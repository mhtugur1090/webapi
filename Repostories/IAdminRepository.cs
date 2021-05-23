using SahinKereste.DTOs;
using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Repostories
{
    public interface IAdminRepository
    {
        Task<AdminLoginDTO> UpdateUser(int id);
    }
}
