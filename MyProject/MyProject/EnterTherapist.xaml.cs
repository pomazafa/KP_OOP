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

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для EnterTherapist.xaml
    /// </summary>
    public partial class EnterTherapist : Window
    {
        UnitOfWork u;
        List<USERS> users;
        public EnterTherapist()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wind = new MainWindow();
            wind.Show();
            Close();
        }

        private void EnterTher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int password = MyPassword.Password.GetHashCode();
                string login = Login.Text;
                if (login != "" && MyPassword.Password != "")
                {
                    var user = users.FirstOrDefault(x => x.PASSWORD_HASH == password && x.LOGIN == login);
                    if (user != null)
                    {
                        if (user.LOGIN == "admin")
                        {
                            AdminWindow wind = new AdminWindow();
                            wind.Show();
                            Close();
                        }
                        else
                        {
                            FirstWindowTherapist wind = new FirstWindowTherapist(user);
                            wind.Show();
                            Close();
                        }
                    }
                    else
                        MessageBox.Show("Неправильный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            await Task.Run(() => Connect());
        }

        private void Connect()
        {
            try
            {
                u = new UnitOfWork();
                users = u.Users.GetAll().ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
