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
    /// 
    class PatientTherapistVisit
    {
        public PATIENT p { get; set; }
        public USERS user { get; set; }
        public VISIT v { get; set; }
        public PatientTherapistVisit(PATIENT p, USERS user, VISIT v)
        {
            this.p = p;
            this.user = user;
            this.v = v;
        }
    }
    public partial class PastVisits : Window
    {

        UnitOfWork u;
        PATIENT currentPatient;
        USERS user;
        DateTime datetime1;
        public PastVisits(PATIENT p, USERS user, DateTime dt)
        {
            u = new UnitOfWork();
            currentPatient = null;
            InitializeComponent();
            datetime1 = dt;
            this.user = user;
            var elements = from a1 in u.Visits.GetAll() where a1.PATIENT_ID == p.PATIENT_ID select a1;

            foreach (VISIT v in elements)
            {
                ResSet.Items.Add(new PatientTherapistVisit(u.Patients.Get(v.PATIENT_ID.Value), u.Users.Get(v.USER_ID.Value), v));
            }

            Choose.Visibility = System.Windows.Visibility.Hidden;
            this.Title = "Предыдущие посещения пациента " + p.SURNAME + " " + p.FATHERSNAME;
            ResSet.SelectionMode = DataGridSelectionMode.Single;

        }

        public PastVisits(USERS user, DateTime dt)
        {
            u = new UnitOfWork();
            InitializeComponent();
            var elements = from a1 in u.Visits.GetAll() where a1.VISIT_DATE_TIME1.Date == DateTime.Now.Date && a1.IS_COMPLETED == false && a1.USER_ID == user.USER_ID select a1;
            this.user = user;
            datetime1 = dt;
            foreach (VISIT v in elements)
            {
                ResSet.Items.Add(new PatientTherapistVisit(u.Patients.Get(v.PATIENT_ID.Value), u.Users.Get(v.USER_ID.Value), v));
            }
            this.Title = "Записи на сегодня";

            ResSet.SelectionMode = DataGridSelectionMode.Single;

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SearchPatient wind = new SearchPatient(user, datetime1);
            wind.Show();
            Close();
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            if (ResSet.SelectedItem != null)
            {
                VISIT v = (VISIT)ResSet.SelectedItem;
                int pat = v.PATIENT_ID.Value;
                currentPatient = u.Patients.Get(pat);
                Visit wind = new Visit(currentPatient, user, v, datetime1);
                wind.Show();
                Close();
            }
            else
                MessageBox.Show("Выберите пациента");
        }
    }
}
