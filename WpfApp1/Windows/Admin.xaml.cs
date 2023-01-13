using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Show_Restaurants_Click(object sender, RoutedEventArgs e)
        {
            AdminApp adminApp = new AdminApp();
            adminApp.Show();
            Close();
        }

        private void Show_Menu_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            var request = ServiceClass<string>.GetRequest("GetRestaurants").Result;
            adminMenu.dataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(request);
            adminMenu.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs exitKey)
        {
            if (exitKey.Key == Key.Escape)
            {
                LoginScreen log = new LoginScreen();
                log.Show();
                Close();
            }
        } 
    }
}
