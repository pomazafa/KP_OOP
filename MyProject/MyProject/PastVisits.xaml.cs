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
    /// Логика взаимодействия для PastVisits.xaml
    /// </summary>
    public partial class PastVisits : Window
    {

        UnitOfWork u;
        PATIENT currentPatient;
        public PastVisits(PATIENT p)
        {
            u = new UnitOfWork();
            currentPatient = p;
            InitializeComponent();
            var elements = from a1 in u.Visits.GetAll() where a1.PATIENT_ID == p.PATIENT_ID select a1;

            foreach (VISIT v in elements)
            {
                ResSet.Items.Add(v);
            }
        }

        public PastVisits()
        {
            u = new UnitOfWork();
            InitializeComponent();
            var elements = from a1 in u.Visits.GetAll() where a1.VISIT_DATE_TIME.Date == DateTime.Now.Date select a1;

            foreach (VISIT v in elements)
            {
                ResSet.Items.Add(v);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SearchPatient wind = new SearchPatient();
            wind.Show();
            Close();
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
