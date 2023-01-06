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
        private static readonly HttpClient client = new HttpClient();
        UserContext userDB;
        public Registration()
        {
            InitializeComponent();
            userDB = new UserContext();
            userDB.user.Load();
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


        private bool IsFoundAccount(string login)
        {
            foreach (var value in userDB.user.ToList())
            {
                if (login == value.UserName)
                    return true;
            }
            return false;
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (!IsCorrectValue(RegLogin.Text) || !IsCorrectValue(RegPassword.Password) ||
               !IsCorrectValue(Reg2Password.Password))
            {
                MessageBox.Show("Ошибка ввода");
            }
            else if (RegPassword.Password != Reg2Password.Password)
            {
                MessageBox.Show("Пароли не соответствуют друг другу");
            }
            else if (IsFoundAccount(RegLogin.Text))
            {
                MessageBox.Show("Аккаунт с таким логином уже существует");
            }
            else
            {
                MessageBox.Show("Регистрация прошла успешно");
                HttpClient httpClient = new HttpClient();
                User user1 = new User { UserName = RegLogin.Text, Password = RegPassword.Password };
                var json = JsonConvert.SerializeObject(user1);
                HttpContent data = new StringContent(json, Encoding.UTF8, "application/json");
                httpClient.PostAsync("https://localhost:7231/Registration", data);

                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
                Close();
            }
            

        }

       
    }
}
