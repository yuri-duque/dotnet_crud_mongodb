using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Tests.Fixture;
using Xunit;

namespace Tests
{
    [Collection("Product")]
    public class GetById_ProductServiceTest
    {
        private readonly IProductService _productService;

        public GetById_ProductServiceTest(BaseFixture fixture)
        {
            _productService = fixture.GetService<IProductService>();
        }

        [Theory]
        [InlineData("product01", "description01", 50F)]
        [InlineData("product01", "description01", 50.5)]
        public async Task GetById_to_defaultProduct(string name, string description, decimal price)
        {
            /// Arrange
            var product = new Product(name, description, price);
            product = await _productService.Insert(product);

            /// Act
            product = await _productService.GetById(product.Id);

            /// Assert
            Assert.NotNull(product);

            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(price, product.Price);
            Assert.Equal(EStatus.active, product.Status);
            Assert.True(DateTime.Now > product.DateCreated);
            Assert.Null(product.DateUpdate);

            /// Delete
            await _productService.Delete(product.Id);
        }
    }
}
