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
    /// Логика взаимодействия для Visit.xaml
    /// </summary>
    public partial class Visit : Window
    {
        public Visit()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SearchPatient wind = new SearchPatient();
            wind.Show();
            Close();
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            FirstWindowTherapist wind = new FirstWindowTherapist();
            wind.Show();
            Close();
        }
    }
}
