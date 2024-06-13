using System.ComponentModel.DataAnnotations.Schema;

namespace VietSacBackend._3.Repository.Data
{
    [Table("PaymentMenthod")]
    public class PaymentMenthodEntity : Entity
    {
        public string name { get; set; }
    }
}
