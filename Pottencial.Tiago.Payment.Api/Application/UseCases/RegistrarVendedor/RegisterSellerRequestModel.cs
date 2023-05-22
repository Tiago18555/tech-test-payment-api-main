using Pottencial.Tiago.Payment.Api.CrossCutting.Validations;
using System.ComponentModel.DataAnnotations;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVendedor
{
    public class RegisterSellerRequestModel
    {
        [MinLength(3)]
        public string Name { get; set; }

        [Cpf]
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
