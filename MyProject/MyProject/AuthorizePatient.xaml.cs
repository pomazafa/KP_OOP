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
    /// Логика взаимодействия для AuthorizePatient.xaml
    /// </summary>
    public partial class AuthorizePatient : Window
    {
        UnitOfWork u;
        List<PATIENT> patients;
        public AuthorizePatient()
        {
            InitializeComponent();
            u = new UnitOfWork();
            try
            {
                Connect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private async void Connect()
        {
            await  Task.Run(() => patients = u.Patients.GetAll().ToList());
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string name = Firstname.Text;
            string surname = Surname.Text;
            string date = Date.Text;

            ResSet.Items.Clear();
            ResSet.Items.Refresh();

            if (patients != null)
            {
                List<PATIENT> list = new List<PATIENT>();

                if (name != "")
                {
                    Regex regex = new Regex(@"(\w*)" + name + @"(\w*)");
                    list.AddRange(from a1 in patients where regex.Matches(a1.FIRSTNAME).Count == 0 select a1);
                }

                if (surname != "")
                {
                    Regex regex = new Regex(@"(\w*)" + surname + @"(\w*)");
                    list.AddRange(from a1 in patients where regex.Matches(a1.SURNAME).Count == 0 select a1);
                }
                ResSet.Items.Refresh();
                if (date != "")
                {
                    list.AddRange(from a1 in patients where a1.BDAY != DateTime.Parse(date) select a1);
                }
                if (list.Count != 0)
                {
                    foreach (PATIENT p in patients)
                    {
                        if (!list.Contains(p))
                        {
                            ResSet.Items.Add(p);
                        }
                    }
                    ResSet.Items.Refresh();

                    if (ResSet.Items.Count == 0)
                    {
                        MessageBox.Show("Не найден пациент, удовлетворяющий запросу");
                    }
                }
                else
                    MessageBox.Show("Заполните поля для поиска");
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wind = new MainWindow();
            wind.Show();
            Close();
        }
    }
}
