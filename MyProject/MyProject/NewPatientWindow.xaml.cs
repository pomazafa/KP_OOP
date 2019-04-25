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
    /// Логика взаимодействия для NewPatientWindow.xaml
    /// </summary>
    public partial class NewPatientWindow : Window
    {
        public NewPatientWindow()
        {
            InitializeComponent();
        }

        public NewPatientWindow(PATIENT p)
        {
            InitializeComponent();

            Create.Content = "Изменить";

            Surname.Text = p.SURNAME;
            FirstName.Text = p.FIRSTNAME;
            if(p.FATHERSNAME != null)
            {
                FatherName.Text = p.FATHERSNAME;
            }
            if(p.GENDER == "м")
            {
                GenderM.IsChecked = true;
            }
            if(p.GENDER == "ж")
            {
                GenderW.IsChecked = true;
            }

            if (p.BDAY != null)
            {
                DateBlock.Text = p.BDAY.Value.ToShortDateString();
            }

            if(p.TELEPHONE != null)
            {
                Telephone.Text = p.TELEPHONE;
            }

            MyDatabase db = new MyDatabase();

            ADDRESS adr = db.ADDRESS.Find(p.ADDRESS_ID);

            Street.Text = adr.STREET;

            House.Text = adr.HOUSE;

            if (adr.HOUSING != null)
            {
                Housing.Text = adr.HOUSING;
            }

            if (adr.FLAT != null)
            {
                Flat.Text = adr.FLAT.ToString();
            }
            p = db.PATIENT.Find(p.PATIENT_ID);
            db.PATIENT.Remove(p);
            db.SaveChanges();
            db.ADDRESS.Remove(adr);
            db.SaveChanges();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            SearchPatient wind = new SearchPatient();
            wind.Show();
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            
            if(Surname.Text != "" && FirstName.Text != "" && Street.Text != "" && House.Text != "")
            {
                PATIENT newP = new PATIENT();
                newP.SURNAME = Surname.Text;
                newP.FIRSTNAME = FirstName.Text;
                if (FatherName.Text != "")
                    newP.FATHERSNAME = FatherName.Text;
                if(GenderW.IsChecked == true)
                {
                    newP.GENDER = "ж";
                }
                else
                {
                    newP.GENDER = "м";
                }

                DateTime dt;
                if (DateTime.TryParse(DateBlock.Text, out dt))
                {
                    newP.BDAY = dt;
                }

                if(Telephone.Text != "")
                {
                    newP.TELEPHONE = Telephone.Text;
                }

                ADDRESS newAdr = new ADDRESS();
                newAdr.STREET = Street.Text;
                newAdr.HOUSE = House.Text;

                if(Housing.Text != "")
                {
                    newAdr.HOUSING = Housing.Text;
                }
                int flat;
                if(Flat.Text != "" && int.TryParse(Flat.Text, out flat))
                {
                    newAdr.FLAT = flat;
                }

                MyDatabase db = new MyDatabase();
                db.ADDRESS.Add(newAdr);

                db.SaveChanges();

                newP.ADDRESS_ID = newAdr.ADDRESS_ID;

                db.PATIENT.Add(newP);

                db.SaveChanges();

                SearchPatient wind = new SearchPatient();
                wind.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Заполните поля!!!!!!");
            }
        }
    }
}
