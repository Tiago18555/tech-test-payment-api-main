using AutoFixture;
using Moq;
using Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda;
using Pottencial.Tiago.Payment.Api.CrossCutting.Validations;
using Pottencial.Tiago.Payment.Api.Models;
using Pottencial.Tiago.Payment.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Pottencial.Tiago.Payment.Api.Application.UseCases.RegistrarVenda.CreateOrderRequestModel;

namespace Pottencial.Tiago.Payment.Api.Application.UseCases.AtualizarVenda
{
    public class CreateOrderTest
    {
        private readonly Mock<ISellRepository> _mockSell;
        private readonly Mock<IProductRepository> _mockProducts;
        private readonly Mock<ISellerRepository> _mockSeller;
        private readonly Mock<IItemRepository> _mockItems;

        private readonly CreateOrderService testTarget;

        public CreateOrderTest()
        {
            _mockSell = new Mock<ISellRepository>();
            _mockProducts = new Mock<IProductRepository>();
            _mockSeller = new Mock<ISellerRepository>();
            _mockItems = new Mock<IItemRepository>();

            testTarget = new CreateOrderService(_mockSell.Object, _mockSeller.Object, _mockProducts.Object, _mockItems.Object);
        }


        [Fact(DisplayName = "Not Empty List Annotation Should Return False If Input List Is Empty")]
        public void NotEmptyListAnnotationShouldReturnFalseIfInputListIsEmpty()
        {
            List<ProductSellRequestModel> products = new();

            Assert.False(new NotEmptyList().IsValid(products));
        }

        [Fact(DisplayName = "Not Empty List Validator Should Return True If Input List Is Not Empty")]
        public void NotEmptyListValidatorShouldReturnTrueIfInputListIsNotEmpty()
        {
            List<ProductSellRequestModel> products = new();
            products.Add(new Fixture().Build<ProductSellRequestModel>().Create());

            Assert.True(new NotEmptyList().IsValid(products));
        }

        [Theory(DisplayName = "Cpf Validator should validate the cpf input")]
        [InlineData("063.305.980-37", true)]
        [InlineData("555.555.555-56", false)]
        [InlineData("774.889.110-91", true)]
        [InlineData("666.666.666-67", false)]
        public void CpfValidatorShouldValidateTheCpfInput(string cpf, bool expected)
        {
            Assert.Equal(expected, new Cpf().IsValid(cpf));
        }

        [Fact(DisplayName = "GetTotalPrice should make the sum correctly")]
        public void GetTotalPriceShouldMakeTheSumCorrectly()
        {
            List <ProductSell> input = new();
            input.Add(new ProductSell { Product = new Product { Price = 60.00M, Quantity = 5 }});
            input.Add(new ProductSell { Product = new Product { Price = 90.00M, Quantity = 2 }});
            input.Add(new ProductSell { Product = new Product { Price = 45.00M, Quantity = 6 }});
            input.Add(new ProductSell { Product = new Product { Price = 42.00M, Quantity = 1 }});
            input.Add(new ProductSell { Product = new Product { Price = 10.00M, Quantity = 1 }});

            var expected = 802.00M;

            Assert.Equal(expected, input.GetTotalPrice());
        }

        [Fact(DisplayName = "GetTotalPrice should throw an exception if Product.Quantity equals less than one")]
        public void GetTotalPriceShouldThrowAnErrorIfProductQuantityEqualsLessThanOne()
        {
            List<ProductSell> input = new();
            input.Add(new ProductSell { Product = new Product { Price = 60.00M, Quantity = 0 } });

            Assert.Throws<Exception>(() => input.GetTotalPrice());
        }
    }
}
