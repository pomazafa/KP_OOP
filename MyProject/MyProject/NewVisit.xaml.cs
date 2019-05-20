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
    /// Логика взаимодействия для NewVisit.xaml
    /// </summary>
    /// 
    class MyTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public MyTime(int i1, int i2)
        {
            Hours = i1;
            Minutes = i2;
        }
    }
    public partial class NewVisit : Window
    {
        USERS user;
        UnitOfWork u;
        PATIENT p;
        List<MyTime> dates;
        List<VISIT> visits;
        int[] minutes = { 00, 15, 30, 45 };
        int hour1 = 8;
        int hour2 = 14;
        DateTime datetime1;
        public NewVisit(PATIENT p)
        {
            InitializeComponent();
            user = null;
            dates = new List<MyTime>();
            visits = new List<VISIT>();

            Window_Loaded();
            ResSet.SelectedIndex = 0;
            this.p = p;
            datetime1 = DateTime.MinValue;
        }

        public NewVisit(USERS user, PATIENT p, DateTime dt)
        {
            InitializeComponent();
            this.user = user;
            this.p = p;
            dates = new List<MyTime>();
            visits = new List<VISIT>();
            Window_Loaded();
            ResSet.SelectedIndex = 0;
            datetime1 = dt;
            Ok.Content = "Записать";
        }

        private void Window_Loaded()
        {
            u = new UnitOfWork();

            foreach(USERS us in from a1 in u.Users.GetAll() where a1.LOGIN != "admin" select a1)
            {
                ResSet.Items.Add(us);
            }

            ResSet.SelectionMode = DataGridSelectionMode.Single;
        }

        private void ResSet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dates.Items.Clear();
            dates.Clear();
            int hour = 0;
            if (ResSet.SelectedItem != null)
            {
                if (u.Users.Get(((USERS)ResSet.SelectedItem).USER_ID).CHANGE == "1")
                    hour = hour1;
                else
                    hour = hour2;
            }

            if (calendar.SelectedDate > DateTime.Now && ResSet.SelectedItem != null && calendar.SelectedDate.Value.DayOfWeek != DayOfWeek.Saturday && calendar.SelectedDate.Value.DayOfWeek != DayOfWeek.Sunday)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < minutes.Length; j++)
                    {
                        var c = from a1 in u.Visits.GetAll()
                                where a1.VISIT_DATE_TIME1 == a1.VISIT_DATE_TIME1.Date.AddHours(hour + i).AddMinutes(minutes[j])
                                && ((USERS)ResSet.SelectedItem).USER_ID == a1.USER_ID && a1.VISIT_DATE_TIME1.Date == calendar.SelectedDate
                                select a1;
                        if (c.Count() == 0)
                            dates.Add(new MyTime(hour + i, minutes[j]));
                    }
                }
                foreach (MyTime mt in dates)
                    Dates.Items.Add(mt);
                //Dates.ItemsSource = dates;
            }

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            //не забыть про datetime1
            if (ResSet.SelectedItem != null && Dates.SelectedItem != null)
            {
                VISIT visit = new VISIT();
                visit.PATIENT_ID = p.PATIENT_ID;
                visit.IS_PLANNED = true;
                visit.IS_COMPLETED = false;
                visit.USER_ID = ((USERS)ResSet.SelectedItem).USER_ID;
                visit.VISIT_DATE_TIME2 = DateTime.MaxValue;
                visit.VISIT_DATE_TIME1 = calendar.SelectedDate.Value.Date.AddHours(((MyTime)Dates.SelectedItem).Hours).AddMinutes(((MyTime)Dates.SelectedItem).Minutes);
                u.Visits.Create(visit);
                u.Save();
                if (user == null)
                {

                    MainWindow wind = new MainWindow();
                    wind.Show();
                }
                MessageBox.Show("Посещение добавлено в базу данных");

                Close();
            }
            else
            {
                MessageBox.Show("Выберите терапевта, дату и время посещения");
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                AuthorizePatient wind = new AuthorizePatient();
                wind.Show();
            }
            Close();
        }
    }
}
