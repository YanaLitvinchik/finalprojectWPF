using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPF
{
   public class Alcohol
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }

        public static ObservableCollection<Alcohol> GetAll()
        {
            return new ObservableCollection<Alcohol>
            {
                new Alcohol { Image = "../Image/default.jpeg",  Name = "Gibson's",Type = "Gin", Manufacturer ="London", Year = 1990},
                new Alcohol { Image = "../Image/default.jpeg", Name = "Yana's",Type = "Bear", Manufacturer ="Kyiv",  Year = 2018},
                new Alcohol { Image = "../Image/default.jpeg", Name = "Yana's",Type = "Bear", Manufacturer ="Kyiv",  Year = 2018},
                new Alcohol { Image = "../Image/default.jpeg", Name = "Yana's",Type = "Bear", Manufacturer ="Kyiv",  Year = 2018},
                new Alcohol { Image = "../Image/default.jpeg", Name = "Yana's",Type = "Bear", Manufacturer ="Kyiv",  Year = 2018},
                new Alcohol { Image = "../Image/default.jpeg", Name = "Yana's",Type = "Bear", Manufacturer ="Kyiv",  Year = 2018}
            };
        }

    }
}
