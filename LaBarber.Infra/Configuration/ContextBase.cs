using LaBarber.Domain.Configuration;
using LaBarber.Domain.Entities.Appointment;
using LaBarber.Domain.Entities.AppUser;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Customer;
using LaBarber.Domain.Entities.MonthlyPlan;
using LaBarber.Domain.Entities.Profile;
using LaBarber.Domain.Entities.Service;
using LaBarber.Domain.Entities.SigningPlan;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
        public DbSet<BarberWalletEntity> BarberWallet => Set<BarberWalletEntity>();
        public DbSet<CompanyEntity> Company => Set<CompanyEntity>();
        public DbSet<CustomerEntity> Customer => Set<CustomerEntity>();
        public DbSet<CustomerPaymentHistoryEntity> CustomerPaymentHistory => Set<CustomerPaymentHistoryEntity>();
        public DbSet<MonthlyPlanEntity> MonthlyPlan => Set<MonthlyPlanEntity>();
        public DbSet<ProfileEntity> Profile => Set<ProfileEntity>();
        public DbSet<ServiceEntity> Service => Set<ServiceEntity>();
        public DbSet<SigningPlanEntity> SigningPlan => Set<SigningPlanEntity>();


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
            base.OnModelCreating(modelBuilder);
        }
    }
}
