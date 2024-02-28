using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using bikebuddy.models;

namespace bikebuddy.api
{
    [ApiController]
    [Route("[controller]")]
    public class BikesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bikes = new BikeManager();
            var result = await bikes.GetBikesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Bike bike)
        {
            var bikes = new BikeManager();
            var result = await bikes.AddBikeAsync(bike);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Bike bike)
        {
            var bikes = new BikeManager();
            var result = await bikes.UpdateBikeAsync(bike);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var bikes = new BikeManager();
            var result = await bikes.DeleteBikeAsync(id);
            return Ok(result);
        }
    }

}
