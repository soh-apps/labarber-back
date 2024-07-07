using LaBarber.Domain.Enums;

namespace LaBarber.Domain.Dtos.SigningPlan
{
    public class SigningPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public PaymentType PaymentType { get; set; }
        public int BarberUnitLimit { get; set; }
        public int BarberLimit { get; set; }

        public SigningPlanDto()
        {
            Id = 0;
            Name = string.Empty;
            Value = 0M;
            PaymentType = PaymentType.None;
            BarberUnitLimit = 0;
            BarberLimit = 0;
        }

        public SigningPlanDto(int id, string name, decimal value, PaymentType paymentType, int barberUnitLimit, int barberLimit)
        {
            Id = id;
            Name = name;
            Value = value;
            PaymentType = paymentType;
            BarberUnitLimit = barberUnitLimit;
            BarberLimit = barberLimit;
        }
    }
}
