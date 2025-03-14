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
        public UserAccount? GetOne(string email, string password)
        {
            this._contextDb = new BookManagementDbContext();
            return this._contextDb.UserAccounts.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            //hàm FirstOrDefault sẽ trả về null nếu không tìm thấy -> Nên ta trả về kiểu UserAccount?
        }
    }
}
