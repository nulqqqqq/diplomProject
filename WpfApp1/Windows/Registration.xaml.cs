using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace WpfApp1.Windows
{

    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();      
        }

        private bool IsCorrectValue(string text)
        {
            string regex = @"^[а-яА-ЯёЁa-zA-Z0-9]{4,16}$";

            if (Regex.IsMatch(text, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Window_KeyDown(object sender, KeyEventArgs exitKey)
        {
            if (exitKey.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }

        private async void Done_Click(object sender, RoutedEventArgs e)
        {
            if (!IsCorrectValue(RegLogin.Text))
            {
                MessageBox.Show("Логин должен быть от 4 до 16 символов!");
            }
            else if(!IsCorrectValue(RegPassword.Password))
            {
                MessageBox.Show("Пароль должен быть от 4 до 16 символов!");
            }
            else if (RegPassword.Password != Reg2Password.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else
            {
                User user = new User { UserName = RegLogin.Text, Password = RegPassword.Password };
                var request = await ServiceClass<User>.PostRequest("Registration", user);
                bool result = JsonConvert.DeserializeObject<bool>(request);
                if (result == false)
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован!");
                }
                else
                {
                    MessageBox.Show("Регистрация прошла успешно!");
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    Close();
                }
            }
        }
    }
}
