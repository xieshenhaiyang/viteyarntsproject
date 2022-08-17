using Dapper.Contrib.Extensions;

namespace Dapper_NOMiNiApi.Entity
{
    [Table("Order")]
    public class OrderEntity
    {
        [Key]
        public Guid OrderId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
