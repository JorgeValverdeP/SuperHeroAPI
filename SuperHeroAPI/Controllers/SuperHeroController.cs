using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GET() //El action Resulta permite que al presionar el botón salga la información
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id=1,
                    Name="Capitan America",
                    FirstName="Steve",
                    LastName="Rogers",
                    Place="Brooklyn"
                 }
            };
            return Ok(heroes);
        }
    }
}
