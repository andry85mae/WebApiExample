using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExample.Models
{
    public class Review
    {
        public string Author { get; set; }
        public int Vote { get; set; }
        public string Text { get; set; }
    }
}