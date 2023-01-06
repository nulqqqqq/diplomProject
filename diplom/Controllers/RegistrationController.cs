using diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace diplom.Controllers
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
        public IActionResult Registration(HttpContent user)
        {
            UserModel user1 = new UserModel { UserName = user.UserName, Password = user.Password };

            db.users.Add(user1);
            db.SaveChanges();
            return View();
        }
        


    }
}
