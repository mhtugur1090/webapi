using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool Active { get; set; }
        public string thickness { get; set; }
        public string width { get; set; }
        public string length { get; set; }
        public string usage { get; set; }
        public Image image { get; set; }
    }
}
