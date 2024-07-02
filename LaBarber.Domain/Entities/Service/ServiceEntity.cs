using LaBarber.Domain.Dtos.Service;
using LaBarber.Domain.Entities.BarberUnit;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Service
{
    [Table("Service")]
    public class ServiceEntity
    {
        public ServiceEntity()
        {
            Id = 0;
            Name = string.Empty;
            TimeToComplete = null;
            Value = 0;
            CommissionPercent = 0;
            BarberUnitId = 0;
            BarberUnit = null;
        }

        public ServiceEntity(ServiceDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            TimeToComplete = dto.TimeToComplete;
            CommissionPercent = dto.CommissionPercent;
            BarberUnitId = dto.BarberUnitId;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("TimeToComplete")]
        public TimeSpan? TimeToComplete { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        [Column("CommissionPercent")]
        public int CommissionPercent { get; set; }

        [ForeignKey("BarberUnit")]
        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public virtual BarberUnitEntity? BarberUnit { get; set; }
    }
}
