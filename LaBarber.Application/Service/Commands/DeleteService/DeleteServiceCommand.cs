using LaBarber.Application.Service.Commands.DeleteService.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Service.Commands.DeleteService
{
    public class DeleteServiceCommand(int id, int userId, string userRole) : Command<bool>
    {
        public int Id { get; set; } = id;
        public int UserId { get; set; } = userId;
        public string UserRole { get; set; } = userRole;

        public override bool IsValid()
        {
            ValidationResult = new DeleteServiceValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
