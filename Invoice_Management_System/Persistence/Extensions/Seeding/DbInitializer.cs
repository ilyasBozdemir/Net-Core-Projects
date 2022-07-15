using Core.Utilities.Security.Hashing;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System.Numerics;
using System.Text;

namespace Persistence.Extensions.Seeding
{
    public class DbInitializer
    {
        public static void Initialize(IMSDbContext dbContext, IServiceProvider services)
        {
            //ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            dbContext.Database.EnsureCreated();

            AddEntitySeed(dbContext);
            dbContext.SaveChanges();
        }
        private static void AddEntitySeed(IMSDbContext dbContext)
        {
            //if (dbContext.Users.Any()) return;

            //  Logs Users Apartments ApartmentTypes  Houses Residents Invoices InvoiceTypes InvoicePayment

            // seeding

        }
    }
}
