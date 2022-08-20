using SqlSugar;

namespace Blog.Entity
{
    public class BaseId
    {
        [SugarColumn(IsIdentity = true,IsPrimaryKey = true)]
        public int Id { get; set; }
    }
}