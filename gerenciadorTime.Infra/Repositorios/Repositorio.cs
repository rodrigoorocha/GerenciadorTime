using gerenciadorTime.Compartilhado;
using gerenciadorTime.Infra.Context;
using GerenciadorTime.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace gerenciadorTime.Infra.Repositorios
{
    public class Repositorio<T> : IRepository<T> where T : Base
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }
        public Repositorio(DbContextGerenciadorTime context)
        {
            this.Context = context;
            this.Query = Context.Set<T>();
        }

        public async Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await this.Query.AnyAsync(expression);
        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await this.Query.FindAsync(id);
            if (obj != null)
            {
                this.Query.Remove(obj);
                await this.Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>?> FindAllByCriterioAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await this.Query.Where(expression).ToListAsync();
        }

        public  async Task<T?> FindOneByCriterioAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await this.Query.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
           return await this.Query.ToListAsync();

        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task<IEnumerable<T>?> GetByIdsAsync(List<Guid> ids)
        {
            return await this.Query.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<Guid> SaveAsync(T entity)
        {
            var obj = await this.Query.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (obj != null)
            {
                this.Context.Entry(obj).CurrentValues.SetValues(entity);
            }
            else
            {
                await this.Query.AddAsync(entity);
            }
            await this.Context.SaveChangesAsync();
            return entity.Id; // Return the GUID of the saved entity
        }

        
    }
}
