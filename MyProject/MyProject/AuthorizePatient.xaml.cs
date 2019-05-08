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
    /// Логика взаимодействия для AuthorizePatient.xaml
    /// </summary>
    public partial class AuthorizePatient : Window
    {
        UnitOfWork u;
        public AuthorizePatient()
        {
            InitializeComponent();
            u = new UnitOfWork();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string name = Firstname.Text;
            string surname = Surname.Text;
            string date = Date.Text;

            ResSet.Items.Clear();
            ResSet.Items.Refresh();
            foreach (PATIENT p in u.Patients.GetAll())
            {
                ResSet.Items.Add(p);
            }

            List<PATIENT> list = new List<PATIENT>();

            if (name != "")
            {
                list.AddRange(from a1 in u.Patients.GetAll() where a1.FIRSTNAME != name select a1);
            }

            if (surname != "")
            {
                foreach (PATIENT p in ResSet.Items)
                {
                    if (p.SURNAME != surname)
                    {
                        list.Add(p);
                    }
                }
            }
            ResSet.Items.Refresh();
            if (date != "")
            {
                foreach (PATIENT p in ResSet.Items)
                {
                    if (p.BDAY != DateTime.Parse(date))
                    {
                        list.Add(p);
                    }
                }
            }
            foreach (PATIENT p in list)
            {
                if (ResSet.Items.Contains(p))
                {
                    ResSet.Items.Remove(p);
                    ResSet.Items.Refresh();
                }
            }
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            if (ResSet.SelectedItem != null)
            {
                PATIENT p = (PATIENT)ResSet.SelectedItem;
                NewVisit wind = new NewVisit(p);
                wind.Show();
                Close();
            }
            else
                MessageBox.Show("Выберите пациента");
        }
    }
}
