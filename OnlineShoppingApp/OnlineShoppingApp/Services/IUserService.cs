using OnlineShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Services
{
    public interface IUserService
    {
        List<User> Get();
        User Register(User user);
        User login(string username, string password);
        bool UpdatePassword(string username, string password);
        List<User> searchuser(string username);
    }
}
