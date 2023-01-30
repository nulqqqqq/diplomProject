using Diplom.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace DiplomServer.Interfaces
{
    public interface IAdminApp
    {
        public Task<IEnumerable<RestaurantsModel>> AddrestClick([FromBody] RestaurantsModel restName);
        public  Task<List<RestaurantsModel>> GetRestaurants();
        public Task<IEnumerable<RestaurantsModel>> DeleteRestaurant([FromBody] int restId);
        public Task<IEnumerable<RestaurantsModel>> AddImage([FromBody] RestaurantsModel restId);
        public Task<IEnumerable<RestaurantsModel>> Update([FromBody] RestaurantsModel restaurants);
    }
}
