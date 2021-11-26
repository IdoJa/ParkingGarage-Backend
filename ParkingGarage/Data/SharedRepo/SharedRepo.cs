using System;
using Microsoft.EntityFrameworkCore;

namespace ParkingGarage.Data.SharedRepo
{
    public class SharedRepo<T> where T : class
    {
        protected readonly MainContext Context;

        protected SharedRepo(MainContext context)
        {
            Context = context;
        }

        protected void Create(DbSet<T> dbSet, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            dbSet.Add(entity);
            SaveChanges();
        }

        protected bool SaveChanges()
        {
            return (Context.SaveChanges() >= 0);
        }
    }
}