using LaBarber.Domain.Base.Exceptions;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaBarber.API.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notificationHandler;

        protected BaseController(INotificationHandler<DomainNotification> notificationHandler)
        {
            _notificationHandler = (DomainNotificationHandler)notificationHandler;
        }

        protected bool IsValidOperation()
        {
            return !_notificationHandler.HasNotification();
        }

        protected IEnumerable<string> GetMessages()
        {
            return _notificationHandler.GetNotifications().Select(x => x.Value).ToList();
        }

        protected int GetUserId()
        {
            if (!string.IsNullOrEmpty(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            }
            else
            {
                throw new DomainException("Id do usuário não encontrado.");
            }
        }
    }
}
