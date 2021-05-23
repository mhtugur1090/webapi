using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Entity
{
    public class Address
    {
        public Address()
        {
            this.address = "";
        }

        public int Id { get; set; }
        public string address { get; set; }

        public int ContactId { get; set; }
        public Contact contact { get; set; }
    }
}
