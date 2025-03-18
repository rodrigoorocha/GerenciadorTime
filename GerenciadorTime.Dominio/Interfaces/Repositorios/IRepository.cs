

using System.Linq.Expressions;

namespace GerenciadorTime.Dominio.Interfaces.Repositorios;

public interface IRepository <T> where T : class
{
    Task<int> SaveAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>?> GetByIdsAsync(List<Guid> ids);
    Task<IEnumerable<T>?> GetAllAsync();
    Task<IEnumerable<T>?> FindAllByCriterioAsync(Expression<Func<T, bool>> expression);
    Task<T?> FindOneByCriterioAsync(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);



}
