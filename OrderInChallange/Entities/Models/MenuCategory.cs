using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class MenuCategory
    {
        //[ForeignKey("Restaurant")]
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
