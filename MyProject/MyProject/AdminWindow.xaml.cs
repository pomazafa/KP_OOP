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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        UnitOfWork u;
        public AdminWindow()
        {
            u = new UnitOfWork();
            InitializeComponent();

            var elements = from a1 in u.Users.GetAll() where a1.LOGIN != "admin" select a1;

            foreach (USERS v in elements)
            {
                ResSet.Items.Add(v);
            }

            ResSet.SelectionMode = DataGridSelectionMode.Single;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            EnterTherapist wind = new EnterTherapist();
            wind.Show();
            Close();
        }
    }
}
