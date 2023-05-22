using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto
{
    public interface IRegisterItemService
    {
        Task<ResponseModel> Add(RegisterItemRequestModel registerProductRequestModel);
        Task<ResponseModel> ListUnits();
       //Task<ResponseModel> Populate();
    }
}
