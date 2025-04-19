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
using Kvalik2025Mukachev.Database;

namespace Kvalik2025Mukachev.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<User> users { get; set; }
        public static List<Master> masters { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string pass = PasswordTb.Text.Trim();

            users = new List<User>(App.db.User.ToList());
            User currentUser = users.FirstOrDefault(x => x.Login == login && x.Password == pass);
            masters = new List<Master>(App.db.Master.ToList());
            Master currentMaster = masters.FirstOrDefault(x => x.Login == login && x.Password == pass);
            if(LoginTb.Text != "" && PasswordTb.Text != "")
            {
                if (currentMaster != null)
                {
                    NavigationService.Navigate(new RecordListPage());
                    MessageBox.Show("Мастер");

                }
                else if (currentUser != null)
                {
                    if (currentUser.ID_role == 1)
                    {
                        MessageBox.Show("Клиент");

                    }
                    else if(currentUser.ID_role == 2)
                    {
                    MessageBox.Show("Администратор");

                    }
                    else if(currentUser.ID_role == 3)
                    {
                        MessageBox.Show("Модератор");

                    }
                }
                else
                {
                    MessageBox.Show("Мы не нашли ваши данные в системе, попробуйте зайти снова");
                    LoginTb.Text = "";
                    PasswordTb.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!!");

            }
        }
    }
}
