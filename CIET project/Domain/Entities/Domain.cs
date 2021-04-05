using Domain.Interfaces;
using System;

namespace Domain.Entities
{
    public class Domain : IDomain
    {
        public string Id { get; }
        public DateTime DateCreated { get; }
        public DateTime? DateUpdate { get; protected set; }
    }
}
