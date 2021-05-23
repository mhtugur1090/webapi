using Microsoft.EntityFrameworkCore;
using SahinKereste.DbContext;
using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Repostories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;
        public ContactRepository(DataContext context)
        {
            this._context = context;
        }


        public async Task<Contact> GetContact()
        {
            var _contact = await this._context.Contacts.Include(phone => phone.phones).Include(address=>address.addresses).FirstOrDefaultAsync();
            if (_contact == null) 
            {
                var _con = new Contact();
                return _con;
            }
            return _contact; 
        }


        public async Task<Contact> PostContact(Contact con) 
        {

            this._context.Add(con);
            await this._context.SaveChangesAsync();
            return con;

        }

        public async Task<Contact> UpdateContact(int id, Contact c)
        {
            if (id != c.Id) 
            {
                return null;
            }

            var _c = await _context.Contacts.FindAsync(id);

            if (!_c.Equals(null)) 
            {
                await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Phones");
                await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Addreses");
                _c.Id = c.Id;
                _c.Name = c.Name;
                _c.phones = c.phones;
                _c.addresses = c.addresses;
                _c.Email = c.Email;
                _c.Instagram = c.Instagram;
                _c.Facebook = c.Facebook;
                _c.Twitter = c.Twitter;
                _context.Contacts.Update(_c);
                await _context.SaveChangesAsync();

            }

            

            return _c;

        }
    }
}
