using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
            
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GET() //El action Resulta permite que al presionar el botón salga la información
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GET(int id) //El action Resulta permite que al presionar el botón salga la información
        {
            var dbhero = await _context.SuperHeroes.FindAsync(id);
            if (dbhero == null)
                return BadRequest("Heroe no existe");
            return Ok(dbhero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero) //El action Resulta permite que al presionar el botón salga la información
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero (SuperHero request) //El action Resulta permite que al presionar el botón salga la información
        {
            var dbhero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbhero == null)
                return BadRequest("Heroe no existe");
            
            dbhero.Name = request.Name;
            dbhero.FirstName = request.FirstName;
            dbhero.LastName = request.LastName;
            dbhero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id) 
        {
            var dbhero = await _context.SuperHeroes.FindAsync(id);
            if (dbhero == null)
                return BadRequest("Heroe no existe");

            _context.SuperHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
