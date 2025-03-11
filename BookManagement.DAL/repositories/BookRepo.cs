using BookManagement.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.repositories
{
    public class BookRepo
    {
        //Nhớ là GUI -- gọi Services -- gọi Repo -- gọi DBContext -- gọi Table
        //Ta cần khai báo biến CONTEXT
        private BookManagementDbContext _dbContext;
        //ko new ngay màn mới mới new

        //các crud trên table book
        public List<Book> GetAllBooks()
        {
            //nhớ new DbContext mỗi lần sử dụng
            _dbContext = new BookManagementDbContext();
            //do .Books trả về DbSet rất giống ArrayList, List
            // Mình cần convert về list
            //return _dbContext.Books.ToList();
            //Viết kiểu này thì ko join với bản BookCategory
            return this._dbContext.Books.Include("BookCategory").ToList();

            //đã join Book và BookCategory bởi foreignKey BookCategoryId

        }

        public void AddNewBook(Book book)
        {
            _dbContext = new BookManagementDbContext();
            this._dbContext.Books.Add(book);
            this._dbContext.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _dbContext = new BookManagementDbContext();
            _dbContext.Books.Remove(book);//y chang ArrayList bên JAVA, remove 1 phần tử khỏi list
            _dbContext.SaveChanges();//đồng bộ DB
        }

        public void UpdateBook(Book book)
        {
            _dbContext = new BookManagementDbContext();
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }
    }
}
