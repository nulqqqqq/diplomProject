using Microsoft.AspNetCore.Mvc;
using DiplomServer.Interfaces;
using Diplom.Domain.Core;

namespace DiplomServer.Controllers
{
    public class AdminAppController : Controller
    {
        private readonly IAdminApp _adminApp;
        public AdminAppController(IAdminApp adminApp)
        {
            _adminApp = adminApp;

        }

        [HttpPost]
        [Route("AddRestClick")]
        public async Task<IEnumerable<RestaurantsModel>> AddrestClick([FromBody] RestaurantsModel restName)
        {
            return await _adminApp.AddrestClick(restName);
        }

        [HttpGet]
        [Route("GetRestaurants")]
        public async Task<List<RestaurantsModel>> GetRestaurants()
        {
            return await _adminApp.GetRestaurants();
        }

        [HttpPost]
        [Route("DeleteRestaurant")]
        public async Task<IEnumerable<RestaurantsModel>> DeleteRestaurant([FromBody] int restId)
        {
            return await _adminApp.DeleteRestaurant(restId);
        }

        [HttpPost]
        [Route("AddImage")]
        public async Task<IEnumerable<RestaurantsModel>> AddImage([FromBody] RestaurantsModel restId)
        {
            return await _adminApp.AddImage(restId);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IEnumerable<RestaurantsModel>> Update([FromBody] RestaurantsModel restaurants)
        {
            return await _adminApp.Update(restaurants);
        }
    }
}
