using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    public class AdminAppController : Controller
    {
        UserContext db;
        public AdminAppController(UserContext context)
        {
            db = context;
        }

        [HttpPost]
        [Route("AdminApp")]
        public async Task<List<RestaurantsModel>> AdminApp()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string nameRest = await reader.ReadToEndAsync();
            RestaurantsModel rest = JsonConvert.DeserializeObject<RestaurantsModel>(nameRest);
            db.Restaurants.Add(rest);
            db.SaveChanges();
            return db.Restaurants.ToList();
        }

        /*[HttpGet]
        [Route("GetRestaurants")]
        public async Task<List<RestaurantsModel>> GetRestaurants()
        {
            return db.Restaurants.ToList();
        }*/
        [HttpGet]
        [Route("GetRestaurants")]
        public string GetRestaurants()
        {
            return "test";
        }
        [HttpPost]
        [Route("DeleteRestaurant")]
        public async Task<List<RestaurantsModel>> DeleteRestaurant()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string  restId = await reader.ReadToEndAsync();
            int rest = JsonConvert.DeserializeObject<int>(restId);
            var query = db.Restaurants.Where(m => m.RestId == rest).FirstOrDefault();
            db.Restaurants.Remove(query);
            db.SaveChanges();
            return db.Restaurants.ToList(); 
        }

        [HttpPost]
        [Route("AddImage")]
        public async Task<List<RestaurantsModel>> AddImage()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string restId = await reader.ReadToEndAsync();
            var rest = JsonConvert.DeserializeObject<RestaurantsModel>(restId);
            var query = db.Restaurants.Where(m => m.RestId == rest.RestId).FirstOrDefault();
            query.RestSourse = rest.RestSourse;
            db.SaveChanges();
            return db.Restaurants.ToList();
        }
        [HttpPost]
        [Route("Update")]
        public async Task<List<RestaurantsModel>> Update(int restaurants)
        {
            int qwe = restaurants;
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string restId = await reader.ReadToEndAsync();
            var rest = JsonConvert.DeserializeObject<RestaurantsModel>(restId);
            var query = db.Restaurants.Where(m => m.RestId == rest.RestId).FirstOrDefault();
            query.RestName = rest.RestName;
            db.SaveChanges();
            return db.Restaurants.ToList();
        }
    }
}
