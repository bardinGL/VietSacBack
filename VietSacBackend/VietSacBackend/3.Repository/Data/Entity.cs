using System.ComponentModel.DataAnnotations;

namespace VietSacBackend._3.Repository.Data
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString("N");
            CreatedTime = LastUpdatedTime = GetCurrenTime();
        }
        [Key]
        public string Id { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }

        protected DateTimeOffset GetCurrenTime()
        {
            DateTime serverTime = DateTime.UtcNow;
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");
            DateTime _localTime = TimeZoneInfo.
                ConvertTimeFromUtc(serverTime, vietnamTimeZone);
            return _localTime;
        }
    }
}
