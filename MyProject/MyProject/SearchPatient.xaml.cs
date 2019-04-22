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
    /// Логика взаимодействия для SearchPatient.xaml
    /// </summary>
    public partial class SearchPatient : Window
    {
        public SearchPatient()
        {
            InitializeComponent();
        }

        private void ShowTalons_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            Visit wind = new Visit();
            wind.Show();
            Close();
        }

        private void NewInfo_Click(object sender, RoutedEventArgs e)
        {
            NewPatientWindow wind = new NewPatientWindow();
            wind.Show();
            Close();
        }
    }
}
