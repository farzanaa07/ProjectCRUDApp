using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.Testing.InterfaceTesting

{
   public interface IDeleteRestaurant
    { 
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
       public string NameofDish { get; set; } public string PictureURL { get; set; }
        public Boolean Delivery { get; set; }
        public string ratings { get; set; }
    }

   

}
