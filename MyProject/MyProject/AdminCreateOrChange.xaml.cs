﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AdminCreateOrChange.xaml
    /// </summary>
    public partial class AdminCreateOrChange : Window
    {
        USERS user;
        UnitOfWork u;
        bool isNew = true;
        public AdminCreateOrChange()
        {
            InitializeComponent();
            user = null;
            u = new UnitOfWork();
        }

        public AdminCreateOrChange(USERS user)
        {
            InitializeComponent();
            u = new UnitOfWork();
            this.user = user;
            isNew = false;
            PasswordHash.Text = user.PASSWORD_HASH.ToString();
            Surname.Text = user.SURNAME;
            Name.Text = user.NAME;
            FathersName.Text = user.FATHERSNAME;
            Login.Text = user.LOGIN;
            if (user.CHANGE == "1")
                Change1.IsChecked = true;
            else
                Change2.IsChecked = true;

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordHash.Text != "" && Login.Text != "" && Surname.Text != "" && Name.Text != "" && FathersName.Text != ""
                && ValidationText(Surname.Text) && ValidationText(Name.Text) && ValidationText(FathersName.Text))
            {
                if (isNew)
                {
                    user = new USERS();
                }
                else
                {
                    u.Users.Get(user.USER_ID);
                }
                user.FATHERSNAME = FathersName.Text;
                user.SURNAME = Surname.Text;
                user.NAME = Name.Text;
                user.PASSWORD_HASH = int.Parse(PasswordHash.Text);
                user.LOGIN = Login.Text;
                if (Change2.IsChecked == true)
                {
                    user.CHANGE = "2";
                }
                else
                {
                    user.CHANGE = "1";
                }
                if (isNew)
                {
                    u.Users.Create(user);
                }
                u.Save();
                Close();
            }
            else
                MessageBox.Show("Заполните все поля корректной информацией");
        }

        private bool ValidationText(string text)
        {
            Regex regex1 = new Regex(@"(\d+)");
            Regex regex2 = new Regex(@"(\W+)");
            MatchCollection matches1 = regex1.Matches(text);
            MatchCollection matches2 = regex2.Matches(text);
            if (matches1.Count > 0 || matches2.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordHash.Text = ((TextBox)sender).Text.GetHashCode().ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
