using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda
{
    public interface ICreateOrderService
    {
        ResponseModel CreateOrder(CreateOrderRequestModel createOrderRequestModel);
    }
}
