using LaBarber.Domain.Configuration;
using LaBarber.Domain.Entities.Appointment;
using LaBarber.Domain.Entities.AppUser;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Credential;
using LaBarber.Domain.Entities.Customer;
using LaBarber.Domain.Entities.MonthlyPlan;
using LaBarber.Domain.Entities.Profile;
using LaBarber.Domain.Entities.Service;
using LaBarber.Domain.Entities.SigningPlan;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;

namespace LaBarber.Infra.Configuration
{
    public class ContextBase : DbContext
    {
        private readonly string _connectionString;
        public ContextBase(DbContextOptions<ContextBase> options, IOptions<Secrets> secrets) : base(options)
        {
            _connectionString = secrets.Value.ConnectionString;
        }

        public DbSet<AppointmentEntity> Appointment => Set<AppointmentEntity>();
        public DbSet<AppUserEntity> AppUser => Set<AppUserEntity>();
        public DbSet<BarberAvailabilityEntity> BarberAvailability => Set<BarberAvailabilityEntity>();
        public DbSet<BarberEntity> Barber => Set<BarberEntity>();
        public DbSet<BarberPaymentHistoryEntity> BarberPaymentHistory => Set<BarberPaymentHistoryEntity>();
        public DbSet<BarberUnitEntity> BarberUnit => Set<BarberUnitEntity>();
        public DbSet<BarberUnitAvailabilityEntity> BarberUnitAvailability => Set<BarberUnitAvailabilityEntity>();
        public DbSet<BarberWalletEntity> BarberWallet => Set<BarberWalletEntity>();
        public DbSet<CompanyEntity> Company => Set<CompanyEntity>();
        public DbSet<CustomerEntity> Customer => Set<CustomerEntity>();
        public DbSet<CustomerPaymentHistoryEntity> CustomerPaymentHistory => Set<CustomerPaymentHistoryEntity>();
        public DbSet<MonthlyPlanEntity> MonthlyPlan => Set<MonthlyPlanEntity>();
        public DbSet<ProfileEntity> Profile => Set<ProfileEntity>();
        public DbSet<ServiceEntity> Service => Set<ServiceEntity>();
        public DbSet<SigningPlanEntity> SigningPlan => Set<SigningPlanEntity>();
        public DbSet<CredentialEntity> Credential => Set<CredentialEntity>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var types = modelBuilder.Model.GetEntityTypes()
                .Select(t => t.ClrType).ToHashSet();

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                t => t.GetInterfaces()
                .Any(i => i.IsGenericType
                && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
                && types.Contains(i.GenericTypeArguments[0]))
                );

            modelBuilder.Entity<ProfileEntity>().HasData(
                  new ProfileEntity(1, "Master", DateTime.UtcNow, true)
                , new ProfileEntity(2, "Admin", DateTime.UtcNow, true)
                , new ProfileEntity(3, "Manager", DateTime.UtcNow, true)
                , new ProfileEntity(4, "Barber", DateTime.UtcNow, true)
                , new ProfileEntity(5, "Customer", DateTime.UtcNow, true)
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
