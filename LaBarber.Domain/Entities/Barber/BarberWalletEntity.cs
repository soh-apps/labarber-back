using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Barber
{
    [Table("BarberWallet")]
    public class BarberWalletEntity
    {
        public BarberWalletEntity()
        {
            Id = 0;
            BarberId = 0;
            Commission = 0;
            Earnings = 0;
            Barber = new BarberEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Commission")]
        public decimal Commission { get; set; }

        [Column("Earnings")]
        public decimal Earnings { get; set; }

        [ForeignKey("Barber")]
        [Column("BarberId")]
        public int BarberId { get; set; }

        public virtual BarberEntity Barber { get; set; }
    }
}
