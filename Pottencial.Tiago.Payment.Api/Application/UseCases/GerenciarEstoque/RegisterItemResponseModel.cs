using Pottencial.Tiago.Payment.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto
{
    public class RegisterItemResponseModel
    {
        [JsonIgnore]
        public long Id { get; set; }
        public ProductResponseModel Product { get; set; }
        public int Quantity { get; set; }

    }

    public class ProductResponseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public IEnumerable<ProductSell> Items { get; set; }
    }
}
