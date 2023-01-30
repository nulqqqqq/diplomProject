using Diplom.Domain.Core;
using DiplomServer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DiplomServer.Services
{
    public class OrderFoodWindow : IOrderFood
    {
        string connectionString = "Server=VLADPC\\SQLEXPRESS;Database=DiplomProject;Trusted_Connection=True;TrustServerCertificate=True";
        UserContext db;
        public OrderFoodWindow(UserContext context)
        {
            db = context;
        }

        public async void OrderFood([FromBody] OrdersModel orders)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = orders;
                db.Orders.Add(query);
                MenuModel result = db.Menus.Where(m => m.FoodId == query.IdFood).FirstOrDefault();
                result.FoodCount--;
                db.SaveChanges();
            }
        }
    }
}
