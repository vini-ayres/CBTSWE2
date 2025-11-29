using Microsoft.EntityFrameworkCore;
using P02_API.Abstractions;
using P02_API.Models;
using TP02.Context;

namespace P02_API.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbSet<T> DbSet;
        protected readonly ProvaContext context;

        public RepositoryBase(ProvaContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Create(T entity)
        {
            DbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            DbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            DbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public abstract Task<T> GetById(int id);
    }
}
