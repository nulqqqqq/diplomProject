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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        UserContext db;
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Menu foods = new Menu();
                foods.RestId = Convert.ToInt32(RestId.Text);
                foods.FoodName = NameFood.Text;
                foods.FoodCount = Convert.ToInt32(CountFood.Text);
                foods.Price = Convert.ToInt32(Price.Text);
                db.menu.Add(foods);
                db.SaveChanges();
                myDataGrid.ItemsSource = db.menu.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            db = new UserContext();
            myDataGrid.ItemsSource = db.menu.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(IdFood.Text);
                var query = db.menu.Where(m => m.FoodId == Id).FirstOrDefault();
                if (string.IsNullOrEmpty(CountFood.Text))
                {
                    db.menu.Remove(query);
                }
                else
                {
                    query.FoodCount -= Convert.ToInt32(CountFood.Text);
                }

                db.SaveChanges();
                myDataGrid.ItemsSource = db.menu.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(IdFood.Text);
                var query = db.menu.Where(m => m.FoodId == Id).FirstOrDefault();
                if (string.IsNullOrEmpty(CountFood.Text) && string.IsNullOrEmpty(Price.Text))
                {
                    query.FoodName = NameFood.Text;
                }
                else if (string.IsNullOrEmpty(NameFood.Text) && string.IsNullOrEmpty(Price.Text))
                {

                    query.FoodCount = Convert.ToInt32(CountFood.Text);
                }
                else if (string.IsNullOrEmpty(CountFood.Text) && string.IsNullOrEmpty(NameFood.Text))
                {
                    query.Price = Convert.ToInt32(Price.Text);
                }
                else if (string.IsNullOrEmpty(CountFood.Text))
                {
                    query.FoodName = NameFood.Text;
                    query.Price = Convert.ToInt32(Price.Text);
                }
                else if (string.IsNullOrEmpty(NameFood.Text))
                {
                    query.FoodCount = Convert.ToInt32(CountFood.Text);
                    query.Price = Convert.ToInt32(Price.Text);
                }
                else if (string.IsNullOrEmpty(Price.Text))
                {
                    query.FoodName = NameFood.Text;
                    query.FoodCount = Convert.ToInt32(CountFood.Text);
                }
                else
                {
                    query.FoodName = NameFood.Text;
                    query.FoodCount = Convert.ToInt32(CountFood.Text);
                    query.Price = Convert.ToInt32(Price.Text);
                }
                db.SaveChanges();
                myDataGrid.ItemsSource = db.menu.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Admin admin = new Admin();
                admin.Show();
                Close();
            }
        }
    }
}
