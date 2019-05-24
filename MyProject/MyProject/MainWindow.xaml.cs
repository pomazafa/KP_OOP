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

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void EnterTher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EnterTherapist et = new EnterTherapist();
                Close();
                et.Show();
            }
            catch { }
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthorizePatient wind = new AuthorizePatient();
                wind.Show();
                Close();
            }
            catch { }
        }
    }
}
