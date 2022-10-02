using MongoDB.Driver;
using OnlineShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _product;
        public ProductService(IDBClient dBClient)

        {
            _product = dBClient.GetProductCollection();
        }

        public Product AddProduct(string productname, Product product)
        {
            int productIdNo = GetAll().Count();
            product.ProductId = productIdNo + 1;
            _product.InsertOne(product);
            return product;
        }

        public bool DeleteProduct(string productname, int id)
        {
            var sampleproduct = _product.Find(p => p.ProductName == productname && p.ProductId == id).FirstOrDefault();
            if (sampleproduct != null)
            {
                _product.DeleteOne(p => p.ProductName == productname && p.ProductId == id);
                return true;
            }
            return false;
        }

        public List<Product> GetAll()
        {
            var products = _product.Find(tweet => true).ToList();
            products.Reverse();
            return products; ;
        }

        public List<Product> SearchProduct(string productname)
        {
            var data = _product .Find(product => product.ProductName.StartsWith(productname)).ToList<Product>();
            data.Reverse();

            return data;
        }

        public bool UpdateProduct(string productname, int id, Product product)
        {
            var sampleproduct = _product.Find(p => p.ProductName == productname && p.ProductId == id).FirstOrDefault();
            if (sampleproduct != null)
            {
                product.Id = sampleproduct.Id;
                product.ProductId = id;
                _product.ReplaceOne(p => p.ProductName == productname && p.ProductId == id, product);

                return true;
            }
            return false;
        }
    }
}
