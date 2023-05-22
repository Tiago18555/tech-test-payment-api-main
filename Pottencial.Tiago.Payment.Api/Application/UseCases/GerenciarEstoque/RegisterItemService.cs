using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto
{
    public class RegisterItemService : IRegisterItemService
    {
        private IItemRepository itemRepository { get; set; }
        private IProductRepository productRepository { get; set; }

        public RegisterItemService(IItemRepository itemRepository, IProductRepository productRepository)
        {
            this.itemRepository = itemRepository;
            this.productRepository = productRepository;
        }

        public async Task<ResponseModel> Add(RegisterItemRequestModel registerProductRequestModel)
        {
            var prod = productRepository.GetById(registerProductRequestModel.ProductId);

            var item = new ProductSell() { ProductId = prod.Id };

            var res = (await this.itemRepository.Add(item)).Created();

            return res;
        }

        public async Task<ResponseModel> ListUnits() =>
            (await itemRepository.GetAll(x => x.MapObjectTo(new RegisterItemResponseModel()))).Ok();
    }
}
