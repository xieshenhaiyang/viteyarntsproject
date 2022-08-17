using Dapper_NOMiNiApi.Entity;

namespace Dapper_NOMiNiApi.SqlContext
{
    public abstract class DapperExtHelperBase<T> where T : BaseEntity, new()
    {
        public abstract bool Delete(T t);
        public abstract bool DeleteAll();
        public abstract T Get(Guid id);
        public abstract IEnumerable<T> GetAll();
        public abstract long Insert(T t);
        public abstract bool Upudate(T t);
    }
}