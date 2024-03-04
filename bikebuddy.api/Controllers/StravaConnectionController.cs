using Microsoft.AspNetCore.Mvc;

public namespace bikebuddy.api
{
    [ApiController]
    [Route("[controller]")]
    public class StravaConnectionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bikes = new BikeManager();
            var result = await bikes.GetBikesAsync();
            return Ok(result);
        }
    }
}