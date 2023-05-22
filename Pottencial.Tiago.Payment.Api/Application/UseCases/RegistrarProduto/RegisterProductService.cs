using Microsoft.AspNetCore.DataProtection.Repositories;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda;
using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.CrossCutting.Enums;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto
{
    public class RegisterProductService : IRegisterProductService
    {
        private IProductRepository productRepository { get; set; }
        private IRegisterItemService registerItemService { get; set; }      
        public RegisterProductService(IProductRepository productRepository, IRegisterItemService registerItemService)
        {
            this.productRepository = productRepository;
            this.registerItemService = registerItemService;
        }


        public async Task<ResponseModel> Add(RegisterProductRequestModel registerProductRequestModel)
        {
            var prod = registerProductRequestModel.MapObjectTo(new Product());

            var HasAnyDuplicates = (await this.productRepository.GetAll(x => x.MapObjectTo(new RegisterProductResponseModel()))).Any(x => x.Name == prod.Name);

            if (HasAnyDuplicates) { return GenericResponses.Forbidden("Já existe um produto cadastrado com esse nome"); }

            var res = (await this.productRepository.Add(prod)).Created();

            return res;
        }

        public async Task<ResponseModel> Populate()
        {
            var hasCalledAlready = (await productRepository.GetAll(x => x.MapObjectTo(new RegisterProductResponseModel()))).Any(x => x.Name == "Uno Minimalista");

            if(hasCalledAlready) { return GenericResponses.Forbidden("Só é permitido uma request nesse end-point"); }

            List<Product> prod = new();
            prod.Add(new Product() { Name = "Uno Minimalista", Price = 59.99m });
            prod.Add(new Product() { Name = "Kit ferramentas", Price = 65.59m });
            prod.Add(new Product() { Name = "Multímetro digital", Price = 225.59m });
            prod.Add(new Product() { Name = "Placa de vídeo AMD radeon 6600xt Sapphire", Price = 1699.99m });
            prod.Add(new Product() { Name = "Echo Dot 3a geração", Price = 349.99m });

            var res = this.productRepository.AddRange(x => x.MapObjectTo(new RegisterProductResponseModel()), prod.ToArray());

            //var items = await registerItemService.Populate();

            return res.Created();

            //return new DataContainer(res, items.Data).Created();
        }

        public async Task<ResponseModel> ListProducts() =>
            (await productRepository.GetAll(x => x.MapObjectTo(new RegisterProductResponseModel()))).Ok();
    }
}
