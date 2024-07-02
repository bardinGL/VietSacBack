namespace VietSacBackend._4.Core.Model.Auth
{
    public class SignUpModel
    {
        public string userName { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string? phone { get; set; }

        public string role_id { get; set; }
        
        public string? firstName { get; set; }
        
        public string? lastName { get; set; }
        
        public DateTime? DOB { get; set; }
        
        public string? gender { get; set; }

        public string? address { get; set; }
    }
}
