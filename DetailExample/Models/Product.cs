using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetailExample.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public bool InStorage { get; set; }
        public string Image { get; set; }
    }
}