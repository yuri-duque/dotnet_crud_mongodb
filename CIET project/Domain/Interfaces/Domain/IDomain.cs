using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Domain.Interfaces
{
    public interface IDomain
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; }
        public DateTime DateCreated { get; }

        public DateTime? DateUpdate { get;}
    }
}
