using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SahinKereste.DbContext;
using SahinKereste.DTOs;
using SahinKereste.Entity;
using SahinKereste.Repostories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SahinKereste.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
       
        private IProductRepository _repo;
        public ProductController(DataContext contex,IProductRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Product>> GetProducts() 
        {


            return await _repo.GetProducts();


        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<Product> GetProduct(int id) 
        {

            return await _repo.GetProduct(id);

        }

        [HttpPost("add")]
        public async Task<Product> AddProduct(Product p) 
        {
            
            return await _repo.AddProduct(p);
        }


        //deneme-------------------------------------------------------

        [HttpPost("update")]
        public async Task<Product> UpdateProduct(Product p)
        {

            return await _repo.UpdateProduct(p.Id,p);

        }

        [HttpPost("delete")]
        public async Task<Product> DeleteProduct(Product p)
        {

            return await _repo.DeleteProduct(p.Id);

        }


        //------------------------------------------------------------

    }
}
