using Core.Utilities.Security.Hashing;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System.Text;

namespace Persistence.Extensions.Seeding
{
    public class DbInitializer
    {
        public static void Initialize(IMSDbContext dbContext, IServiceProvider services)
        {
            //ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            dbContext.Database.EnsureCreated();

            SeedAdminUser(dbContext, services);
            AddEntitySeed(dbContext);
            dbContext.SaveChanges();
        }

        private async static void SeedAdminUser(IMSDbContext dbContext, IServiceProvider services)
        {
            string[] roles = new string[]
                {
                    "Sistem Yöneticisi","Yönetici","Üye",
                    "Misafir","Tedarikçi","Kara Liste","Editör"
                };
            var roleStore = new RoleStore<IdentityRole>(dbContext);
            foreach (string role in roles)
            {


                if (!dbContext.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            var user = new AppUser
            {
                FirstName = "ilyas",
                LastName = "Bozdemit",
                Email = "bozdemir.ib70@gmail.com",
                NormalizedEmail = "BOZDEMIR.IB70@GMAIL.COM",
                UserName = "Bozdemir.ilyas",
                NormalizedUserName = "BOZDEMIR.ILYAS",
                PhoneNumber = "+905464667898",//random
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = "",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!dbContext.Roles.Any(r => r.Name == roles[0]))
            {
                await roleStore.CreateAsync(new IdentityRole
                {
                    Name = roles[0],
                    NormalizedName = roles[0].ToUpper()
                });
            }

            if (!dbContext.Users.Any(u => u.UserName == user.UserName))
            {
                byte[] passwordHash, passwordSalt;

                HashingHelper.CreatePasswordHash("Bozdemir.12345", out passwordHash, out passwordSalt);
                user.PasswordHash = Encoding.ASCII.GetString(passwordHash);
                user.PasswordSalt = Encoding.ASCII.GetString(passwordSalt);


                //var userStore = new UserStore<AppUser>(dbContext);

                //var userStore = new UserStore<AppUser>(dbContext);


                //await userStore.CreateAsync(user);
                //await userStore.AddToRoleAsync(user, roles[0]);
            }

            await dbContext.SaveChangesAsync();

        }

        private static void AddEntitySeed(IMSDbContext dbContext)
        {
            //if (dbContext.Users.Any()) return;

            //  Logs Users Apartments ApartmentTypes  Houses Residents Invoices InvoiceTypes InvoicePayment

            // seeding
        }
    }
}
