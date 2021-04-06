using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;
using Tests.Fixture;
using Xunit;

namespace Tests
{
    [Collection("Product")]
    public class GetAll_ProductServiceTest
    {
        private readonly IProductService _productService;

        public GetAll_ProductServiceTest(BaseFixture fixture)
        {
            _productService = fixture.GetService<IProductService>();
        }

        [Theory]
        [InlineData("product01", "description01", 50F)]
        [InlineData("product01", "description01", 50.5)]
        public async Task GetAll_to_defaultProduct(string name, string description, decimal price)
        {
            /// Arrange
            var product1 = await _productService.Insert(new Product(name, description, price));
            var product2 = await _productService.Insert(new Product(name, description, price));

            /// Act
            var products = await _productService.GetAll();

            /// Assert
            Assert.NotNull(products);

            Assert.Contains(products, x => x.Id == product1.Id);
            Assert.Contains(products, x => x.Id == product2.Id);

            /// Delete
            await _productService.Delete(product1.Id);
            await _productService.Delete(product2.Id);
        }
    }
}
