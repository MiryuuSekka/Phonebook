using System;
using System.Windows;
using System.Text.RegularExpressions;
using FileManager;
using FileManager.Models;
using System.Collections.Generic;

namespace Phonebook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manager LocalBook;
        enum Columns { LastName, FirstName, BirthYear, Telephone };
        Regex TelephoneFormat = new Regex(@"^((\+7|7|8)+([0-9]){10})$");
        Regex NameFormat = new Regex(@"^[A-Z]'?([a-zA-Z]|\.| |-)+$");
        Regex YearFormat = new Regex(@"^[1-2][0-9][0-9][0-9]$");
        Match match;

        public MainWindow()
        {
            InitializeComponent();
            LocalBook = new Manager();
            LocalBook.ReadFile();
            RefreshTable();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            bool result = true;
            var Validate = Formatter();
            ShowErrors(Validate);

            for (int i = 0; i < Validate.Length; i++)
            {
                result &= Validate[i];
            }

            if (result)
            {
                LocalBook.AddToList(new Person()
                {
                    BirthYear = int.Parse(tb_Year.Text),
                    FirstName = tb_First.Text,
                    LastName = tb_Last.Text,
                    Phone = tb_Tel.Text
                });

                RefreshTable();
            }
        }

        bool[] Formatter()
        {
            var Validate = new bool[4] { true, true, true, true };
            int Number;

            match = NameFormat.Match(tb_First.Text);
            if (match.Success) tb_First.Text = match.Value;
            else
            {
                Validate[(int)Columns.FirstName] = false;
            }
            
            match = NameFormat.Match(tb_Last.Text);
            if (match.Success) tb_Last.Text = match.Value;
            else
            {
                Validate[(int)Columns.LastName] = false;
            }

            match = YearFormat.Match(tb_Year.Text);
            if (match.Success)
            {
                int.TryParse(tb_Year.Text, out Number);
                if ((Number > DateTime.Now.Year) || (Number < 1900))
                {
                    Validate[(int)Columns.BirthYear] = false;
                }
                else { tb_Year.Text = match.Value; }
            }
            else
            {
                Validate[(int)Columns.BirthYear] = false;
            }

            match = TelephoneFormat.Match(tb_Tel.Text);
            if (match.Success) tb_Tel.Text = match.Value;
            else
            {
                Validate[(int)Columns.Telephone] = false;
            }
            return Validate;
        }

        void ShowErrors(bool[] Validate)
        {
            if (Validate[(int)Columns.Telephone]) lb_Tel.Content = "";
            else { lb_Tel.Content = "Wrong number"; }

            if (Validate[(int)Columns.BirthYear]) lb_Year.Content = "";
            else { lb_Year.Content = "Wrong number"; }

            if (Validate[(int)Columns.FirstName]) lb_First.Content = "";
            else { lb_First.Content = "Wrong format"; }

            if (Validate[(int)Columns.LastName]) lb_Last.Content = "";
            else { lb_Last.Content = "Wrong format"; }
        }

        void RefreshTable()
        {
            var Data = LocalBook.GetList();

            string str;
            tb_text.Text = "";
            for (int i = 0; i < Data.Count; i++)
            {
                str = i.ToString() + "    ";
                str += Data[i].LastName.ToString() + "   ";
                str += Data[i].FirstName.ToString() + "   ";
                str += Data[i].BirthYear.ToString() + "   ";
                str += Data[i].Phone.ToString() + "\n";
                tb_text.Text += str;
            }
        }

        private void btn_LastName_Click(object sender, RoutedEventArgs e)
        {
            LocalBook.SortListByLastName();
            RefreshTable();
        }

        private void btn_Year_Click(object sender, RoutedEventArgs e)
        {
            LocalBook.SortListByBirth();
            RefreshTable();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LocalBook.SaveFile();
        }

        private void Btn_remove_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tb_id.Text, out int id);
            LocalBook.RemoveFromList(id);
            RefreshTable();
        }

        private void Btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            var Finded = LocalBook.SearchInList(tb_Search.Text);

            string str;
            tb_text.Text = "";
            for (int i = 0; i < Finded.Count; i++)
            {
                str = i.ToString() + "    ";
                str += Finded[i].LastName.ToString() + "   ";
                str += Finded[i].FirstName.ToString() + "   ";
                str += Finded[i].BirthYear.ToString() + "   ";
                str += Finded[i].Phone.ToString() + "\n";
                tb_text.Text += str;
            }
        }
    }
}
