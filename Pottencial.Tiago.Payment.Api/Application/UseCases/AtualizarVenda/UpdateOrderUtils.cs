using Pottencial.Tiago.Payment.Api.CrossCutting.Enums;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda
{
    public static class UpdateOrderUtils
    {
        /// <summary>
        /// Verifica se é permitido a troca da propriedade "Status", de acordo com a regra de negócio
        /// </summary>
        /// <param name="status">Status atual</param>
        /// <param name="newStatus">Novo Status</param>
        /// <returns></returns>
        public static bool IsAllowed(this Status status, Status newStatus)
        {
            if (status == Status.AguardandoPagamento)
            {
                return
                    newStatus == Status.PagamentoAprovado ||
                    newStatus == Status.Cancelada;
            }
            else if (status == Status.PagamentoAprovado)
            {
                return
                    newStatus == Status.EnviadoParaTransportadora ||
                    newStatus == Status.Cancelada;
            }
            else if (status == Status.EnviadoParaTransportadora)
            {
                return
                    newStatus == Status.Entregue;
            }
            else return false;
        }

        public static string StatusToString(this Status s)
        {
            return s switch
            {
                Status.AguardandoPagamento => "Aguardando pagamento",
                Status.Cancelada => "Cancelada",
                Status.PagamentoAprovado => "Pagamento aprovado",
                Status.Entregue => "Entregue",
                Status.EnviadoParaTransportadora => "Enviado para transportadora",
                _ => "Inválido",
            };
        }
    }
}
