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
    public class Update_ProductServiceTest
    {
        private readonly IProductService _productService;

        public Update_ProductServiceTest(BaseFixture fixture)
        {
            _productService = fixture.GetService<IProductService>();
        }

        [Theory]
        [InlineData("product01", "description01", 50F, "newProduct1")]
        [InlineData("product02", "description02", 50.5, "newProduct2")]
        public async Task Update_to_defaultProduct(string name, string description, decimal price, string newName)
        {
            /// Arrange
            var product = new Product(name, description, price);
            product = await _productService.Insert(product);
            product.SetName(newName);

            /// Act
            await _productService.Update(product.Id, product);

            /// Assert
            product = await _productService.GetById(product.Id);
            Assert.NotNull(product);

            Assert.Equal(newName, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(price, product.Price);
            Assert.Equal(EStatus.active, product.Status);
            Assert.True(DateTime.Now > product.DateCreated);
            Assert.True(DateTime.Now > product.DateUpdate);

            /// Delete
            await _productService.Delete(product.Id);
        }
    }
}
