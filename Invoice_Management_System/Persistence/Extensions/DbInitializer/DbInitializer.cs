using Persistence.Context;

namespace Persistence.Extensions.DbInitializer
{
    public class DbInitializer
    {
        public static void Initialize(IMSDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            //if (dbContext.Users.Any()) return;
            //if (dbContext.Users.Any()) return;
            //if (dbContext.Users.Any()) return;
            //if (dbContext.Users.Any()) return;
         
            //  Logs Users Apartments ApartmentTypes  Houses Residents Invoices InvoiceTypes InvoicePayment

            // seeding

            dbContext.SaveChanges();
        }
    }
}
