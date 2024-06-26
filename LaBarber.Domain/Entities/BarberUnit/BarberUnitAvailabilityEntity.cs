﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaBarber.Domain.Entities.BarberUnit
{
    [Table("BarberUnitAvailability")]
    public class BarberUnitAvailabilityEntity
    {
        public BarberUnitAvailabilityEntity()
        {
            Id = 0;
            WorkingDay = 0;
            StartWorkingHour = new TimeSpan(0, 0, 0);
            EndWorkingHour = new TimeSpan(0, 0, 0);
            BarberUnitId = 0;
            BarberUnit = null;
        }

        public BarberUnitAvailabilityEntity(int workingDay, TimeSpan startWorkingHour, TimeSpan endWorkingHour, int barberUnitId)
        {
            WorkingDay = workingDay;
            StartWorkingHour = startWorkingHour;
            EndWorkingHour = endWorkingHour;
            BarberUnitId = barberUnitId;
            BarberUnit = null;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("WorkingDay")]
        public int WorkingDay { get; set; }

        [Column("StartWorkingHour")]
        public TimeSpan StartWorkingHour { get; set; }

        [Column("EndWorkingHour")]
        public TimeSpan EndWorkingHour { get; set; }

        [ForeignKey("BarberUnit")]
        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public virtual BarberUnitEntity? BarberUnit { get; set; }
    }
}
