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
        public EnterTherapist()
        {
            InitializeComponent();
            u = new UnitOfWork();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wind = new MainWindow();
            wind.Show();
            Close();
           
        }

        private void EnterTher_Click(object sender, RoutedEventArgs e)
        {
            using (MyDatabase db = new MyDatabase())
            {
                int password = MyPassword.Password.GetHashCode();
                string login = Login.Text;
                var user = u.Users.GetAll().FirstOrDefault(x => x.PASSWORD_HASH == password && x.LOGIN == login); 
                if (user != null)
                {
                    FirstWindowTherapist wind = new FirstWindowTherapist();
                    wind.Show();
                    Close();
                }
                else
                    MessageBox.Show("Неправильный логин или пароль");
            }
            
        }
    }
}
