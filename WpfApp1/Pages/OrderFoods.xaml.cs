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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderFoods.xaml
    /// </summary>
    public partial class OrderFoods : Page
    {
        public static int number;
        Windows.Check windowCheck;
        public string Path = @"D:\Андрей\(1)2 курс\ООП курсач\код\qwe\Delivery\WpfApp1\WpfApp1\Check.txt";
        public static bool proverka = false;
       
        UserContext db;
        Orders orders = new Orders();
        Menu menu = new Menu();

        public OrderFoods()
        {
            InitializeComponent();
            Lko();
        }

        private void Lko()
        {
            db = new UserContext();
            var item = db.restaurants.ToList();
            foreach (var it in item)
            {
                List.Items.Add(it.RestId);
                List2.Items.Add(it.RestName);
            }
            List2.IsEnabled = false;
            
            list2.IsEnabled = false;
            list6.IsEnabled = false;
            list3.IsEnabled = false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = db.menu.ToList();
            
            var lid = Convert.ToInt32(List.SelectedItem);
            
            foreach(var qw in item)
            {
                if(lid == qw.RestId)
                {
                    
                    list2.Items.Add(qw.FoodName);
                    
                    list3.Items.Add(qw.Price);
                    
                    list4.Items.Add(qw.FoodId);
                }
            }
            
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            orders.IdFood = Convert.ToInt32(list4.SelectedItem);
            orders.IdUser = Windows.UserMain.Id;

            var item = db.menu.ToList();
            var query = db.menu.ToList().Where(m => m.FoodId == orders.IdFood).FirstOrDefault();
            var lid = Convert.ToInt32(list4.SelectedItem);
            foreach (var qw in item)
            {
                
                if (lid == qw.FoodId)
                {
                    list5.Items.Add(qw.FoodId);
                    list6.Items.Add(query.Price);
                    break;
                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            orders = new Orders();
            var men = db.menu.ToList();
            if (proverka == false)
            {
                Windows.Payment payment = new Windows.Payment();
                payment.Show();



            }
            if(proverka == true) {
                for (int i = 0; i < list5.Items.Count; i++)
                {


                    if (string.IsNullOrWhiteSpace(adress.Text))
                    {

                        MessageBox.Show("Enter adress");
                        



                    }
                    else
                    {

                       
                        orders.NumberOrd = number;
                        orders.IdFood = Convert.ToInt32(list5.Items[i]);
                        orders.IdUser = Windows.UserMain.Id;
                        db.orders.Add(orders);
                        orders.Adress = adress.Text;
                        var qury = db.menu.ToList().Where(m => m.FoodId == orders.IdFood).First();
                        qury.FoodCount--;

                        db.SaveChanges();

                    }

                }

                using (var write = new StreamWriter(Path, false))
                {
                    double price = 0;
                    for (int a = 0; a < list5.Items.Count; a++)
                    {
                        orders.IdFood = Convert.ToInt32(list5.Items[a]);
                        var qiery = db.menu.ToList().Where(m => m.FoodId == orders.IdFood).First();
                        write.WriteLine($"You ordrered {qiery.FoodName} for {qiery.Price}");
                        price += qiery.Price;
                    }
                    write.WriteLine();
                    write.WriteLine($"Shipping adress: {adress.Text}");
                    write.WriteLine($"Order number {orders.NumberOrd}");
                    write.WriteLine($"The price for the entire order is: {price}");
                }
                number++;
            }
            list5.Items.Clear();
            list6.Items.Clear();
        }
        

        

        private void delete(object sender, RoutedEventArgs e)
        {
            
            var item = db.orders.ToList();
            var query = db.menu.ToList().Where(m => m.FoodId == orders.IdFood).FirstOrDefault();
            var lid = Convert.ToInt32(list5.SelectedItem);
            foreach (var qw in item)
            {

                if (lid == qw.IdFood)
                {
                    list5.Items.Remove(qw.IdFood);
                    list6.Items.Remove(query.Price);
                    break;
                }

            }

        }

        private void Chek_Click(object sender, RoutedEventArgs e)
        {
            if (proverka == true)
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
