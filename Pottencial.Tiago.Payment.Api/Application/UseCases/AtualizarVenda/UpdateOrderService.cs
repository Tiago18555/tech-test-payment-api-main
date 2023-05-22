using Pottencial.Tiago.Payment.Api.CrossCutting;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda
{
    public class UpdateOrderService : IUpdateOrderService
    {
        private ISellRepository repository { get; set; }
        public UpdateOrderService(ISellRepository context)
        {
            repository = context;
        }
        
        public ResponseModel UpdateStatus(UpdateOrderRequestModel updateOrderRequestModel)
        {
            if(repository.GetById(updateOrderRequestModel.Id) == null) { return GenericResponses.NotFound("Pedido não encontrado");  }

            var foundSell = repository.GetById(updateOrderRequestModel.Id);

            if (!foundSell.Status.IsAllowed(updateOrderRequestModel.Status))
            {
                return GenericResponses.Forbidden($"Não é permitido atualizar o status de {foundSell.Status.StatusToString()} para {updateOrderRequestModel.Status.StatusToString()}");
            }

            foundSell.Status = updateOrderRequestModel.Status;

            repository.Update(foundSell.MapObjectTo(new Sell()));

            return repository.GetById(foundSell.Id).Ok($"Status atualizado: {foundSell.Status.StatusToString()}.");
        }

    }
}
