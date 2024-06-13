using System.ComponentModel.DataAnnotations.Schema;

namespace VietSacBackend._3.Repository.Data
{
    [Table("UserRefreshToken")]
    public class UserRefreshToken : Entity
    {
        public string User_Id { get; set; }
        [ForeignKey(nameof(User_Id))]
        public UserEntity UserEntity { get; set; }
        public string RefreshToken { get; set; }
        public string JwtId { get; set; }
        public bool isUsed { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
