using Diplom.Domain.Core;
using DiplomServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiplomServer.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistration _registration;

        public RegistrationController(IRegistration registration)
        {
            _registration = registration;
        }

        [Route("Registration")]
        [HttpPost]
        public async Task<bool> Registration([FromBody] UserModel user)
        {
            return await _registration.Registration(user);
        }
    }
}
