using Aplication.Helpers;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<Product>> GetAll()
        {
            var products = await _productRepository.GetAll();

            return products;
        }

        public async Task<Product> GetById(string idProduct)
        {
            var product = await _productRepository.GetById(idProduct);

            if (product is null)
                throw new NotFoundException("Product not found!");

            return product;
        }

        public async Task<Product> Insert(Product product)
        {
            //if (!product.Validate())
            //    throw new ErrorException(product.GetErrosValidationResult()); // return errors validation

            product.Id = await _productRepository.Insert(product);

            return product;
        }

        public async Task<Product> Update(string id, Product product)
        {
            var baseProduct = await GetById(id);

            product.SetUpdate(baseProduct);

            //if (!product.Validate())
            //    throw new ErrorException(product.GetErrosValidationResult()); // return errors validation

            await _productRepository.Update(id, product);

            return product;
        }

        public async Task<Product> Delete(string id)
        {
            var product = await GetById(id);

            await _productRepository.Delete(id);

            return product;
        }
    }
}
