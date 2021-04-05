using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace Repository.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IConfiguration _configuration;

        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }

        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;

            ConfigureMongo();
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null) return;

            MongoClient = new MongoClient(_configuration["Mongo:ConnectionString"]);
            Database = MongoClient.GetDatabase(_configuration["Mongo:NomeBanco"]);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
