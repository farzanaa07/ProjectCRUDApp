using System;

namespace TestingLibrary.Testing.InterfaceTesting
{
    public interface IDeleteFood
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string PictureURL { get; set; }
            public string Cuisine { get; set; }
            public string Description { get; set; }

        }
    }


