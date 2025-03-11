using BookManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.repositories
{
    public class CategoryRepo
    {
        private BookManagementDbContext _dbContext = null;
        public List<BookCategory> GetALlCategory()
        {
            _dbContext = new BookManagementDbContext();
            return _dbContext.BookCategories.ToList();
        }
    }
}
