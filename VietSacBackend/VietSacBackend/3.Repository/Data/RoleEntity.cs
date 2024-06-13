namespace VietSacBackend._3.Repository.Data
{
    public class RoleEntity : Entity
    {
        public string? role_name { get; set; }

        public virtual ICollection<UserEntity> UserEntities { get; set; }
    }
}
