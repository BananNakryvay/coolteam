﻿
using ADONetMovie_RazorPages.Models;
using ADONetMovie_RazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADONetMovie_RazorPages.Services
{
    public class UserService : IUserService
    {
     
        private AdonetUserService userService { get; set; }
        public UserService(AdonetUserService service)

        {
            userService = service;
        }
        public IEnumerable<User> GetUsers()
        {
            return userService.GetUsers();
        }
        public User GetUserById(int id)
        {
            return   null;
        }

        public void DeleteUser(User User)
        {
            userService.DeleteUser(User);
        }
    }
}