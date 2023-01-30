using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using DiplomServer.Interfaces;
using Microsoft.Data.SqlClient;
using Diplom.Domain.Core;

namespace DiplomServer.Controllers
{ 
    public class AdminMenuController : Controller
    {
        private readonly IAdminMenu _adminMenu;
        public AdminMenuController(IAdminMenu adminMenu)
        {
            _adminMenu = adminMenu;
        }

        [HttpPost]
        [Route("AddFood")]
        public async Task<IEnumerable<MenuModel>> AddFood([FromBody] MenuModel id)
        {
            return await _adminMenu.AddFood(id);
        }

        [HttpPost]
        [Route("DeleteFood")]
        public async Task<IEnumerable<MenuModel>> DeleteFood([FromBody] int id)
        {
            return await _adminMenu.DeleteFood(id);
        }

        [HttpPost]
        [Route("UpdateMenu")]
        public async Task<IEnumerable<MenuModel>> UpdateMenu([FromBody] MenuModel restaurants)
        {
            return await _adminMenu.UpdateMenu(restaurants);
        }

        [HttpGet]
        [Route("GetMenu")]
        public async Task<List<MenuModel>> GetMenu()
        {
            return await _adminMenu.GetMenu();
        }
    }
}
