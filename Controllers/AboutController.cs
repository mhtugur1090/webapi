using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SahinKereste.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyAllowedSpecificOrigins")]
    public class AboutController : ControllerBase
    {

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<Aboutus> GetInfoFile()
        {
            string path = "./Resources/about.txt";
            string reading = "";
            using (var sr = new StreamReader(path))
            {
                // Read the stream as a string, and write the string to the console.
                reading= await sr.ReadToEndAsync();
            }

            Aboutus ab = new Aboutus();
            ab.message = reading;

            return ab;


        }

        //Deneme --------------------------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> UpdateInfoFile(Aboutus info)
        {
            string path = "./Resources/about.txt";

            using (StreamWriter writer = new StreamWriter(path, false)) //// true to append data to the file
            {
                await writer.WriteAsync(info.message);
            }
            return Ok(info);


        }
        //----------------------------------------------------------------------------

        [HttpPut]
        public async Task<IActionResult> PutInfoFile(Aboutus info)
        {
            string path = "./Resources/about.txt";

            using ( StreamWriter writer = new StreamWriter(path, false)) //// true to append data to the file
            {
                    await writer.WriteAsync(info.message);
            }
            return Ok(info);


        }


    }
}
