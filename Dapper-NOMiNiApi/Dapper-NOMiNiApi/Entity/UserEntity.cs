using Dapper;
using Dapper.Contrib.Extensions;

namespace Dapper_NOMiNiApi.Entity
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
        }
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
