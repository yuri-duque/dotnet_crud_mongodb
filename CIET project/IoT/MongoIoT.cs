using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Repository.Context;

namespace IoT
{
    public static class MongoIoT
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            // setando a data para o timezone do Brasil
            BsonSerializer.RegisterSerializer(DateTimeSerializer.LocalInstance);

            services.AddSingleton<IMongoContext, MongoContext>();

            return services;
        }
    }
}
