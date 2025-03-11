using BookManagement.DAL.Entity;
using BookManagement.DAL.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.services
{
    public class CategoryService
    {
        private CategoryRepo _categoryRepo = new CategoryRepo();

        public List<BookCategory> GetALlBookCategory()
        {
            return _categoryRepo.GetALlCategory();
        }
    }
}
