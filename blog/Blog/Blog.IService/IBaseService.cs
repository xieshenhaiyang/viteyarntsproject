using SqlSugar;
using System.Linq.Expressions;

namespace Blog.IService
{
    public interface IBaseService<TEntity> where TEntity : class,new ()
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        Task<IEnumerable<TEntity>> QueryAsync();
        Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression, int page, int size, RefAsync<int> total);
    }
}