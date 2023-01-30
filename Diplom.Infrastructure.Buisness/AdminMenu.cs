using Diplom.Domain.Core;
using DiplomServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace DiplomServer.Services
{
    public class AdminMenu : IAdminMenu
    {
        UserContext db;
        string connectionString = "Server=VLADPC\\SQLEXPRESS;Database=DiplomProject;Trusted_Connection=True;TrustServerCertificate=True";
        public AdminMenu(UserContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<MenuModel>> AddFood([FromBody] MenuModel id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var idfood = id;
                db.Menus.Add(idfood);
                db.SaveChanges();
                return db.Menus.ToList();
            }
        }

        public async Task<IEnumerable<MenuModel>> DeleteFood([FromBody] int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var foodId = id;
                MenuModel query = db.Menus.Where(m => m.FoodId == foodId).FirstOrDefault();
                db.Menus.Remove(query);
                db.SaveChanges();
                return db.Menus.ToList();
            }
        }

        public async Task<IEnumerable<MenuModel>> UpdateMenu([FromBody] MenuModel restaurants)
        {
            var valueRestaurant = restaurants;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                MenuModel query = db.Menus.Where(m => m.FoodId == valueRestaurant.FoodId).FirstOrDefault();
                if (query.FoodName != valueRestaurant.FoodName && valueRestaurant.FoodName != "")
                {
                    query.FoodName = valueRestaurant.FoodName;

                }
                if (query.FoodCount != valueRestaurant.FoodCount && valueRestaurant.FoodCount != 0)
                {
                    query.FoodCount = valueRestaurant.FoodCount;
                }
                if (query.Price != valueRestaurant.Price && valueRestaurant.Price != 0)
                {
                    query.Price = valueRestaurant.Price;
                }
                db.Update(query);
                db.SaveChanges();
                return db.Menus.ToList();
            }
        }

        [HttpGet]
        [Route("GetMenu")]
        public async Task<List<MenuModel>> GetMenu()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return db.Menus.Where(x => x.FoodCount > 0).ToList();
            }
        }
    }
}
