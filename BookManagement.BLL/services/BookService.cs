using BookManagement.DAL.Entity;
using BookManagement.DAL.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.services
{
    public class BookService
    {
        //NHỚ: GUI -- SERVICE -- REPO -- DBCONTEXT -- TABLE
        private BookRepo _bookRepo = new BookRepo();
        //new lun: vì nó bao thằng repo. Thằng Repo đã tự lo new DBContext đúng chỗ

        //Các hàm CRUB như bình thường trên table BOOK, nhưng ko tự làm phải gọi REPO giúp vì repo nằm DbContext
        //Trong DbContext có Connection String đọc từ file .JSON
        public List<Book> GetAllBooks() => _bookRepo.GetAllBooks();

        public void AddNewBook(Book book) => _bookRepo.AddNewBook(book);

        public void DeleteBook(Book book) => _bookRepo.DeleteBook(book);

        public void UpdateBook(Book book) => _bookRepo.UpdateBook(book);

        public List<Book> SearchBookByNameOrDesc(string searchValue) => _bookRepo.SearchBookByNameOrDesc(searchValue);
    }
}
