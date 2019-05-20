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
    /// Логика взаимодействия для FirstWindowTerapevt.xaml
    /// </summary>
    public partial class FirstWindowTherapist : Window
    {
        USERS user;
        UnitOfWork u;
        int countCompleted;
        List<VISIT> completedVisits;
        public FirstWindowTherapist(USERS user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Begin_Click(object sender, RoutedEventArgs e)
        {
            
            SearchPatient wind = new SearchPatient(user, DateTime.Now);
            wind.Show();
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программное средство терапевт, Дубень Полина, 2019г", "О программе");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wind = new MainWindow();
            wind.Show();
            Close();
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now.Date;
            foreach (VISIT v in completedVisits)
            {
                dt += v.VISIT_DATE_TIME2 - v.VISIT_DATE_TIME1;
            }
            string result = "Терапевт " + user.SURNAME + "\nПациентов принято: " + countCompleted +
                "\nИз них по талону: " + completedVisits.Where(v => v.IS_PLANNED == true).Count() +
                "\nОбщее время приёмов: " + dt.TimeOfDay.Hours + ":" + dt.TimeOfDay.Minutes;
            MessageBox.Show(result, "Статистика " + user.SURNAME + " за " + DateTime.Now.Day + "." + DateTime.Now.Month);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => Connect());
        }
        private void Connect()
        {
            u = new UnitOfWork();
            completedVisits = u.Visits.GetAll().Where((v) => v.VISIT_DATE_TIME1.Date == DateTime.Now.Date && v.IS_COMPLETED == true).ToList();
            countCompleted = completedVisits.Count();
        }
    }
}
