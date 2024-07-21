using FluentValidation;

namespace LaBarber.Application.MonthlyPlan.Commands.Validation
{
    public class GetAllMonthlyPlansValidations : AbstractValidator<GetAllMonthlyPlansCommand>
    {
        public GetAllMonthlyPlansValidations()
        {
        }
    }
}