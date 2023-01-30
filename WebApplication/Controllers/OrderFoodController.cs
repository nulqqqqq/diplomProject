using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    public class OrderFoodController : Controller
    {
        UserContext db;
        public OrderFoodController(UserContext context)
        {
            db = context;
        }

        [HttpPost]
        [Route("OrderFood")]
        public async void  OrderFood()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string name = await reader.ReadToEndAsync();
            var order = JsonConvert.DeserializeObject<OrdersModel>(name);
            db.Orders.Add(order);
            MenuModel result = db.Menus.Where(m => m.FoodId == order.IdFood).FirstOrDefault();
            result.FoodCount--;
            db.SaveChanges();
        }
    }
}
