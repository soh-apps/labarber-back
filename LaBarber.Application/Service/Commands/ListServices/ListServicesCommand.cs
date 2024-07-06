using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.ListServices.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Service.Commands.ListServices
{
    public class ListServicesCommand(int userId, int? barberUnitId, string role) : Command<List<ServiceOutput>>
    {
        public int UserId { get; set; } = userId;
        public int? BarberUnitId { get; set;} = barberUnitId;
        public string Role { get; set; } = role;

        public override bool IsValid()
        {
            ValidationResult = new ListServicesValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    } 
}