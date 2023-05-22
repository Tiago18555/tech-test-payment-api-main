using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pottencial.Tiago.Payment.Api.Models
{
    public class ProductSell
    {
        [Key]
        public long Id { get; set; }

        //public int Quantity { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long SellId { get; set; }

        [JsonIgnore]
        public Sell Sell { get; set; }
    }
}
