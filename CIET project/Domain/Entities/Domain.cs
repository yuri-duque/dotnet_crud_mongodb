using Domain.Interfaces;
using System;

namespace Domain.Entities
{
    public class Domain : IDomain
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; protected set; }

        public Domain(string id, DateTime dateCreated, DateTime? dateUpdate)
        {
            Id = id;
            DateCreated = dateCreated;
            DateUpdate = dateUpdate;
        }

        public Domain()
        {
            DateCreated = DateTime.Now;
        }
    }
}
