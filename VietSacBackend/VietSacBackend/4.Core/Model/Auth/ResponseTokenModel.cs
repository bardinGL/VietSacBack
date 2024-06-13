using VietSacBackend._4.Core.Model.User;

namespace VietSacBackend._4.Core.Model.Auth
{
    public class ResponseTokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public ResponseUserModel ResponseUserModel { get; set; }
    }
}
