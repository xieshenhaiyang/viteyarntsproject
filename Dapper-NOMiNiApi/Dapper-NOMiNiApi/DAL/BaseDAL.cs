using Dapper.Contrib.Extensions;
using Dapper_Demo.SqlContext;
using Dapper_NOMiNiApi.Entity;

namespace Dapper_NOMiNiApi.DAL
{
    public abstract class BaseDAL<T> where T : BaseEntity, new()
    {
        public T Get(Guid id)
        {
            return DbContext.DbConnection.Get<T>(id);
        }

        public  IEnumerable<T> GetAll()
        {
            return DbContext.DbConnection.GetAll<T>();
        }

        public  long Insert(T t)
        {
            return DbContext.DbConnection.Insert<T>(t);
        }

        public  bool Delete(T t)
        {
            return DbContext.DbConnection.Delete<T>(t);
        }

        public  bool DeleteAll()
        {
            return DbContext.DbConnection.DeleteAll<T>();
        }

        public  bool Upudate(T t)
        {
            return DbContext.DbConnection.Update<T>(t);
        }
    }
}
