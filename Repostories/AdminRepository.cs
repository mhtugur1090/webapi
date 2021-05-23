using SahinKereste.DbContext;
using SahinKereste.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Repostories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _dataContext ;
        
        public async Task<AdminLoginDTO> UpdateUser(int id)
        {
           
            return null;
        }
    }
}
