using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories
{
    public interface IProductRepository
    {
        Task<List<T>> GetAll<T>(Func<Product, T> predicate);
        Product GetById(long id);
        Task<Product> Add(Product product);
        public List<T> AddRange<T>(Func<Product, T> predicate, params Product[] product);
    }
}
