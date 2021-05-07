﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models
{
   public class Restaurant
    {
        public int ID { get; set; }
        public int FoodID { get; set; }
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
       public string NameofDish { get; set; } public string PictureURL { get; set; }
        public Boolean Delivery { get; set; }
        public string ratings { get; set; }
        public DateTime CreatedAt { get; set; }
        //public virtual Recipe Recipe { get; set; }
        //public virtual Food Food { get; set; }
    }

}
