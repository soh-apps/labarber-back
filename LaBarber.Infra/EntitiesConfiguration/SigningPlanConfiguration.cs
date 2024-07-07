using LaBarber.Domain.Dtos.SigningPlan;
using LaBarber.Domain.Entities.SigningPlan;
using LaBarber.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaBarber.Infra.EntitiesConfiguration
{
    public class SigningPlanConfiguration : IEntityTypeConfiguration<SigningPlanEntity>
    {
        public void Configure(EntityTypeBuilder<SigningPlanEntity> builder)
        {
            builder.HasData(
                new SigningPlanEntity(new SigningPlanDto(1, "gratuito", 0, PaymentType.None, 10, 2))
            );
        }
    }
}
