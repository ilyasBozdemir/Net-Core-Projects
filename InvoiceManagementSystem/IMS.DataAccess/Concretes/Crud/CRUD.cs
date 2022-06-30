using IMS.Core.Entities.Abstracts;
using IMS.DataAccess.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Concretes.Crud
{
    public class CRUD : ICRUD
    {
        #region CRUD
        /// <summary>
        /// Create a new record of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectForDb"></param>
        /// <returns></returns>
        public async Task<T> Create<T>(T objectForDb) where T : class
        {
            //try
            //{
            //    using (var context = new InvoiceManagementDbContext(InvoiceManagementDbContext.Options.DatabaseOptions))
            //    {
            //        await context.AddAsync<T>(objectForDb);
            //        await context.SaveChangesAsync();
            //        return objectForDb;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            throw new Exception();
        }

        /// <summary>
        /// Get a record from the database of Type T, by passing the Id(Primary Key) of the object type you want back. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<T> Read<T>(Int64 entityId) where T : class
        {
            //try
            //{
            //    using (InvoiceManagementDbContext context = new InvoiceManagementDbContext(InvoiceManagementDbContext.Options.DatabaseOptions))
            //    {
            //        T result = await context.FindAsync<T>(entityId);
            //        return result;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            throw new Exception();
        }

        /// <summary>
        /// Gets all records from the database of Type T. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Generic List Object</returns>
        public async Task<List<T>> ReadAll<T>() where T : class
        {
            //try
            //{
            //    using (InvoiceManagementDbContext context = new InvoiceManagementDbContext(InvoiceManagementDbContext.Options.DatabaseOptions))
            //    {
            //        var result = await context.Set<T>().ToListAsync();
            //        return result;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            throw new Exception();
        }

        /// <summary>
        /// Update a record in the database of Type T, by passing both updated value and the primary key. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToUpdate"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<T> Update<T>(T objectToUpdate, Int64 entityId) where T : class
        {
            //try
            //{
            //    using (var context = new InvoiceManagementDbContext(InvoiceManagementDbContext.Options.DatabaseOptions))
            //    {
            //        var objectFound = await context.FindAsync<T>(entityId);
            //        if (objectFound != null)
            //        {
            //            context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
            //            await context.SaveChangesAsync();
            //        }
            //        return objectFound;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            throw new Exception();
        }

        /// <summary>
        /// Delete a record of Type T from the database by passing the primary key value of the object you want deleted for the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public async Task<bool> Delete<T>(Int64 entityId) where T : class
        {
            //try
            //{
            //    using (InvoiceManagementDbContext context = new InvoiceManagementDbContext(InvoiceManagementDbContext.Options.DatabaseOptions))
            //    {
            //        T recordToDelete = await context.FindAsync<T>(entityId);
            //        if (recordToDelete != null)
            //        {
            //            context.Remove(recordToDelete);
            //            await context.SaveChangesAsync();
            //            return true;
            //        }
            //        return false;
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
            throw new Exception();
        }

      
        #endregion
    }
}
