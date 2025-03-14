using BookManagement.DAL.Entity;
using BookManagement.DAL.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.services
{
    public class UserService
    {
        private UserRepo UserRepo = new UserRepo();
        public List<UserAccount> GetAllUser()
        {
            return UserRepo.GetAllUser();
        }
        public UserAccount Login(string email, string password)
        {
            return UserRepo.Login(email, password);
        }
    }
}
