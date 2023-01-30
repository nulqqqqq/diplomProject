using Newtonsoft.Json;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public static string name;

        public LoginScreen()
        {
            InitializeComponent();
        }

        private async void Input_Click(object sender, RoutedEventArgs e)
        {
            User user = new User { UserName = Login.Text, Password = Password.Password};

            using (var httpclient = new HttpClient())
            {
                var request = await httpclient.PostAsJsonAsync("http://localhost:5253/LoginScreen", user);
                int result = await request.Content.ReadAsAsync<int>();
                if (!IsCorrectValue(Login.Text) || !IsCorrectValue(Password.Password))
                {
                    MessageBox.Show("Ошибка ввода");
                }
                else if (result == 0)
                {
                    MessageBox.Show("Не найден логин или пароль. Убедитесь в корректности введённых данных");
                }
                else
                {
                    if (result == 3)
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        Close();
                        MessageBox.Show($"Вы зашли как администратор");
                    }
                    else
                    {
                        UserMain userMain = new UserMain();
                        userMain.username.Text = user.UserName;
                        userMain.name.Text += user.UserName;
                        userMain.Show();
                        Close();
                        UserMain.Id = result;
                    }
                }
            }

            
        }

        private void Window_KeyDown(object sender, KeyEventArgs exitKey)
        {
            if (exitKey.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }

        private bool IsCorrectValue(string text)
        {
            string regex = @"^[а-яА-ЯёЁa-zA-Z0-9]{4,20}$";

            if (Regex.IsMatch(text, regex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Login_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
