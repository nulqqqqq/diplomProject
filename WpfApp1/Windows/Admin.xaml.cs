using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        UserContext db;
        public Admin()
        {
            InitializeComponent();
            db = new UserContext();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminApp adminApp = new AdminApp();
            adminApp.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.dataGrid.ItemsSource = db.restaurants.ToList();
            adminMenu.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                LoginScreen log = new LoginScreen();
                log.Show();
                Close();
            }
        }

        
    }
}
