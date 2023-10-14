using Progect1.shalost;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Progect1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (Context context = new Context()) 
            {
                context.Users.Add(new User() { Name = "Иван", SecondName = "", MiddleName = "", Login = "ivan", Password = "123" });
                context.Users.Add(new User() { Name = "Олег", SecondName = "", MiddleName = "", Login = "oleg", Password = "228" });
                context.Users.Add(new User() { Name = "Александр", SecondName = "", MiddleName = "", Login = "alex", Password = "123" });
                context.Users.Add(new User() { Name = "Святослава", SecondName = "", MiddleName = "", Login = "stvataya", Password = "123" });
                context.Users.Add(new User() { Name = "Ольга", SecondName = "", MiddleName = "", Login = "olga", Password = "123" });
                context.SaveChanges();
            }
        }

        private void bt_OK_Click(object sender, RoutedEventArgs e)
        {
            using (Context context = new Context())
            {
                User user = context.Users.Where(u => u.Login == tb_login.Text).FirstOrDefault() as User; // проверка по логину на наличие пользователя
                if (user == null)
                {
                    MessageBox.Show("Такой пользователь не существует", "Ошибка");
                    return;
                }
                if (user.Password != tb_password.Text && user.Login != tb_login.Text)
                {
                    MessageBox.Show("Логин или пароль введены неверно", "Ошибка");
                    return;
                }
                MessageBox.Show("Авторизация пройдена");
            }
        }
    }
}
