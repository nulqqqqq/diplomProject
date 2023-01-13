using Microsoft.AspNetCore.Mvc;
using diplom.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace diplom.Controllers
{ 
    public class AdminMenuController : Controller
    {
        UserContext db;
        public AdminMenuController(UserContext context)
        {
            db = context;
        }
        
        [HttpPost]
        [Route("AddClick")] 
        public async Task<List<MenuModel>> AddClick()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string food = await reader.ReadToEndAsync();
            MenuModel menu = JsonConvert.DeserializeObject<MenuModel>(food);
            db.Menus.Add(menu);
            db.SaveChanges();
            return db.Menus.ToList();
        }
        [HttpPost]
        [Route("DeleteClick")]
        public async Task<List<MenuModel>> Deleteclick()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string food = await reader.ReadToEndAsync();
            int menu = JsonConvert.DeserializeObject<int>(food);
            MenuModel query = db.Menus.Where(m => m.FoodId == menu).FirstOrDefault();
            db.Menus.Remove(query);
            db.SaveChanges();
            return db.Menus.ToList();
        }
        [HttpPost]
        [Route("UpdateMenu")]
        public async Task<List<MenuModel>> UpdateMenu()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string food = await reader.ReadToEndAsync();
            MenuModel menu = JsonConvert.DeserializeObject<MenuModel>(food);
            MenuModel query = db.Menus.Where(m => m.FoodId == menu.FoodId).FirstOrDefault();
            if (query.FoodName != menu.FoodName && menu.FoodName != "")
            {
                query.FoodName = menu.FoodName;

            }
            if (query.FoodCount != menu.FoodCount && menu.FoodCount != 0)
            {
                query.FoodCount = menu.FoodCount;
            }
            if (query.Price != menu.Price && menu.Price != 0)
            {
                query.Price = menu.Price;
            }
            db.Update(query);
            db.SaveChanges();
            return db.Menus.ToList();
        }

        [HttpGet]
        [Route("GetMenu")]
        public async Task<List<MenuModel>> GetMenu()
        {
            return db.Menus.Where(x => x.FoodCount > 0).ToList();
        }
    }
}
