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
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderFoods.xaml
    /// </summary>
    public partial class OrderFoods : Page
    {
        Dictionary<int, string> menuDictionary = new Dictionary<int, string>();
        Dictionary<int, string> restDictionary = new Dictionary<int, string>();

        public static int number = 1;
        Windows.Check windowCheck;
        public string Path = "Check.txt";
        public static bool checking = false;
       
        Orders orders = new Orders();
        Menu menu = new Menu();

        public OrderFoods()
        {
            InitializeComponent();
            Display_Restaurants();
        }

        private void Display_Restaurants()
        {
            var item = ServiceClass<string>.GetRequest("GetRestaurants").Result;
            foreach (var it in JsonConvert.DeserializeObject<IEnumerable<Restaurants>>(item))
            {
                restDictionary.Add(it.RestId, it.RestName);
                restNameList.Items.Add(it.RestName);
            }
        }

        private void Select_Food(object sender, RoutedEventArgs e)
        {

            orders.IdFood = menuDictionary.FirstOrDefault(x => x.Value == foodName.SelectedItem).Key;
            orders.IdUser = Windows.UserMain.Id;

            var item = ServiceClass<string>.GetRequest("GetMenu").Result;
            var menus = JsonConvert.DeserializeObject<IEnumerable<Menu>>(item);
            var query = menus.Where(m => m.FoodId == orders.IdFood).FirstOrDefault();

            foreach (var qw in menus)
            {
                if (orders.IdFood == qw.FoodId)
                {
                    CurrentOrder.Items.Add(menuDictionary[orders.IdFood]);
                    break;
                }
            }
        }
        private async void Accept_Order(object sender, RoutedEventArgs e)
        {
            orders = new Orders();
            var men = ServiceClass<string>.GetRequest("GetMenu").Result;

            if (checking == false)
            {
                Windows.Payment payment = new Windows.Payment();
                payment.Show();
            }

            if(checking == true) 
            {
                if (string.IsNullOrWhiteSpace(adress.Text))
                {
                    MessageBox.Show("Enter adress");
                }
                else
                {
                    for (int i = 0; i < CurrentOrder.Items.Count; i++)
                    {
                        orders.NumberOrd = number;
                        orders.IdFood = menuDictionary.FirstOrDefault(x => x.Value == CurrentOrder.Items[i]).Key;
                        orders.IdUser = Windows.UserMain.Id;
                        orders.Adress = adress.Text;
                        var item = ServiceClass<int>.GetRequest("GetMenu").Result;
                        var menus = JsonConvert.DeserializeObject<IEnumerable<Menu>>(item);
                        if (menus.Any(x => x.FoodId == orders.IdFood))
                        {
                            await ServiceClass<Orders>.PostRequest("OrderFood", orders);
                            number++;
                        }
                        else
                        {
                            MessageBox.Show($"{CurrentOrder.Items[i]} закончился");
                        }
                    }

                    using (var write = new StreamWriter(Path, false))
                    {
                        double price = 0;
                        for (int a = 0; a < CurrentOrder.Items.Count; a++)
                        {
                            orders.IdFood = menuDictionary.FirstOrDefault(x => x.Value == CurrentOrder.Items[a]).Key;
                            var item = ServiceClass<string>.GetRequest("GetMenu").Result;
                            var menus = JsonConvert.DeserializeObject<IEnumerable<Menu>>(item);
                            var qiery = menus.Where(m => m.FoodId == orders.IdFood).First();
                            write.WriteLine($"You ordrered {qiery.FoodName} for {qiery.Price}$");
                            price += qiery.Price;
                        }
                        write.WriteLine();
                        write.WriteLine($"Your adress: {adress.Text}");
                        write.WriteLine($"Order number {orders.NumberOrd}");
                        write.WriteLine($"The price for the entire order is: {price}$");
                    }
                    CurrentOrder.Items.Clear();
                    Thread.Sleep(1000);
                    if (checking == true)
                    {
                        using (var read = new StreamReader(Path))
                        {
                            var str = read.ReadToEnd();
                            windowCheck = new Windows.Check();
                            windowCheck.Show();
                            windowCheck.check.Text = str.ToString();
                        }
                    }
                }
            }
        }
        
        private void Delete(object sender, RoutedEventArgs e)
        {
            CurrentOrder.Items.Remove(CurrentOrder.SelectedItem);
        }

        private void restNameList_Selected(object sender, SelectionChangedEventArgs e)
        {
            foodName.Items.Clear();
            menuDictionary.Clear();
            var item = ServiceClass<string>.GetRequest("GetMenu").Result;
            var lid = restNameList.SelectedItem;
            string outParametr;

            foreach (var qw in JsonConvert.DeserializeObject<IEnumerable<Menu>>(item))
            {
                if (restDictionary.TryGetValue(qw.RestId, out outParametr))
                {
                    if (lid == outParametr)
                    {
                        menuDictionary.Add(qw.FoodId, $"{qw.FoodName} - {qw.Price}$");
                        foodName.Items.Add(menuDictionary[qw.FoodId]);
                    }
                }
                
            }
        }
    }
}
