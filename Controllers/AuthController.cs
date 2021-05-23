using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SahinKereste.DTOs;
using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SahinKereste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IConfiguration _configuration;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAdmin(AdminLoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user==null)
            {
                return BadRequest(new { message="Bilgiler yanlış"});
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user,model.Password,false);

            if (result.Succeeded)
            {
                return Ok(new { token = GenerateJwtToken(user) });
            }
            else { return Unauthorized(); }

        }

        public async Task<bool> KullaniciVarMi(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return false;
            }
            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // appsetting.json daki secret keyini byte şeklinde almamız gerekiyor.
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);

            //Tokenımızı tanımlayalım.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    // Token bilgisi içerisinde olmasını istediğimiz kısımları ekleyelim.
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1), // Token'ın geçerlilik süresini belirledik.
                SigningCredentials = new SigningCredentials(//Burada Token'ı şifreliyeceğiz.Hangi algoritmayı ve şifrelerken kullanacağımız key bilgisini burada vercez.
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);// Bu dönen sonuç Byte cinsinden

            return tokenHandler.WriteToken(token); // bu token'ı string formatına çevirir.
        }


    }
}
