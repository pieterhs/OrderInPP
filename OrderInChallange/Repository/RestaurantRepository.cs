using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            var categories = base.RepositoryContext.Categories.Include(c => c.MenuItems).ToList();
            var restaurants = base.RepositoryContext.Restaurants.Include(r => r.Categories).OrderBy(r => r.Rank).ToList();

            return restaurants;

            //return FindAll().OrderBy(re => re.Rank).ToList();
        }
    }




    /*
    public class RestaurantRepository : IRestaurantRepository
    {
        private static ConcurrentDictionary<int, Restaurant> _restaurants = new ConcurrentDictionary<int, Restaurant>();

        public RestaurantRepository()
        {
            List<Restaurant> restaurants;

            using (StreamReader reader = new StreamReader(@"D:\Documents\Google Drive\P&A\Pieter\CV\OrderIn\SampleData.json.js"))
            {
                string json = reader.ReadToEnd();

                restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            }

            foreach (Restaurant restaurant in restaurants)
            {
                _restaurants[restaurant.Id] = restaurant;
            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.Values;
        }

        public Restaurant Find(int key)
        {
            Restaurant restaurant;
            _restaurants.TryGetValue(key, out restaurant);
            return restaurant;
        }
    }*/
}
