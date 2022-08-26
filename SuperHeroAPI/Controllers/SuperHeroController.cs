using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>

            {
               new SuperHero {
               Id = 1,
               Name = "Capitan America",
               FirstName = "Steve",
               LastName = "Rogers",
               Place = "Brooklyn"
               },
                  new SuperHero {
               Id = 2,
               Name = "Iron Man",
               FirstName = "Tony",
               LastName = "Stark",
               Place = "Long Island"
               }
            };



        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GET() //El action Resulta permite que al presionar el botón salga la información
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GET(int id) //El action Resulta permite que al presionar el botón salga la información
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Heroe no existe");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero) //El action Resulta permite que al presionar el botón salga la información
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero (SuperHero request) //El action Resulta permite que al presionar el botón salga la información
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Heroe no existe");
            
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            return Ok(heroes);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id) 
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
                return BadRequest("Heroe no existe");
                heroes.Remove(hero);

            return Ok(hero);
        }
    }
}
