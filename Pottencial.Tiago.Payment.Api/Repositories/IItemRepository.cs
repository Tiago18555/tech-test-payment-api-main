using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories
{
    public interface IItemRepository
    {
        Task<List<T>> GetAll<T>(Func<ProductSell, T> predicate);
        ProductSell GetById(long id);
        Task<ProductSell> Add(ProductSell sell);
        IEnumerable<ProductSell> AddRange(params ProductSell[] sell);
        ProductSell Update(ProductSell sell);
    }
}
