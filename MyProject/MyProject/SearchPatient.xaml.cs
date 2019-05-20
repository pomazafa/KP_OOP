using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        UnitOfWork u;
        USERS user;
        DateTime datetime1;
        public SearchPatient(USERS user, DateTime dt)
        {
            u = new UnitOfWork();
            InitializeComponent();
            this.user = user;
            datetime1 = dt;
            foreach(PATIENT p in u.Patients.GetAll())
            {
                ResSet.Items.Add(p);
            }
            ResSet.SelectionMode = DataGridSelectionMode.Single;
        }


        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            if (ResSet.SelectedItem != null)
            {
                PATIENT p = (PATIENT)ResSet.SelectedItem;
                Visit wind = new Visit(p, user, datetime1);
                wind.Show();
                Close();
            }
            else
                MessageBox.Show("Выберите пациента");
        }

        private void NewInfo_Click(object sender, RoutedEventArgs e)
        {
            NewPatientWindow wind = new NewPatientWindow(user, datetime1);
            wind.Show();
            Close();
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
                Regex regex = new Regex(@"(\w*)" + name + @"(\w*)");
                list.AddRange(from PATIENT a1 in ResSet.Items where regex.Matches(a1.FIRSTNAME).Count == 0 select a1);
            }
            
            if (surname != "")
            {
                Regex regex = new Regex(@"(\w*)" + surname + @"(\w*)");
                list.AddRange(from PATIENT a1 in ResSet.Items where regex.Matches(a1.SURNAME).Count == 0 select a1);
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

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (ResSet.SelectedItem != null)
            {
                PATIENT p = (PATIENT)ResSet.SelectedItem;
                NewPatientWindow wind = new NewPatientWindow(p, user, datetime1);
                wind.Show();
                Close();
            }
            else
                MessageBox.Show("Выберите пациента");
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {

            if (ResSet.SelectedItem != null)
            {
                PATIENT p = (PATIENT)ResSet.SelectedItem;
                PastVisits wind = new PastVisits(p, user, datetime1);
                wind.Show();
                Close();
            }
            else
                MessageBox.Show("Выберите пациента");
        }

        private void ShowTalons_Click(object sender, RoutedEventArgs e)
        {

            PATIENT p = (PATIENT)ResSet.SelectedItem;
            PastVisits wind = new PastVisits(user, datetime1);
            wind.Show();
            Close();

        }
    }
}
