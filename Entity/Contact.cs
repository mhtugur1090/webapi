using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Entity
{
    public class Contact
    {

        public Contact()
        {
            this.Id = 0;
            this.addresses = new List<Address>();
            this.phones = new List<Phone>();
            this.Name = "";
            this.Email = "";
            this.Instagram = "";
            this.Facebook = "";
            this.Twitter = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }

        public List<Phone> phones { get; set; }
        public List<Address> addresses { get; set; }

    }
}
