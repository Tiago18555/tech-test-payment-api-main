using Moq;
using Pottencial.Tiago.Payment.Api.Application.UseCases.BuscarVenda;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;
using Pottencial.Tiago.Payment.Api.Repositories.Impl;
using System.Collections.Generic;
using Xunit;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda
{
    public class FindOrderTest
    {
        private readonly Mock<ISellRepository> _mockSell;
        private readonly Mock<IProductRepository> _mockProducts;
        private readonly Mock<ISellerRepository> _mockSeller;
        private List<Product> productList = new();

        private readonly FindOrderService testTarget;

        public FindOrderTest()
        {
            _mockSell = new Mock<ISellRepository>();
            _mockProducts = new Mock<IProductRepository>();
            _mockSeller = new Mock<ISellerRepository>();

            testTarget = new FindOrderService(_mockSell.Object, _mockSeller.Object, _mockProducts.Object);           
        }    

        [Theory(DisplayName = "Find order should return code 400 if id is null")]
        [InlineData(0)]
        public void FindOrderShouldReturnCode400IfIdIsNull(long id)
        {
            var res = testTarget.FindOrder(id);

            var expected = 400;

            Assert.Equal(expected, res.StatusCode);
        }

        [Theory(DisplayName = "Find order should return code 404 if id doesn't exists")]
        [InlineData(50)]
        public void FindOrderShouldReturnCode404IfIdDoesntExists(long id)
        {
            var res = testTarget.FindOrder(id);

            var expected = 404;

            Assert.Equal(expected, res.StatusCode);
        }
    }
}
