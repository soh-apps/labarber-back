using LaBarber.Domain.Entities.Credential;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaBarber.Infra.EntitiesConfiguration
{
    public class CredentialConfiguration : IEntityTypeConfiguration<CredentialEntity>
    {
        public void Configure(EntityTypeBuilder<CredentialEntity> builder)
        {
            var pwd = "21826A058D9D3DBCDB208EEF87DB2C024BDD6A7DE9ADC1C344E14010EA3730D0A0093A8F57C5AC9EE6ED335B0136764D51E7B9543C8F2EA06F89EC3688ACDADA";
            builder.HasData(new CredentialEntity(1, "teste", pwd, 1, "admin@labarber.com.br"));
        }
    }
}
