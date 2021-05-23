using Microsoft.EntityFrameworkCore;
using SahinKereste.DbContext;
using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Repostories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            this._context = context;
        }

        
        public async Task<Product> GetProduct(int id)
        {
            var products = await _context.Products.Include(im => im.image).FirstOrDefaultAsync(i=>i.Id==id);

            return products;

        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.Include(im=>im.image).ToListAsync();
            return products;
        }

        public async Task<Product> UpdateProduct(int id, Product p)
        {

            if (id != p.Id)
            {
                return null;
            }

            var _p = await _context.Products.FindAsync(id);

            if (!_p.Equals(null))
            {
                _p.Id = p.Id;
                _p.Name = p.Name;
                _p.Description = p.Description;
                _p.Category = p.Category;
                _p.Active = p.Active;
                _p.thickness = p.thickness;
                _p.width = p.width;
                _p.length = p.length;
                _p.usage = p.usage;
                _p.image = p.image;
                _context.Products.Update(_p);
                await _context.SaveChangesAsync();
            }

            return _p;
        }

        public async Task<Product> AddProduct(Product p)
        {
            _context.Products.Add(p);
            var result = await _context.SaveChangesAsync();
            return p;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var p = await _context.Products.FindAsync(id);

            if (p == null)
                return null;

            _context.Products.Remove(p);
            await _context.SaveChangesAsync();

            return p;
        }
    }
}
