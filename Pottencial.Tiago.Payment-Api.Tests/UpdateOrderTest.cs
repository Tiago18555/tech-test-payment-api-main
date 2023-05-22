using Moq;
using Pottencial.Tiago.Payment.Api.CrossCutting.Enums;
using Pottencial.Tiago.Payment.Api.Repositories;
using Xunit;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda
{
    public class UpdateOrderTest
    {
        private readonly Mock<ISellRepository> _mockSell;
        private readonly Mock<IProductRepository> _mockProducts;
        private readonly Mock<ISellerRepository> _mockSeller;

        private readonly UpdateOrderService testTarget;

        public UpdateOrderTest()
        {
            _mockSell = new Mock<ISellRepository>();
            _mockProducts = new Mock<IProductRepository>();
            _mockSeller = new Mock<ISellerRepository>();

            testTarget = new UpdateOrderService(_mockSell.Object);
        }

        [Theory(DisplayName = "IsAllowed Method Works Correctly")]

        [InlineData(Status.AguardandoPagamento, Status.PagamentoAprovado, true)]
        [InlineData(Status.AguardandoPagamento, Status.Cancelada, true)]
        [InlineData(Status.AguardandoPagamento, Status.EnviadoParaTransportadora, false)]
        [InlineData(Status.AguardandoPagamento, Status.Entregue, false)]
        [InlineData(Status.AguardandoPagamento, Status.AguardandoPagamento, false)]

        [InlineData(Status.PagamentoAprovado, Status.EnviadoParaTransportadora, true)]
        [InlineData(Status.PagamentoAprovado, Status.Cancelada, true)]
        [InlineData(Status.PagamentoAprovado, Status.PagamentoAprovado, false)]
        [InlineData(Status.PagamentoAprovado, Status.Entregue, false)]
        [InlineData(Status.PagamentoAprovado, Status.AguardandoPagamento, false)]

        [InlineData(Status.EnviadoParaTransportadora, Status.Entregue, true)]
        [InlineData(Status.EnviadoParaTransportadora, Status.EnviadoParaTransportadora, false)]
        [InlineData(Status.EnviadoParaTransportadora, Status.Cancelada, false)]
        [InlineData(Status.EnviadoParaTransportadora, Status.PagamentoAprovado, false)]
        [InlineData(Status.EnviadoParaTransportadora, Status.AguardandoPagamento, false)]
        public void IsAllowedMethodWorksCorrectly(Status current, Status next, bool expected)
        {
            Assert.Equal(expected, current.IsAllowed(next));
        }
    }
}
