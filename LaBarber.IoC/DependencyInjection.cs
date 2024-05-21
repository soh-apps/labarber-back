using LaBarber.Application.AppUser.Commands.Login;
using LaBarber.Application.AppUser.Handlers;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Entities.AppUser;
using LaBarber.Infra.Repository.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LaBarber.IoC
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddTransient<IRequestHandler<LoginCommand, bool>, LoginHandler>();

            services.AddScoped<IAppUserRepository, AppUserRepository>();
        }
    }
}
