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
        UserContext db;
        public Search()
        {
            InitializeComponent();
            db = new UserContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            search2.Items.Clear();
            search1.Items.Clear();
            string str = restText.Text;
            var rest = db.restaurants.ToList();
            var men = db.menu.ToList();
            foreach(var item in rest)
            {
                if(item.RestName.IndexOf(str, StringComparison.OrdinalIgnoreCase)>=0)
                {
                    search1.Items.Add(item.RestName);
                    id = item.RestId;
                    var query = db.menu.ToList().Where(m => m.RestId == id).ToList();
                    foreach (var items in query)
                    {
                        search2.Items.Add(items.FoodName);
                    }

                }
            }
            
            
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            search2.Items.Clear();
            search1.Items.Clear();
            string str = foodText.Text;
            var rest = db.restaurants.ToList();
            var men = db.menu.ToList();
            foreach(var item in men)
            {
                if (item.FoodName.IndexOf(str, StringComparison.OrdinalIgnoreCase) >=0)
                {
                    search1.Items.Add(item.FoodName);
                    id = item.RestId;
                    var query = db.restaurants.ToList().Where(m => m.RestId == id).ToList();
                    foreach (var items in query)
                    {
                        search2.Items.Add(items.RestName);
                    }
                }
            }
            
        }

        private void search2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
