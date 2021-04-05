using Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<TDocument> : IRepository<TDocument> where TDocument : IDomain
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TDocument> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
            string collectionName = GetCollectionName();
            DbSet = Context.GetCollection<TDocument>(collectionName);
        }

        public virtual async Task InsertOneAsync(TDocument obj)
        {
            await DbSet.InsertOneAsync(obj);
        }

        public virtual async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            var all = await DbSet.FindAsync(Builders<TDocument>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task UpdateAsync(string id, TDocument obj)
        {
            var filter = Builders<TDocument>.Filter.Eq(x => x.Id, id);
            await DbSet.ReplaceOneAsync(filter, obj);
        }

        public virtual async Task RemoveAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(x => x.Id, id);
            await DbSet.DeleteOneAsync(filter);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        /// <summary>
        /// Get custom collection name by "table" attribute
        /// </summary>
        /// <returns></returns>
        private string GetCollectionName()
        {
            string collumnName = typeof(TDocument).Name;

            var customAttributes = typeof(TDocument).GetCustomAttributes(typeof(TableAttribute), false);
            if (customAttributes.Any())
            {
                collumnName = (customAttributes.First() as TableAttribute).Name;
            }

            return collumnName;
        }
    }
}
