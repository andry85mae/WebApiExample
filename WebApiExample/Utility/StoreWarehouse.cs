using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExample.Models;

namespace WebApiExample.Utility
{
    public class StoreWarehouse
    {
        public static List<Phone> Phones { get; set; }

        static StoreWarehouse()
        {
            Phones = new List<Phone>();

            Phones.Add(new Phone
            {
                Colour = "White",
                Description = "Fast just got faster with Nexus S.",
                Name = "Nexus S",
                Price = 700
            });

            Phones.Add(new Phone
            {
                Colour = "Black",
                Description = "The Next, Next Generation phone.",
                Name = "MOTOROLA XOOM™",
                Price = 150
            });

            Phones.Add(new Phone
            {
                Colour = "Gray",
                Description = "Iphone 7, something special",
                Name = "IPhone 7",
                Price = 800

            });

            Phones.Add(new Phone
            {
                Colour = "Gray",
                Description = "Free your smartphone",
                Name = "Galaxy S8",
                Price = 740

            });
        }
    }
}