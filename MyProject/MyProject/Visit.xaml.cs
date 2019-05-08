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
        PATIENT currentPatient;
        UnitOfWork u;
        USERS user;
        VISIT visit;
        DateTime datetime1;
        bool isPlanned = false;
        public Visit(PATIENT p, USERS user, DateTime dt)
        {
            InitializeComponent();
            u = new UnitOfWork();

            currentPatient = u.Patients.Get(p.PATIENT_ID);
            this.user = u.Users.Get(user.USER_ID);
            datetime1 = dt;
            visit = null;

        }

        public Visit(PATIENT p, USERS user, VISIT visit, DateTime dt)
        {
            InitializeComponent();
           
            u = new UnitOfWork();
            currentPatient = p;
            datetime1 = dt;

            this.user = u.Users.Get(user.USER_ID);
            isPlanned = true;
            this.visit = u.Visits.Get(visit.VISIT_ID);
          
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SearchPatient wind = new SearchPatient(user, datetime1);
            wind.Show();
            Close();
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = true;
            if(visit == null)
                visit = new VISIT();
            
            visit.COMPLAINTS = Complaints.Text;
            visit.DIAGNOSIS = Diagnosis.Text;
            decimal d;
            if (Height.Text != "")
            {
                if (decimal.TryParse(Height.Text, out d) && d > 0)
                {
                    visit.HEIGHT = d;
                }
                else
                {
                    isOk = false;
                    MessageBox.Show("Поле роста заполнено неверно, возможно Вы использовали '.' вместо ',' или использовали буквы", "Ошибка");
                }
            }
            if (Weight.Text != "")
            {
                if (decimal.TryParse(Weight.Text, out d) && d > 0)
                {
                    visit.WEIGHT = d;
                }
                else
                {
                    isOk = false;
                    MessageBox.Show("Поле веса заполнено неверно, возможно Вы использовали '.' вместо ',' или использовали буквы", "Ошибка");
                }
            }

            visit.VISIT_DATE_TIME1 = DateTime.Now;

            visit.ADDITIONAL_INFORMATION = Additing.Text;

            visit.PRESSURE = Pressure.Text;



            visit.PATIENT_ID = currentPatient.PATIENT_ID;

            visit.IS_PLANNED = isPlanned;

            visit.USER_ID = user.USER_ID;


            if (isPlanned && isOk)
            {
                visit.IS_COMPLETED = true;
                visit.VISIT_DATE_TIME2 = DateTime.Now;
                visit.VISIT_DATE_TIME1 = datetime1;
                u.Save();
                FirstWindowTherapist wind = new FirstWindowTherapist(user);
                wind.Show();
                Close();
            }
            else
            {
                if (isOk)
                {
                    visit.IS_COMPLETED = true;
                    visit.VISIT_DATE_TIME1 = datetime1;
                    visit.VISIT_DATE_TIME2 = DateTime.Now;
                    u.Visits.Create(visit);
                    u.Save();
                    FirstWindowTherapist wind = new FirstWindowTherapist(user);
                    wind.Show();
                    Close();
                }
            }

        }

        private void NewVisit_Click(object sender, RoutedEventArgs e)
        {
            NewVisit wind = new NewVisit(user, currentPatient, datetime1);
            wind.ShowDialog();
        }

        private void PrintRecipe_Click(object sender, RoutedEventArgs e)
        {
            NewRecipe wind = new NewRecipe(currentPatient, user);
            wind.ShowDialog();
        }
    }
}
