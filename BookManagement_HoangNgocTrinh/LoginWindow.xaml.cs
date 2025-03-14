using BookManagement.BLL.services;
using BookManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserService _userService = new UserService();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Bước 1: Lấy thông tin từ 2 textbox
            //Bước 2: Gọi service để kiểm tra thông tin đó có trong database không
            //Bước 3: Nếu có thì mở
            //Bước 4: Nếu không thì thông báo lỗi
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            UserAccount user = this._userService.Login(email, password);
            if (user.Role == 1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.User = user;
                mainWindow.Show();
                this.Close();
            }
            else if (user.Role == 2 || user.Role == 3)
            {

                MainWindow mainWindow = new MainWindow();
                mainWindow.User = user;
                mainWindow.HeaderLabel.Content = "You have no permission to access this function!.";
                mainWindow.BookNameTextBox.IsEnabled = false;
                mainWindow.DescriptionTextBox.IsEnabled = false;
                mainWindow.SearchButton.IsEnabled = false;
                mainWindow.CreateButton.IsEnabled = false;
                mainWindow.UpdateButton.IsEnabled = false;
                mainWindow.DeleteButton.IsEnabled = false;
                mainWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Email or password is incorrect!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
