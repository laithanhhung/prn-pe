using BookManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.repositories
{
    public class UserRepo
    {
        private BookManagementDbContext _contextDb;
        public List<UserAccount> GetAllUser()
        {
            this._contextDb = new BookManagementDbContext();
            return this._contextDb.UserAccounts.ToList();
        }
        public UserAccount Login(string email, string password)
        {
            this._contextDb = new BookManagementDbContext();
            return this._contextDb.UserAccounts.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }
    }
}
