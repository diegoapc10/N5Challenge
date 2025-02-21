using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly N5challengeContext _context;
        private readonly DbSet<T> entity;

        public Repository(N5challengeContext context)
        {
            this._context = context;
            this.entity = this._context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            int record = 0;
            using (IDbContextTransaction transaction = await this._context.Database.BeginTransactionAsync())
            {
                this.entity.Add(entity);
                record = await this._context.SaveChangesAsync();
                if (record > 0)
                {
                    transaction.Commit();
                    return entity;
                }
                else
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            if (id == 0) throw new ArgumentNullException("Not Id");
            int record = 0;
            using (IDbContextTransaction transaction = await this._context.Database.BeginTransactionAsync())
            {
                var entitySearch = await _context.FindAsync<T>(id);
                if (entitySearch == null)
                    return null;

                foreach(var item in entitySearch.GetType().GetProperties())
                {
                    if(item.Name.Equals("Id"))
                        continue;

                    var propertyValue = entity.GetType().GetProperty(item.Name).GetValue(entity);

                    if (propertyValue == null)
                        continue;

                    entitySearch.GetType().GetProperty(item.Name).SetValue(entitySearch, propertyValue);
                }
                this._context.Update<T>(entitySearch);
                record = await this._context.SaveChangesAsync();
                if (record > 0)
                {
                    transaction.Commit();
                    return entitySearch;
                }
                else
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }
    }
}
