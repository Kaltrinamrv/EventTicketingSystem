using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace backend.Entities
{
    [SwaggerSchema(Required = new[] { "amount", "paymentDate" })]
    public class Payment
    {
        public int PaymentID { get; set; }
        
        public int OrderID { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
