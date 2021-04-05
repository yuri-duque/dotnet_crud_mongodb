using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetAll();
        Task<Product> GetById(string id);
        Task<string> Insert(Product product);
        Task<string> Update(string id, Product product);
        Task Delete(string id);
    }
}
