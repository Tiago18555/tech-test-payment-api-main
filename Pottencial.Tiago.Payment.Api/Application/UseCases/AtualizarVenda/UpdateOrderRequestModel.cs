using Pottencial.Tiago.Payment.Api.CrossCutting.Enums;
using Pottencial.Tiago.Payment.Api.Models;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda
{
    public class UpdateOrderRequestModel
    {
        public long Id { get; set; }
        public Status Status { get; set; }

    }
}
