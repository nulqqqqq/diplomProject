using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;
using System.Net.Http;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminApp.xaml
    /// </summary>
    public partial class AdminApp : Window
    {
        
        AdminMenu adminMenu;
        public AdminApp()
        {
            InitializeComponent();
        }

        private async void Button_Loaded(object sender, RoutedEventArgs e)
        {
            adminMenu = new AdminMenu();
            var request = ServiceClass<string>.GetRequest("GetRestaurants").Result;
            myDataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(request);
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Restaurants rest = new Restaurants();
                rest.RestName = NameText.Text;
                var request = await ServiceClass<Restaurants>.PostRequest("AddRestClick", rest);
                myDataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(request);
                adminMenu.dataGrid.ItemsSource = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(IdText.Text);
                var result = await ServiceClass<int>.PostRequest("DeleteRestaurant", Id);
                var listOfRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(result);
                myDataGrid.ItemsSource = listOfRestaurants;
                adminMenu.dataGrid.ItemsSource = listOfRestaurants;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Restaurants restaurants = new Restaurants();
                restaurants.RestName = NameText.Text;
                restaurants.RestId = Convert.ToInt32(IdText.Text);
                var result = await ServiceClass<Restaurants>.PostRequest("Update", restaurants);
                var listOfRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(result);
                myDataGrid.ItemsSource = listOfRestaurants;
                adminMenu.dataGrid.ItemsSource = listOfRestaurants;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Select_Image_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == true)
                {
                    Restaurants restaurants = new Restaurants();
                    string fileName = file.FileName;
                    int Id = Convert.ToInt32(IdText.Text);
                    restaurants.RestSourse = fileName;
                    restaurants.RestId = Id;
                    var result = await ServiceClass<Restaurants>.PostRequest("AddImage",restaurants);
                    var listOfRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(result);
                    myDataGrid.ItemsSource = listOfRestaurants;
                    adminMenu.dataGrid.ItemsSource = listOfRestaurants;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
