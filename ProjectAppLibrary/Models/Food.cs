using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public string Cuisine { get; set; }
        public string Description { get; set; }
     public DateTime CreatedAt { get; set; }


        //setting relationships 
        public virtual List<Restaurant> Restaurants { get; set; } 
        public virtual List<Recipe> Recipes { get; set; }
    }
}
