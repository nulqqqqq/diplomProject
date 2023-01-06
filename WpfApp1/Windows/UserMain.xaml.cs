using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Threading;
using WpfApp1.Pages;

namespace WpfApp1.Windows
{

    public partial class UserMain : Window
    {
        UserContext db;
        public static int Id;
        MainWindow mainWindow;



        public UserMain()
        {
            db = new UserContext();
            InitializeComponent();
           


        }

        

        private void RestBtn_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            userName.Text = "";
            logo.Height = 0;
            main.Content = new RestPage();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            userName.Text = "";
            logo.Height = 0;
            main.Content = new OrderFoods();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            userName.Text = "";
            logo.Height = 0;
            main.Content = new Search();
        }
    }
}

