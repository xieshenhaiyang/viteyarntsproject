using Blog.IRepository;
using Blog.Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {
        public BaseRepository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {

            base.Context = context;//ioc注入的对象
            // base.Context=DbScoped.SugarScope; SqlSugar.Ioc这样写
            // base.Context=DbHelper.GetDbInstance()当然也可以手动去赋值
            // 创建数据库
            base.Context.DbMaintenance.CreateDatabase();
            base.Context.CodeFirst.SetStringDefaultLength(200).InitTables(
                typeof(BlogNews),
                typeof(TypeInfo),
                typeof(WriterInfo)
                );
        }
        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await base.InsertAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await base.GetListAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>().ToPageListAsync(page, size, total);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression, int page, int size, RefAsync<int> total)
        {
            return await base.Context.Queryable<TEntity>()
                .Where((expression))
                .ToPageListAsync(page, size, total);
        }

        public override async Task<bool> UpdateAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }
    }
}
