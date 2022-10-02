using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Models
{
    public class DBClient:IDBClient
    {
        private readonly IMongoCollection<User> _user;
        private readonly IMongoCollection<Product> _product;

        /// <summary>
        /// connecting to the mongodb
        /// </summary>
        /// <param name="databasesetting"></param>
        public DBClient(IConfiguration config)
        {
            var client = new MongoClient(config.GetValue<string>("OnlineShoppingDBSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("OnlineShoppingDBSettings:DatabaseName"));
            _user = database.GetCollection<User>(config.GetValue<string>("OnlineShoppingDBSettings:UserCollection"));
            _product = database.GetCollection<Product>(config.GetValue<string>("OnlineShoppingDBSettings:ProductCollection"));
        }

        public IMongoCollection<User> GetUserCollection()
        {
            return _user;
        }

        public IMongoCollection<Product> GetProductCollection()
        {
            return _product;
        }
    }
}
