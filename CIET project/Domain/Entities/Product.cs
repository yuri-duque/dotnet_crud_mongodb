using Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Products")] // configure collection name
    public class Product : Domain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EStatus Status { get; set; }

        public Product(string id, string name, string description, decimal price, EStatus status, DateTime dateCreated, DateTime? dateUpdated) : base(id, dateCreated, dateUpdated)
        {
            Name = name;
            Description = description;
            Price = price;
            Status = status;
        }

        public Product(string name, string description, decimal price) : base()
        {
            Name = name;
            Description = description;
            Price = price;
            Status = EStatus.active;
        }

        public void SetUpdate(Product product)
        {
            Id = product.Id;
            DateCreated = product.DateCreated;
            DateUpdate = DateTime.Now;
        }
    }
}
