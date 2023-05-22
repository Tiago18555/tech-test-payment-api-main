using Pottencial.Tiago.Payment.Api.CrossCutting;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVendedor
{
    public interface IRegisterSellerService
    {
        Task<ResponseModel> Add(RegisterSellerRequestModel registerProductRequestModel);
        Task<ResponseModel> Populate();
        Task<ResponseModel> ListSellers();
    }

}
