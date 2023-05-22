using Pottencial.Tiago.Payment.Api.CrossCutting.Enums;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda
{
    public class CreateOrderResponseModel
    {
        public long Id { get; set; }
        public Seller Seller { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }


        //[NotNullList]
        public List<ProductSell> ProductSells { get; set; }

        public Status Status { get; set; }
    }
}
