using Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.BuscarVenda;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Repositories
{
    public interface ISellRepository
    {
        Task<List<FindOrderResponseModel>> GetAll();
        FindOrderResponseModel GetById(long id);
        CreateOrderResponseModel Add(Sell sell);
        UpdateOrderResponseModel Update(Sell sell);
    }
}
