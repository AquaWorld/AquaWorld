using AquaWorld.Data.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaWorld.Data.Models
{
    public class Creature : ICreature
    {
        public Creature()
        {
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Preview")]
        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        [DisplayName("Available Count")]
        public int AvailableCount { get; set; }

        public int OrderedItemsCount { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
