using Pottencial.Tiago.Payment.Api.CrossCutting;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto
{
    public interface IRegisterProductService
    {
        Task<ResponseModel> Add(RegisterProductRequestModel registerProductRequestModel);
        Task<ResponseModel> Populate();
        Task<ResponseModel> ListProducts();
    }
}
