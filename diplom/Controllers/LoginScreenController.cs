using Microsoft.AspNetCore.Mvc;
using diplom.Models;
using Newtonsoft.Json;

namespace diplom.Controllers
{
    public class LoginScreenController : Controller
    {
        UserContext db;
        int IdIccount;
        public static string name;
        public LoginScreenController(UserContext context)
        {
            db = context;
        }

        [HttpPost]
        [Route("LoginScreen")]
        public async Task<int> LoginScreen()
        {
            using StreamReader reader = new StreamReader(HttpContext.Request.Body) ;
            string name = await reader.ReadToEndAsync();
            UserModel user = JsonConvert.DeserializeObject<UserModel>(name);
            foreach (var value in db.Users.ToList())
            {
                if (user.UserName == value.UserName && user.Password == value.Password)
                {
                    IdIccount = value.UserModelId;
                    name = value.UserName;
                }
            }
            return IdIccount;
         }
    }
}
