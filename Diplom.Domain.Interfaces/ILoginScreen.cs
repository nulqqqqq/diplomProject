using Microsoft.AspNetCore.Mvc;
using Diplom.Domain.Core;

namespace DiplomServer.Interfaces
{
    public interface ILoginScreen
    {
        [HttpPost]
        public Task<int> LoginScreen([FromBody] UserModel idUser);
    }
}
