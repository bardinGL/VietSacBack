namespace VietSacBackend._4.Core.Model.User
{
    public class RequestUserModel
    {
        public string? userName { get; set; }
        public string? Name { get; set; }
        public string? password { get; set; }

        public string? email { get; set; }

        public string? phone { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public string role_id { get; set; }

        public string? address { get; set; }
    }
}
