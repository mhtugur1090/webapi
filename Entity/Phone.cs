using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Entity
{
    public class Phone
    {
        public Phone()
        {
            this.phone = "";
        }
        public int Id { get; set; }
        public string phone { get; set; }

        public int ContactId { get; set; }
        public Contact contact { get; set; }
    }
}
