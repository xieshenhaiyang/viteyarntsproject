using Dapper_Demo.SqlContext;
using Dapper_NOMiNiApi.Entity;
using Dapper.Contrib.Extensions;

namespace Dapper_NOMiNiApi.SqlContext
{
    public class DapperExtHelper<T> : DapperExtHelperBase<T> where T : BaseEntity, new() 
    {
        public override T Get(Guid id)
        {
            return DbContext.DbConnection.Get<T>(id);
        }

        public override IEnumerable<T> GetAll()
        {
            return DbContext.DbConnection.GetAll<T>();
        }

        public override long Insert(T t)
        {
            return DbContext.DbConnection.Insert<T>(t);
        }

        public override bool Delete(T t)
        {
            return DbContext.DbConnection.Delete<T>(t);
        }

        public override bool DeleteAll()
        {
            return DbContext.DbConnection.DeleteAll<T>();
        }

        public override bool Upudate(T t)
        {
            return DbContext.DbConnection.Update<T>(t);
        }
    }
}
