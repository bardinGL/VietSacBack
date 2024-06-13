namespace VietSacBackend._4.Core.Model.User
{
    public class ResponseUserModel
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string? fullName { get; set; }
        public string password { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public string role_id { get; set; }
        public string? address { get; set; }
    }
}
