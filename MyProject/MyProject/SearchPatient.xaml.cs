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
                foreach (PATIENT p in ResSet.Items)
                {
                    if (p.FIRSTNAME != name)
                    {
                        list.Add(p);
                    }
                }
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
            //var r = context1.OrderedGoods;
            //List<OrderedGoods> lst = new List<OrderedGoods>();
            //if (dg2.SelectedItem != null)
            //{
            //    Orders order = dg2.SelectedItem as Orders;
            //    foreach (OrderedGoods item in r)
            //    {
            //        if (item.OrderID == order.OrderID)
            //        {
            //            lst.Add(item);
            //        }
            //    }
            //    AddProductOrder d = new AddProductOrder(order, lst);
            //    if (d.ShowDialog() == true)
            //    {
            //        context1.SaveChanges();
            //        var show1 = context1.OrderedGoods;
            //        dg1.ItemsSource = null;
            //        dg1.Items.Clear();
            //        foreach (OrderedGoods m in show1)
            //        {
            //            if (m.OrderID == order.OrderID)
            //            {
            //                dg1.Items.Add(m);
            //            }
            //        }
            //        dg1.Items.Refresh();

            //    }
            //}
            //else MessageBox.Show("Выберите заказ для добавления товара(oв)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);

        }

    }
}
