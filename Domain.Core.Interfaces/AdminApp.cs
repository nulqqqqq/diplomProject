using DiplomServer.Interfaces;
using DiplomServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DiplomServer.Services
{
    public class AdminApp : IAdminApp
    {
        UserContext db;
        string connectionString = "Server=VLADPC\\SQLEXPRESS;Database=DiplomProject;Trusted_Connection=True;TrustServerCertificate=True";

        public AdminApp(UserContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<RestaurantsModel>> AddrestClick([FromBody] RestaurantsModel restName)
        {
            var nameRest = restName;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                db.Restaurants.Add(nameRest);
                db.SaveChanges();
                connection.Close();
                return db.Restaurants.ToList();
            }
        }

        public async Task<List<RestaurantsModel>> GetRestaurants()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return db.Restaurants.ToList();
            }
        }

        public async Task<IEnumerable<RestaurantsModel>> DeleteRestaurant([FromBody] int restId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int rest = restId;
                var query = db.Restaurants.Where(m => m.RestId == rest).FirstOrDefault();
                db.Restaurants.Remove(query);
                db.SaveChanges();
                return db.Restaurants.ToList();
            }
        }

        public async Task<IEnumerable<RestaurantsModel>> AddImage([FromBody] RestaurantsModel restId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var idrest = restId;
                var query = db.Restaurants.Where(m => m.RestId == idrest.RestId).FirstOrDefault();
                query.RestSourse = idrest.RestSourse;
                db.SaveChanges();
                return db.Restaurants.ToList();
            }
        }

        public async Task<IEnumerable<RestaurantsModel>> Update([FromBody] RestaurantsModel restaurants)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var qwe = restaurants;
                var query = db.Restaurants.Where(m => m.RestId == qwe.RestId).FirstOrDefault();
                query.RestName = qwe.RestName;
                db.SaveChanges();
                return db.Restaurants.ToList();
            }
        }
    }
}
