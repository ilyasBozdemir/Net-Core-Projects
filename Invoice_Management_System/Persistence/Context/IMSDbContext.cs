using Application.Interfaces.Context;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Extensions.Seeding;
using Persistence.Mapping;
using System.Text;

namespace Persistence.Context
{
    //public class IMSDbContext : DbContext , IIMSDbContext
    public class IMSDbContext : IdentityDbContext<AppUser, AppRole, Guid>,
        IIMSDbContext 
    {
        public IMSDbContext(DbContextOptions options) 
            : base(options) {}
        public DbSet<Log> Logs { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<InvoicePayment> InvoicePayment { get; set; }
       
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApartmentMap());
            modelBuilder.ApplyConfiguration(new ApartmentTypeMap());
            modelBuilder.ApplyConfiguration(new HouseMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new InvoicePaymentMap());
            modelBuilder.ApplyConfiguration(new InvoiceTypeMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new ResidentMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            //
            modelBuilder.Entity<AppUser>(); //AspNetUsers
            modelBuilder.Entity<IdentityRole>(); //AspNetRoles
            modelBuilder.Entity<IdentityUserRole<Guid>>(); //AspNetUserRole
            modelBuilder.Entity<IdentityUserClaim<Guid>>(); //AspNetUserClaim
            modelBuilder.Entity<IdentityUserLogin<Guid>>(); //AspNetUserLogin
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(); //AspNetRoleClaim
            modelBuilder.Entity<IdentityUserToken<Guid>>(); //AspNetUserToken

            modelBuilder.AdminUserSeeding();//custom seeding

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
