using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Data;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.BuscarVenda
{

    public class FindOrderService : IFindOrderService
    {
        private ISellRepository repository { get; set; }
        private ISellerRepository sellerRepository { get; set; }
        private IProductRepository productRepository { get; set; }
        public FindOrderService(ISellRepository repository, ISellerRepository sellerRepository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.sellerRepository = sellerRepository;
            this.productRepository = productRepository;
        }



        public ResponseModel FindOrder(long id)
        {
            if (id == 0) return GenericResponses.BadRequest("Id do pedido nulo ou vazio");

            var res = repository.GetById(id);

            if (res == null) return GenericResponses.NotFound("Pedido não encontrado");

            return res.Ok();
        }
        public async Task<ResponseModel> ListOrders()
        {
            var res = await repository.GetAll();

            return res.Ok();
        }
    }
}
