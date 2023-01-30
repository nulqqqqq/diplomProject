using Microsoft.AspNetCore.Mvc;
using Diplom.Domain.Core;

namespace DiplomServer.Interfaces
{
    public interface IRegistration
    {
        public Task<bool> Registration([FromBody] UserModel user);
    }
}
