using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda;
using Pottencial.Tiago.Payment.Api.Models;
using System.ComponentModel.DataAnnotations;
using static Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda.CreateOrderRequestModel;

namespace Pottencial.Tiago.Payment.Api.CrossCutting.Validations
{
    public class NotEmptyList : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var res = (List<ProductSellRequestModel>)value;
            return res.Count >= 1;
        }
    }
}
