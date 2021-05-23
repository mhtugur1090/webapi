using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SahinKereste.DbContext;
using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.TestData
{
    public class SeedDatabase
    {
        public static async Task Seed(UserManager<User> userManager)
        {
            if (!userManager.Users.Any()) // Kullanıcı tablosunda herhangi bir bilgi varsa bize true gelir
            {
                var users = File.ReadAllText("TestData/customers.json");

                var listOfusers = JsonConvert.DeserializeObject<List<User>>(users);

                foreach (var user in listOfusers)
                {
                    var res = await userManager.CreateAsync(user,"reco123");
                }

            }


        }
    }
}
