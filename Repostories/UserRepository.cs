using Microsoft.EntityFrameworkCore;
using SahinKereste.DbContext;
using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Repostories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<User> GetAdmin()
        {
            var admin = await _context.Users.FirstOrDefaultAsync();
            return admin;
        }
    }
}
