using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVendedor;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories
{

    public interface ISellerRepository
    {
        Task<List<RegisterSellerResponseModel>> GetAll();
        Seller GetById(long id);
        Task<RegisterSellerResponseModel> Add(Seller product);
        Task<IEnumerable<RegisterSellerResponseModel>> AddRange(params Seller[] sellers);

    }
}
