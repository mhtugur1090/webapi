using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.DTOs
{
    public class UserForRegisterDTO
    {
        [Required(ErrorMessage ="İsim alanı zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim alanı zorunludur")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "E-mail alanı zorunludur")]
        public string Email { get; set; }
        [Required(ErrorMessage = "kullanici ismi alanı zorunludur")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedTime { get; set; }


    }
}
