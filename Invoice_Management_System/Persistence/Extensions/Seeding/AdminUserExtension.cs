using Core.Utilities.Security.Hashing;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Persistence.Extensions.Seeding
{
    public static class AdminUserExtension
    {
        public static void AdminUserSeeding(this ModelBuilder modelBuilder)
        {
            const string USER_1 = "be175bf2-9a15-4708-89b4-15b57f3bfeda",
                         USER_2 = "979488cb-5c01-4c55-9a18-30f71b5acf35",
                         USER_PASSWORD = "testUserSecurityKey";

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(USER_PASSWORD, out passwordHash, out passwordSalt);

            // Crear ROLES
            List<IdentityRole> roles = new List<IdentityRole>() {
                new IdentityRole ()
                {
                   Id = USER_1,  Name = "Administrator", NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole ()
                {
                    Id=USER_2, Name = "Visitor", NormalizedName = "VISITOR"
                }
            };

        

            // Crear USERS
            List<AppUser> users = new List<AppUser>() {
                new AppUser {
                    Id=Guid.Parse(USER_1),
                    FirstName = "ilyas",
                    LastName = "Bozdemir",
                    Email = "bozdemir.ib70@gmail.com",
                    NormalizedEmail = "BOZDEMIR.IB70@GMAIL.COM",
                    UserName = "Bozdemir.ilyas",
                    NormalizedUserName = "BOZDEMIR.ILYAS",
                    PhoneNumber = "+90 546 546 45 64",//random
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = Encoding.ASCII.GetString(passwordHash),
                    PasswordSalt = Encoding.ASCII.GetString(passwordSalt)
                },
                new AppUser {
                    Id=Guid.Parse(USER_2),
                    FirstName = "test user",
                    LastName = "user test",
                    Email = "test@xx.com",
                    NormalizedEmail = "TEST@XX.COM",
                    UserName = "test.user",
                    NormalizedUserName = "TEST.USER",
                    PhoneNumber = "+90 546 546 45 65",//random
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    PasswordHash = Encoding.ASCII.GetString(passwordHash),
                    PasswordSalt = Encoding.ASCII.GetString(passwordSalt)
                }
            };

          

            List<IdentityUserRole<Guid>> userRoles = new List<IdentityUserRole<Guid>>();
            userRoles.Add(new IdentityUserRole<Guid>
            {
                UserId = users[0].Id,
                RoleId = Guid.Parse( roles.First(x => x.Name == "Administrator").Id)
            });
            userRoles.Add(new IdentityUserRole<Guid>
            {
                UserId = users[1].Id,
                RoleId = Guid.Parse(roles.First(x => x.Name == "Visitor").Id)
            });

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<AppUser>().HasData(users);
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);
            /*
             * The INSERT statement conflicted with the FOREIGN KEY constraint 
             * "FK_AspNetUserRoles_AspNetRoles_RoleId".
             * The conflict occurred in database "InvoiceManagementDB", table "dbo.AspNetRoles",
             * column 'Id'.
             * The statement has been terminated.
             */
        }
    }
}
