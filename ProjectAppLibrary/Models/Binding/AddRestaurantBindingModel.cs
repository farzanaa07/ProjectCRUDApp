using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAppLibrary.Models.Binding
{
    public class AddRestaurantBindingModel
    {
         
        public string Name { get; set; }
        public string Location { get; set; }
        public string NameofDish { get; set; }
        public Boolean Delivery { get; set; }
        public string ratings { get; set; }
        public int FoodID { get; set; }
        public string PictureURL { get; set; }
    }
}
