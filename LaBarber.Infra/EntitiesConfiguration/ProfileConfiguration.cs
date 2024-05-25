using LaBarber.Domain.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaBarber.Infra.EntitiesConfiguration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.HasData(
                  new ProfileEntity(1, "Master", new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560), true)
                , new ProfileEntity(2, "Admin", new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560), true)
                , new ProfileEntity(3, "Manager", new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560), true)
                , new ProfileEntity(4, "Barber", new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560), true)
                , new ProfileEntity(5, "Customer", new DateTime(2024, 5, 25, 18, 25, 36, 478, DateTimeKind.Utc).AddTicks(5560), true)
            );
        }
    }
}
