using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.DTOs
{
    public class AdminChangePassDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string newPassword { get; set; }
    }
}
