namespace VietSacBackend._4.Core.Model
{
    public class ResponseModel
    {
        public string? MessageError { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
