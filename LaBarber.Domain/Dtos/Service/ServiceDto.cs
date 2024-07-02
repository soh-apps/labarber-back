using LaBarber.Domain.Entities.Service;

namespace LaBarber.Domain.Dtos.Service
{
    public class ServiceDto
    {
        public ServiceDto()
        {
            Id = 0;
            Name = string.Empty;
            TimeToComplete = null;
            Value = 0;
            CommissionPercent = 0;
            BarberUnitId = 0;
        }

        public ServiceDto(ServiceEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            TimeToComplete = entity.TimeToComplete;
            CommissionPercent = entity.CommissionPercent;
            BarberUnitId = entity.BarberUnitId;
        }

        public ServiceDto(int id, string name, TimeSpan? timeToComplete, decimal value, int commissionPercent, int barberUnitId)
        {
            Id = id;
            Name = name;
            TimeToComplete = timeToComplete;
            Value = value;
            CommissionPercent = commissionPercent;
            BarberUnitId = barberUnitId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan? TimeToComplete { get; set; }
        public decimal Value { get; set; }
        public int CommissionPercent { get; set; }
        public int BarberUnitId { get; set; }
    }
}