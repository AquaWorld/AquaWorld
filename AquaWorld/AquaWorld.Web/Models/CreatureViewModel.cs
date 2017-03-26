using AquaWorld.Data.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaWorld.Web.Models
{
    public class CreatureViewModel
    {
        public CreatureViewModel(Creature creature)
        {
            if (creature != null)
            {
                this.Id = creature.Id;
                this.Name = creature.Name;
                this.Description = creature.Description;
                this.Category = creature.Category;
                this.AvailableCount = creature.AvailableCount;
                this.ImageUrl = creature.ImageUrl;
                this.Price = creature.Price;
                this.OrderedItemsCount = creature.OrderedItemsCount;
                this.Orders = new List<Order>(creature.Orders);
            }
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