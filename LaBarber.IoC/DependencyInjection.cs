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

namespace LaBarber.IoC
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddTransient<IRequestHandler<LoginCommand, LoginOutput>, LoginHandler>();

            services.AddScoped<ILoginUseCase, LoginUseCase>();
            services.AddScoped<ITokenUseCase, TokenUseCase>();

            services.AddScoped<ICredentialRepository, CredentialRepository>();

            //AppUser
            services.AddScoped<IAppUserUseCase, AppUserUseCase>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            //Company
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUseCase, CompanyUseCase>();
            services.AddTransient<IRequestHandler<CreateCompanyCommand, bool>, CreateCompanyHandler>();
            services.AddTransient<IRequestHandler<CreateCompanyUserCommand, bool>, CreateCompanyUserHandler>();
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
