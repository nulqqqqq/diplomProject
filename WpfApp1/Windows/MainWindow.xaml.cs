using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Windows.LoginScreen loginScreen = new Windows.LoginScreen();
            loginScreen.Show();
            Close();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Windows.Registration registration = new Windows.Registration();
            registration.Show();
            Close();
        }

    }
}
