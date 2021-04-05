using Domain.Entities;
using Domain.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<IList<Product>> GetAll()
        {
            try
            {
                var products = await DbSet.AsQueryable().ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Product> GetById(string id)
        {
            try
            {
                var product = await DbSet.AsQueryable()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string> Insert(Product product)
        {
            try
            {
                await InsertOneAsync(product);

                return product.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string> Update(string id, Product product)
        {
            try
            {
                await UpdateAsync(id, product);

                return product.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                await RemoveAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
