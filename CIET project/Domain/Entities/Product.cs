using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Products")]
    public class Product : Domain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EStatus Status { get; set; }

    }
}
