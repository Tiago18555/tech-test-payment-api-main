using System.ComponentModel.DataAnnotations;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarProduto
{
    public class RegisterItemRequestModel
    {
        [Required(ErrorMessage = "Campo nome não pode estar nulo ou vazio")]
        public long ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
