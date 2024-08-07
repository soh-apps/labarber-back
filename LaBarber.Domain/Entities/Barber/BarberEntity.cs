﻿using LaBarber.Domain.Dtos.Barber;
using LaBarber.Domain.Entities.BarberUnit;
using LaBarber.Domain.Entities.Credential;
using LaBarber.Domain.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Barber
{
    [Table("Barber")]
    public class BarberEntity
    {
        public BarberEntity()
        {
            Id = 0;
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            ZipCode = string.Empty;
            Phone = string.Empty;
            Cellphone = string.Empty;
            Status = 0;
            RegisterDate = DateTime.UtcNow;
            BarberUnitId = 0;
            BarberUnit = null;
            Commissioned = false;
            LastPayment = DateTime.UtcNow;
            NextPayment = DateTime.UtcNow;
            CredentialId = 0;
            Credential = null;
            Number = string.Empty;
            Complement = string.Empty;
        }

        public BarberEntity(BarberDto dto)
        {
            Name = dto.Name;
            City = dto.City;
            State = dto.State;
            Street = dto.Street;
            Number = dto.Number;
            ZipCode = dto.ZipCode;
            Phone = dto.Phone.OnlyNumbers();
            Cellphone = dto.Cellphone.OnlyNumbers();
            Complement = dto.Complement;
            Status = BarberStatus.Active;
            RegisterDate = DateTime.UtcNow;
            Commissioned = dto.Commissioned;
            BarberUnitId = dto.BarberUnitId;
            CredentialId = dto.CredentialId;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        [Column("Number")]
        public string Number { get; set; }

        [Column("Complement")]
        public string Complement { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("Cellphone")]
        public string Cellphone { get; set; }

        [Column("Status")]
        public BarberStatus Status { get; set; }

        [Column("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public virtual BarberUnitEntity? BarberUnit { get; set; }

        [Column("Commissioned")]
        public bool Commissioned { get; set; }

        [Column("LastPayment")]
        public DateTime? LastPayment { get; set; }

        [Column("NextPayment")]
        public DateTime? NextPayment { get; set; }


        [ForeignKey("Credential")]
        [Column("CredentialId")]
        public int CredentialId { get; set; }

        public CredentialEntity? Credential { get; set; }
    }
}
