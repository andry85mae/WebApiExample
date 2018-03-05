using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWebApi
{
    public class Phone
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Colour { get; set; }

        public decimal Price { get; set; }

        public List<string> Images { get; set; }
        
        public int Quantity { get; set; }

        public bool published { get; set; }
    }
}
