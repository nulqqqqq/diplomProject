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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminApp.xaml
    /// </summary>
    public partial class AdminApp : Window
    {
        UserContext db;
        AdminMenu adminMenu;
        public AdminApp()
        {
            InitializeComponent();
            
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            db = new UserContext();
            adminMenu = new AdminMenu();
            myDataGrid.ItemsSource = db.restaurants.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Restaurants rest = new Restaurants();
                rest.RestName = NameText.Text;
                db.restaurants.Add(rest);
                db.SaveChanges();
                myDataGrid.ItemsSource = db.restaurants.ToList();
                adminMenu.dataGrid.ItemsSource = db.restaurants.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(IdText.Text);
                var query = db.restaurants.Where(m => m.RestId == Id).FirstOrDefault();
                db.restaurants.Remove(query);
                db.SaveChanges();
                myDataGrid.ItemsSource = db.restaurants.ToList();
                adminMenu.dataGrid.ItemsSource = db.restaurants.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt32(IdText.Text);
                var query = db.restaurants.Where(m => m.RestId == Id).FirstOrDefault();
                query.RestName = NameText.Text;
                db.SaveChanges();
                myDataGrid.ItemsSource = db.restaurants.ToList();
                adminMenu.dataGrid.ItemsSource = db.restaurants.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == true)
                {
                    string src = file.FileName;
                    int Id = Convert.ToInt32(IdText.Text);
                    var query = db.restaurants.Where(m => m.RestId == Id).FirstOrDefault();
                    query.RestSourse = src;
                    db.SaveChanges();
                    myDataGrid.ItemsSource = db.restaurants.ToList();
                    adminMenu.dataGrid.ItemsSource = db.restaurants.ToList();

                }

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
