using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Repository.Context;

namespace Api.IoT
{
    public static class MongoIoT
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            try // adicionado try pois não é possovel registrar um serializador para o mesmo type mais de uma vez
            {
                // setando a data para o timezone do Brasil
                BsonSerializer.RegisterSerializer(DateTimeSerializer.LocalInstance);
            }
            catch { }

            services.AddSingleton<IMongoContext, MongoContext>();

            return services;
        }
    }
}
