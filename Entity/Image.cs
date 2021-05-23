using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public string path { get; set; }

        public int ProductId { get; set; }
        public Product product { get; set; }
    }
}
