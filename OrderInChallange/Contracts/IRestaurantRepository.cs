using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IRestaurantRepository :IRepositoryBase<Restaurant>
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }
}
