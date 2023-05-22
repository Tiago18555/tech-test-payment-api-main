using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto;
using Pottencial.Tiago.Payment.Api.CrossCutting.Validations;
using Pottencial.Tiago.Payment.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda
{
    public class CreateOrderRequestModel
    {
        [Required]
        public int SellerId { get; set; }

        [NotEmptyList]
        public List<ProductSellRequestModel> Product { get; set; }
    }

    public class ProductSellRequestModel
    {
        [Required]
        public long Id { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
