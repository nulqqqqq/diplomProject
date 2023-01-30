using Microsoft.AspNetCore.Mvc;
using Diplom.Domain.Core;

namespace DiplomServer.Interfaces
{
    public interface IAdminMenu
    {
        [HttpPost]
        public Task<IEnumerable<MenuModel>> AddFood([FromBody] MenuModel id);
        [HttpPost]
        public Task<IEnumerable<MenuModel>> DeleteFood([FromBody] int id);
        [HttpPost]
        public Task<IEnumerable<MenuModel>> UpdateMenu([FromBody] MenuModel restaurants);
        [HttpGet]
        public Task<List<MenuModel>> GetMenu();
    }
}
