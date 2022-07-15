using Application.CrossCuttingConcerns.Logging;
using Application.Interfaces.Context;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    //public class IMSDbContext : DbContext , IIMSDbContext
    public class IMSDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IIMSDbContext
    {
        public IMSDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Aidat> Aidats { get; set; }
        public DbSet<Blok> Bloks { get; set; }
        public DbSet<Daire> Apartments { get; set; }
        public DbSet<Fatura> Bills { get; set; }
        public DbSet<Mesaj> Messages { get; set; }
        public DbSet<UserAidat> UserAidats { get; set; }
        public DbSet<UserFatura> UserBills { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.OlusturmaTarihi = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.OlusturmaTarihi = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ApartmentMap());

            //
            modelBuilder.Entity<AppUser>(); //AspNetUsers
            modelBuilder.Entity<IdentityRole>(); //AspNetRoles
            modelBuilder.Entity<IdentityUserRole<Guid>>(); //AspNetUserRole
            modelBuilder.Entity<IdentityUserClaim<Guid>>(); //AspNetUserClaim
            modelBuilder.Entity<IdentityUserLogin<Guid>>(); //AspNetUserLogin
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(); //AspNetRoleClaim
            modelBuilder.Entity<IdentityUserToken<Guid>>(); //AspNetUserToken

            //modelBuilder.AdminUserSeeding();//custom seeding

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
