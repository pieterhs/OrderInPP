using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderInTacoChallenge.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public RestaurantController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            try
            {
                var restaurants = _repository.Restaurant.GetAllRestaurants();

                _logger.LogInfo($"Returned all restaurants from database.");

                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllRestaurants action: {ex.Message}");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder(string[] content)
        {
            return Ok();
        }
    }
}
