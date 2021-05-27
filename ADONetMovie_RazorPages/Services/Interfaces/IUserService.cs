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
        void AddUser(User User);
        void DeleteUser(User User);
        void LogOut();
        User LogIn(User user);
    }
}
