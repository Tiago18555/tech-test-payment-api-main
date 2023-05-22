using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pottencial.Tiago.Payment.Api.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public ICollection<ProductSell> ProductSells { get; set; }
    }
}
