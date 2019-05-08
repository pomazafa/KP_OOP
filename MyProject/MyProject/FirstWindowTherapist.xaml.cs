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
    /// Логика взаимодействия для FirstWindowTerapevt.xaml
    /// </summary>
    public partial class FirstWindowTherapist : Window
    {
        USERS user;
        public FirstWindowTherapist(USERS user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Begin_Click(object sender, RoutedEventArgs e)
        {
            
            SearchPatient wind = new SearchPatient(user, DateTime.Now);
            wind.Show();
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программное средство терапевт, Дубень Полина, 2019г", "О программе");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wind = new MainWindow();
            wind.Show();
            Close();
        }
    }
}
