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
        MyDatabase db;
        public SearchPatient()
        {
            db = new MyDatabase();
            InitializeComponent();

            foreach(PATIENT p in db.PATIENT)
            {
                ResSet.Items.Add(p);
            }
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string name = Firstname.Text;
            string surname = Surname.Text;
            string date = Date.Text;

            ResSet.Items.Clear();
            ResSet.Items.Refresh();
            foreach (PATIENT p in db.PATIENT)
            {
                ResSet.Items.Add(p);
            }

            List<PATIENT> list = new List<PATIENT>();

            if (name != "")
            {
                list.AddRange(from a1 in db.PATIENT where a1.FIRSTNAME != name select a1);
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

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (ResSet.SelectedItem != null)
            {
                PATIENT p = (PATIENT)ResSet.SelectedItem;
                NewPatientWindow wind = new NewPatientWindow(p);
                wind.Show();
                Close();
            }
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            //if (ResSet.SelectedItem != null)                  УДАЛЕНИЕ ВЫБРАННОГО ПАЦИЕНТА
            //{
            //    PATIENT p = (PATIENT)ResSet.SelectedItem;
            //    db.PATIENT.Remove(p);
            //    db.SaveChanges();
            //    ResSet.Items.Remove(p);
            //    ResSet.Items.Refresh();
            //}
        }
    }
}
