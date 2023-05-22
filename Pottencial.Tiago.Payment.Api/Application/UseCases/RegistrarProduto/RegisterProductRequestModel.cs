using System.ComponentModel.DataAnnotations;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto
{
    public class RegisterProductRequestModel
    {
        [Required(ErrorMessage = "Campo nome não pode estar nulo ou vazio")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo Preço não pode estar nulo")]
        public decimal Price { get; set; }

    }
}
