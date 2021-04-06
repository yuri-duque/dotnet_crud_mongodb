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
    public class Insert_ProductServiceTest
    {
        private readonly IProductService _productService;

        public Insert_ProductServiceTest(BaseFixture fixture)
        {
            _productService = fixture.GetService<IProductService>();
        }

        [Theory]
        [InlineData("product01", "description01", 50F)]
        [InlineData("product01", "description01", 50.5)]
        public async Task Insert_to_defaultProduct(string name, string description, decimal price)
        {
            /// Arrange
            var product = new Product(name, description, price);

            /// Act
            product = await _productService.Insert(product);

            /// Assert
            Assert.NotNull(product.Id);

            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(price, product.Price);
            Assert.Equal(EStatus.active, product.Status);
            Assert.True(DateTime.Now > product.DateCreated);
            Assert.Null(product.DateUpdate);

            product = await _productService.GetById(product.Id);
            Assert.NotNull(product);

            /// Delete
            await _productService.Delete(product.Id);
        }
    }
}
