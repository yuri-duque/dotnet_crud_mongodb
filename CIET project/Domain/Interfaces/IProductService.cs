using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        Task<IList<Product>> GetAll();
        Task<Product> GetById(string idProduct);
        Task<Product> Insert(Product product);
        Task<Product> Update(string id, Product product);
        Task<Product> Delete(string id);
    }
}
