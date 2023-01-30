using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        int idUser;
        public AdminMenu()
        {
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Menu foods = new Menu();
                foods.RestId = Convert.ToInt32(RestId.Text);
                foods.FoodName = NameFood.Text;
                foods.FoodCount = Convert.ToInt32(CountFood.Text);
                foods.Price = Convert.ToInt32(Price.Text);
                var request = await ServiceClass<Menu>.PostRequest("AddFood", foods);
                myDataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Menu>>(request);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            var request = ServiceClass<string>.GetRequest("GetMenu").Result;
            myDataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Menu>>(request);
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(IdFood.Text);

                if (string.IsNullOrEmpty(CountFood.Text))
                {
                    var request = await ServiceClass<int>.PostRequest("DeleteClick", Id);
                    myDataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Menu>>(request);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(IdFood.Text);
                int countFood = !string.IsNullOrEmpty(CountFood.Text) ? Convert.ToInt32(CountFood.Text) : 0;
                int priceFood = !string.IsNullOrEmpty(Price.Text) ? Convert.ToInt32(Price.Text) : 0;
                string nameFood = !string.IsNullOrEmpty(NameFood.Text) ? NameFood.Text : "";
                Menu menu = new Menu { FoodCount = countFood,Price = priceFood,FoodName = nameFood,FoodId = Id};
                var request = await ServiceClass<Menu>.PostRequest("UpdateMenu", menu);
                myDataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Menu>>(request);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void Window_KeyDown(object sender, KeyEventArgs exitKey)
        {
            if (exitKey.Key == Key.Escape)
            {
                Admin admin = new Admin();
                admin.Show();
                Close();
            }
        }
    }
}
