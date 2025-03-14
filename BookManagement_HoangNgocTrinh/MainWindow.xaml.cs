using Azure.Messaging;
using BookManagement.BLL.services;
using BookManagement.DAL.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService _service = new();
        public UserAccount? User { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BookMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (User.Role == 1)
            {
                BookListDataGrid.ItemsSource = _service.GetAllBooks();
            }
            //hàm này sẽ tự chạy khi của sổ MainWindow mở ra
            //trả sẽ gọi service giúp để lấy toàn bộ data từ table book chuyển vào fill váo cái grid
            //vì ta còn xài CRUD BOOK cho nên ta sẽ khai báo biến BOOKSERVICE ở ngoài hàm ngày để còn dùng được trong toàn bộ của sổ này

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //Tạo màn hình Book Detail
            BookDetailWindow bookDetailWindow = new BookDetailWindow();
            //Bước 1 đổi tên Detail Header Label phân biệt create/ update
            bookDetailWindow.DetailHeaderLabel.Content = "Create Book";
            bookDetailWindow.ShowDialog();
            //Bước 2: refresh lại cái grid
            FillDataGrid(_service.GetAllBooks());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = BookListDataGrid.SelectedItem as Book;
            if (selectedBook == null)
            {
                MessageBox.Show("Please select the book first!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            BookDetailWindow bookDetailWindow = new BookDetailWindow();
            //Bước 1 đổi tên Detail Header Label phân biệt create/ update
            bookDetailWindow.DetailHeaderLabel.Content = "Update Book";
            bookDetailWindow.EditedOne = selectedBook;
            bookDetailWindow.ShowDialog();
            //Bước 2: refresh lại cái grid
            FillDataGrid(_service.GetAllBooks());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Book selectedBook = BookListDataGrid.SelectedItem as Book;
            if (selectedBook == null)
            {
                MessageBox.Show("Please select the book first!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Bước 2: Confirm
            MessageBoxResult answer = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //Bước 3: check confirm result
            if (answer == MessageBoxResult.Yes)
            {
                //Bước 4: gọi service xóa
                _service.DeleteBook(selectedBook);
                //Bước 5: refresh lại cái grid
                FillDataGrid(_service.GetAllBooks());
                //Bước 6: thông báo đã xóa xong
                MessageBox.Show("Deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                //Bước 7: Refresh selected item
                BookListDataGrid.SelectedItem = null;
                //Vì UI đã chọn Yes/No nên nó mất màu xanh khi select vào list nhưng list vẫn đang có giá trị selected book là thằng cũ nên phải set lại selected item = null để không bị lặp
            }
        }

        private void FillDataGrid(List<Book> listBooks)
        {
            BookListDataGrid.ItemsSource = null; //xóa data cũ
            BookListDataGrid.ItemsSource = listBooks;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchBookName = BookNameTextBox.Text;
            string searchDescription = DescriptionTextBox.Text;
            List<Book> listBooks = _service.GetAllBooks().FindAll(x => x.BookName.Contains(searchBookName) && x.Description.Contains(searchDescription));
            FillDataGrid(listBooks);
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}