using LaBarber.Domain.Entities.AppUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Profile
{
    [Table("Profile")]
    public class ProfileEntity
    {
        public ProfileEntity()
        {
            Id = 0;
            Name = string.Empty;
            IsActive = false;
            RegisterDate = DateTime.UtcNow;
        }

        public ProfileEntity(int id, string name, DateTime registerDate, bool isActive)
        {
            Id = id;
            Name = name;
            RegisterDate = registerDate;
            IsActive = isActive;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}