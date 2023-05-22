using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda
{
    public static class CreateOrderUtils
    {
        public static decimal GetTotalPrice(this List<ProductSell> source)
        {
            if(source.Any(x => x.Product.Quantity <= 0))            
                throw new Exception("Quantidade de produtos deve ser maior do que 1");
            
            return source.Sum(x => x.Product.Quantity * x.Product.Price);
        }
    }
}
