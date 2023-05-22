using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.CrossCutting.Enums;
using Pottencial.Tiago.Payment.Api.Data;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda
{
    public class CreateOrderService : ICreateOrderService
    {
        private ISellRepository repository { get; set; }
        private ISellerRepository sellerRepository { get; set; }
        private IProductRepository productRepository { get; set; }
        private IItemRepository itemRepository { get; set; }
        public CreateOrderService(ISellRepository repository, ISellerRepository sellerRepository, IProductRepository productRepository, IItemRepository itemRepository)
        {
            this.repository = repository;
            this.sellerRepository = sellerRepository;
            this.productRepository = productRepository;
            this.itemRepository = itemRepository;
        }



        public ResponseModel CreateOrder(CreateOrderRequestModel createOrderRequestModel)
        {            
            List<ProductSell> productSells = new();
            createOrderRequestModel.Product.ToList().ForEach(item =>
            {
                var foundProd = productRepository.GetById(item.Id);
                foundProd.Quantity = item.Quantity;
                productSells.Add(new ProductSell()
                {
                    ProductId = item.Id,
                    SellId = createOrderRequestModel.SellerId,
                    Product = foundProd
                });
            });

            Sell sell = new();

            sell.ProductSells = productSells;
            
            if(sellerRepository.GetById(createOrderRequestModel.SellerId) == null)
            {
                return GenericResponses.NotFound("Vendedor não encontrado.");
            }

            sell.Seller = sellerRepository.GetById(createOrderRequestModel.SellerId);
            sell.Total = sell.ProductSells.GetTotalPrice();
            sell.Date = DateTime.Now;
            sell.Status = Status.AguardandoPagamento;

            var res = this.repository.Add(sell);

            return res.Created();
        }
    }
}
