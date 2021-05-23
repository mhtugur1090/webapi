using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SahinKereste.Entity;
using SahinKereste.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactController
    {
        private IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<Contact> GetContact() 
        {
            return await _repo.GetContact();
        }


        //Deneme------------------------------------------------------

        [HttpPost]
        public async Task<Contact> UpdateContact(Contact c)
        {

            if (c.Id == 0)
            {
                return await _repo.PostContact(c);
            }

            return await _repo.UpdateContact(c.Id, c);

        }

        //-------------------------------------------------------------

        [HttpPut]
        [Route("{id}")]
        public async Task<Contact> UpdateContact(int id,Contact c) 
        {

            if (id == 0) 
            {
              return await _repo.PostContact(c);
            }

            return await _repo.UpdateContact(id,c);
        
        }

    }
}
