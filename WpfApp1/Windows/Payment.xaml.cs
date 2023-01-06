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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public bool mouth;
        public bool yer;
        public bool nam;
        public bool sub;
        
        public Payment()
        {
            InitializeComponent();
            mounth.MaxLength = 2;
            years.MaxLength = 2;
            main.IsEnabled = false;
            sub = false;
            yer = false;
            nam = false;
            mouth = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sub == true)
            {
                Pages.OrderFoods.proverka = true;
                Close();
                
            }
            else if (mounth.Text.Length == 2 && years.Text.Length == 2 && name.Text.Length > 2 && mouth == true && yer == true && nam == true)
            {

                Pages.OrderFoods.proverka = true;
                sub = true;
                
                Close();

            }
            else
            {
                MessageBox.Show("Неправильно заполнены данные");
            }
            
           
        }

        private void Name_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(name.Text.Contains("NAME"))
                name.Clear();
            
        }


        private bool IsCorrectMounth(string text)
        {
            string regex = @"(0[1-9])|(1[0-2])$";

            if (Regex.IsMatch(text, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsCorrectYear(string text)
        {
            string regex = @"(2[0-4])$";

            if (Regex.IsMatch(text, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            name.Text = name.Text.ToUpper();
            if(name.Text.Length > 2)
            {
                nam = true;
            }
        }

        private void Data_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsCorrectMounth(mounth.Text))
            {
                mounth.Foreground = Brushes.Red;
            }
            else if (mounth.Text.Length == 2)
            {
                mouth = true;
                mounth.Foreground = Brushes.Black;
            }
        }

        private void Years_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsCorrectYear(years.Text))
            {
                years.Foreground = Brushes.Red;
            }
            else if(years.Text.Length == 2)
            {
                yer = true;
                years.Foreground = Brushes.Black;
            }
        }

        private void Mounth_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mounth.Text.Contains("mm"))
                mounth.Clear();
        }

        private void Years_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (years.Text.Contains("yy"))
            {
                years.Clear();
            }
        }


        private void Mounth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.Text, 0));
        }

        private void Years_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.Text, 0));
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = char.IsDigit(e.Text, 0);
        }

        private void NameCard_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (NameCard.Text.Length < 16)
            {
                MessageBox.Show("Введите номер карты полностью");
            }
            else
            {
                NameCard.Foreground = Brushes.Black;
            }
        }

        private void Nal_Checked(object sender, RoutedEventArgs e)
        {
            main.IsEnabled = false;
            sub = true;
        }

        private void Card_Checked(object sender, RoutedEventArgs e)
        {
            main.IsEnabled = true;
            sub = false;
        }

        private void None_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
