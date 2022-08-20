using Blog.IRepository;
using Blog.IService;
using SqlSugar;
using System.Linq.Expressions;

namespace Blog.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await _baseRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _baseRepository.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> QueryAsync()
        {
            return await _baseRepository.QueryAsync();
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _baseRepository.QueryAsync(expression); 
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await _baseRepository.QueryAsync(page, size, total);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression, int page, int size, RefAsync<int> total)
        {
            return await _baseRepository.QueryAsync(expression, page, size, total);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}