using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Repostories
{
    public interface IContactRepository
    {
        Task<Contact> GetContact();
        Task<Contact> UpdateContact(int id, Contact c);
        Task<Contact> PostContact(Contact con);
    }
}
