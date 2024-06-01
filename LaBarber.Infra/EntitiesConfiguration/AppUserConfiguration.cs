using LaBarber.Domain.Entities.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaBarber.Infra.EntitiesConfiguration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUserEntity>
    {
        public void Configure(EntityTypeBuilder<AppUserEntity> builder)
        {
            builder.HasData(
                new AppUserEntity(1, "admin", null, 1)
            );
        }
    }
}
