using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.Login;
using LaBarber.Application.Login.Handlers;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Entities.Credential;
using LaBarber.Infra.Repository.Credential;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using LaBarber.Domain.Entities.Company;
using LaBarber.Infra.Repository.Company;
using LaBarber.Application.Company.Commands;
using LaBarber.Application.Company.Handlers;
using LaBarber.Application.Company.UseCase;
using LaBarber.Application.Company.Commands.CreateCompanyUser;
using LaBarber.Application.AppUser.UseCase;
using LaBarber.Domain.Entities.AppUser;
using LaBarber.Infra.Repository.AppUser;
using LaBarber.Domain.Base.Email;
using LaBarber.Infra.Services;
using LaBarber.Application.Login.Commands.ForgotPassword;
using LaBarber.Application.Login.Commands.RecoverPassword;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.Handlers;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Infra.Repository.Barber;
using LaBarber.Application.Login.Commands.RefreshToken;
using LaBarber.Application.Company.Commands.GetAllCompanies;
using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.GetCompanyById;

namespace LaBarber.IoC
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Login
            services.AddScoped<ILoginUseCase, LoginUseCase>();
            services.AddTransient<IRequestHandler<LoginCommand, LoginOutput>, LoginHandler>();
            services.AddTransient<IRequestHandler<ForgotPasswordCommand, bool>, ForgotPasswordHandler>();
            services.AddTransient<IRequestHandler<RecoverPasswordCommand, bool>, RecoverPasswordHandler>();
            services.AddTransient<IRequestHandler<RefreshTokenCommand, LoginOutput>, RefreshTokenHandler>();


            services.AddScoped<ITokenUseCase, TokenUseCase>();
            services.AddScoped<ILoggedUserRepository, LoggedUserRepository>();
            services.AddScoped<ICredentialRepository, CredentialRepository>();

            //AppUser
            services.AddScoped<IAppUserUseCase, AppUserUseCase>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            //Company
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUseCase, CompanyUseCase>();
            services.AddTransient<IRequestHandler<CreateCompanyCommand, bool>, CreateCompanyHandler>();
            services.AddTransient<IRequestHandler<CreateCompanyUserCommand, bool>, CreateCompanyUserHandler>();
            services.AddTransient<IRequestHandler<GetAllCompaniesCommand, List<CompanyOutput>>, GetAllCompaniesHandler>();
            services.AddTransient<IRequestHandler<GetCompanyByIdCommand, CompanyOutput>, GetCompanyByIdHandler>();

            //BarberUnit
            services.AddScoped<IBarberUnitUseCase, BarberUnitUseCase>();
            services.AddScoped<IBarberUnitRepository, BarberUnitRepository>();
            services.AddTransient<IRequestHandler<CreateBarberUnitCommand, bool>, CreateBarberUnitHandler>();

            //Email
            services.AddScoped<IEmailSender, EmailSender>();
        }

        public static void AddAuthenticationJwt(this IServiceCollection services, string secret)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Append("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };

                });
        }

    }
}
