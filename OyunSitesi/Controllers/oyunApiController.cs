using Microsoft.AspNetCore.Mvc;
using OyunSitesi.Models;

namespace OyunSitesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class oyunApiController : ControllerBase
    {
        private readonly DataBaseContext context;
        public oyunApiController(DataBaseContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IEnumerable<Oyun> Get()
        {
            return context.Oyunlar.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = context.Oyunlar.Where(p => p.Id == id).FirstOrDefault();
            if (game == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(game);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Oyun newGame)
        {
            var gameName = newGame != null ? newGame.OyunAd : "";
            if (newGame != null)
            {
                context.Oyunlar.Add(newGame);
                context.SaveChanges();
            }
            return Ok(gameName);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
