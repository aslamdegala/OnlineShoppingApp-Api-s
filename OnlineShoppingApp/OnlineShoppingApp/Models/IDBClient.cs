using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Models
{
    public interface IDBClient
    {
        IMongoCollection<User> GetUserCollection();
        IMongoCollection<Product> GetProductCollection();
    }
}
