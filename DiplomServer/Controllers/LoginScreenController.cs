using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using DiplomServer.Interfaces;
using Diplom.Domain.Core;

namespace DiplomServer.Controllers
{
    public class LoginScreenController : Controller
    {
        private readonly ILoginScreen _loginScreen;
        public LoginScreenController(ILoginScreen loginScreen)
        {
            _loginScreen = loginScreen;
        }


        [HttpPost]
        [Route("LoginScreen")]
        public async Task<int> LoginScreen([FromBody] UserModel idUser)
        {
            return await _loginScreen.LoginScreen(idUser);
        }
    }
}
