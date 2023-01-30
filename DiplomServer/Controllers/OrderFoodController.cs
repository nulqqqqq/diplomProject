using Microsoft.AspNetCore.Mvc;
using DiplomServer.Interfaces;
using Diplom.Domain.Core;

namespace DiplomServer.Controllers
{
    public class OrderFoodController : Controller
    {
        private readonly IOrderFood _orderFood;
        public OrderFoodController(IOrderFood orderFood)
        {
            _orderFood = orderFood;
        }

        [HttpPost]
        [Route("OrderFood")]
        public void OrderFood([FromBody] OrdersModel orders)
        {
           _orderFood.OrderFood(orders);
        }
    }
}
