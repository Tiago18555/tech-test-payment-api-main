using Pottencial.Tiago.Payment.Api.CrossCutting.Validations;
using System.ComponentModel.DataAnnotations;

namespace Pottencial.Tiago.Payment.Api.Models
{
    public class Seller
    {
        [Key]
        public long Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [Cpf]
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
