using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public int id;
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Restaurant_Click(object sender, RoutedEventArgs e)
        {
            search2.Items.Clear();
            search1.Items.Clear();
            string str = restText.Text;
            var rest = ServiceClass<Restaurants>.GetRequest("GetRestaurants").Result;
            var men = ServiceClass<string>.GetRequest("GetMenu").Result;
            var menuDeserialized = JsonConvert.DeserializeObject<IEnumerable<Menu>>(men);
            foreach (var item in JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(rest))
            {
                if(item.RestName.IndexOf(str, StringComparison.OrdinalIgnoreCase)>=0)
                {
                    search1.Items.Add(item.RestName);
                    id = item.RestId;
                    var query = menuDeserialized.Where(m => m.RestId == id).ToList();
                    foreach (var items in query)
                    {
                        search2.Items.Add(items.FoodName);
                    }
                }
            }           
        }

        private void Search_Food_Click(object sender, RoutedEventArgs e)
        {
            search2.Items.Clear();
            search1.Items.Clear();
            string str = foodText.Text;
            var rest = ServiceClass<Restaurants>.GetRequest("GetRestaurants").Result;
            var men = JsonConvert.DeserializeObject<IEnumerable<Menu>>(rest);
            var menuDeserialized = ServiceClass<string>.GetRequest("GetMenu").Result;
            var restDeserialized = JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(rest);
            foreach (var item in men)
            {
                if (item.FoodName.IndexOf(str, StringComparison.OrdinalIgnoreCase) >=0)
                {
                    search1.Items.Add(item.FoodName);
                    id = item.RestId;
                    var query = restDeserialized.ToList().Where(m => m.RestId == id).ToList();
                    foreach (var items in query)
                    {
                        search2.Items.Add(items.RestName);
                    }
                }
            } 
        }
    }
}
