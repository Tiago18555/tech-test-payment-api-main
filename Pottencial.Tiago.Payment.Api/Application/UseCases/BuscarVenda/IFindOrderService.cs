using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.BuscarVenda
{
    public interface IFindOrderService
    {
        ResponseModel FindOrder(long id);
        Task<ResponseModel> ListOrders();
    }
}
