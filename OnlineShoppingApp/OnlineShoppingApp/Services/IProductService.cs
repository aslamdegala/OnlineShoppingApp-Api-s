using OnlineShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Services
{
    public interface IProductService
    {

        List<Product> GetAll();
        Product AddProduct(string productname, Product product);
        List<Product> SearchProduct(string productname);
        bool UpdateProduct(string productname, int id, Product product);
        bool DeleteProduct(string productname, int id);
    }
}
