using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TDocument> : IDisposable where TDocument : IDomain
    {
        Task InsertOneAsync(TDocument obj);
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task UpdateAsync(string id, TDocument obj);
        Task RemoveAsync(string id);
    }
}
