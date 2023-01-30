using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    public class RegistrationController : Controller
    {
        UserContext db;
        public RegistrationController(UserContext context)
        {
            db = context;
        }

        [Route("Registration")]
        [HttpPost]
        public async Task<bool>  Registration()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body);
            string name = await reader.ReadToEndAsync();
            UserModel user = JsonConvert.DeserializeObject<UserModel>(name);
            int count = db.Users.Where(i => i.UserName == user.UserName).Count();
            if (count > 0)
            {
                return false;
            }
            else
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }         
        }
    }
}
