using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVendedor
{
    public class RegisterSellerService : IRegisterSellerService
    {
        private ISellerRepository sellerRepository { get; set; }
        public RegisterSellerService(ISellerRepository sellerRepository) =>        
            this.sellerRepository = sellerRepository;

        public async Task<ResponseModel> Add(RegisterSellerRequestModel registerSellerRequestModel)
        {
            var seller = registerSellerRequestModel.MapObjectTo(new Seller());

            
            var HasAnyDuplicates = (await this.sellerRepository.GetAll()).Any(x => x.Name == seller.Name);

            if (HasAnyDuplicates) { return GenericResponses.Forbidden("Já existe um vendedor cadastrado com esse nome"); }

            var res = (await this.sellerRepository.Add(seller)).Created();

            return res;
        }

        public async Task<ResponseModel> ListSellers() =>
           (await sellerRepository.GetAll()).Ok();

        public async Task<ResponseModel> Populate()
        {
            var hasCalledAlready = (await sellerRepository.GetAll()).Any(x => x.Cpf == "562.522.134 - 03");

            if (hasCalledAlready) { return GenericResponses.Forbidden("Só é permitido uma request nesse end-point"); }

            List<Seller> prod = new();
            prod.Add(new Seller() { Name = "Alícia Eliane da Silva", Cpf = "562.522.134 - 03", Email = "alicia_eliane_dasilva@scuderiagwr.com.br", PhoneNumber = "(27) 2876-1228" });
            prod.Add(new Seller() { Name = "Valentina Ana Moura", Cpf = "996.477.044-88", Email = "valentina_ana_moura@vieiradarocha.adv.br", PhoneNumber = "(86) 2529-9774" });
            prod.Add(new Seller() { Name = "Osvaldo Miguel Campos", Cpf = "894.328.378-40", Email = "osvaldo_miguel_campos@wredenborg.se", PhoneNumber = "(48) 3768-3440" });
            prod.Add(new Seller() { Name = "Lavínia Gabrielly Rocha", Cpf = "268.785.538-30", Email = "lavinia-rocha97@achievecidadenova.com.br", PhoneNumber = "(66) 3596-5818" });
            prod.Add(new Seller() { Name = "Lorenzo Miguel Daniel dos Santos", Cpf = "318.798.798-24", Email = "lorenzo-dossantos81@seal.com.br", PhoneNumber = "(88) 3508-8759" });


            var res = (await sellerRepository.AddRange(prod.ToArray())).Created();

            return res;
        }
    }

}
