using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;

namespace Application
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        Task<T> GetById(object id);
        void Insert(T entity);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext context;
        private DbSet<T> dbSet;

        public GenericRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }



        public IQueryable<T> Query()
        {
            return dbSet;
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }
    }
}
