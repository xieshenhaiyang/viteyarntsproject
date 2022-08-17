using Dapper.Contrib.Extensions;

namespace Dapper_NOMiNiApi.Entity
{
    [Table("Menu")]
    public class MenuEntity:BaseEntity
    {
        [Key]
        public Guid MenuId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsShow { get; set; }
        public string Icon { get; set; }
        public Guid ParentId { get; set; }
    }
}
