using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary.Testing.InterfaceTesting
{

    public interface IDetailFoods
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public string Cuisine { get; set; }
        public string Description { get; set; }

    }

}
