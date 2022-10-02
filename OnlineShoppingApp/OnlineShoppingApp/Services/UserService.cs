using MongoDB.Driver;
using OnlineShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Services
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<User> _user;
        public UserService(IDBClient dBClient)

        {
            _user = dBClient.GetUserCollection();
        }

        /// <summary>
        ///   Getting User List         
        /// </summary>
        /// <returns>All User</returns>
        public List<User> Get()
        {

            return _user.Find(user => true).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public User Register(User user)
        {
            var sampleuser = _user.Find(u => u.Email == user.Email || u.UserName == user.UserName).FirstOrDefault();
            if (sampleuser == null)
            {
                _user.InsertOne(user);
                return user;
            }
            return null;


        }

        public User login(string username, string password)
        {
            var sampleuser = _user.Find(u => u.UserName == username && u.Password == password).FirstOrDefault();

            if (sampleuser != null)
            {
                return sampleuser;
            }

            return null;

        }

        public bool UpdatePassword(string username, string password)
        {
            var sampleuser = _user.Find(u => u.UserName == username).FirstOrDefault();
            if (sampleuser != null)
            {
                sampleuser.Password = password;
                _user.ReplaceOne(u => u.UserName == username, sampleuser);

                return true;
            }
            return false;
        }


        public List<User> searchuser(string username)
        {
            var data = _user.Find(user => user.UserName.StartsWith(username)).ToList<User>();
            data.Reverse();

            return data;
        }
    }
}