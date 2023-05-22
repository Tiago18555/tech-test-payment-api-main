using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda
{
    public interface IUpdateOrderService
    {
        ResponseModel UpdateStatus(UpdateOrderRequestModel updateOrderRequestModel);
    }
}
