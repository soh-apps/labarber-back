using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.GetService.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Service.Commands.GetService
{
    public class GetServiceCommand(int id, int userId, string userRole) : Command<ServiceOutput>
    {
        public int Id { get; set; } = id;
        public int UserId { get; set; } = userId;
        public string UserRole { get; set; } = userRole;

        public override bool IsValid()
        {
            ValidationResult = new GetServiceValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}