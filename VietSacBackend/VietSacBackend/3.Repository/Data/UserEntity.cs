using System.ComponentModel.DataAnnotations.Schema;

namespace VietSacBackend._3.Repository.Data
{
    public class UserEntity :Entity
    {
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        public string role_id { get; set; }

        [ForeignKey(nameof(role_id))]
        public RoleEntity Role { get; set; }
    }
}
