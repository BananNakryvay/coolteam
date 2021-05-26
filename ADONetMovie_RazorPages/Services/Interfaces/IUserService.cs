using ADONetMovie_RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        public User GetUserById(int id);
        void DeleteUser(User User);
        void LogOut();
        void LogIn(User user);
    }
}
