using SahinKereste.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahinKereste.Repostories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetProducts();
        Task<Product> AddProduct(Product p);
        Task<Product> UpdateProduct(int id, Product p);
        Task<Product> DeleteProduct(int id);
    }
}
