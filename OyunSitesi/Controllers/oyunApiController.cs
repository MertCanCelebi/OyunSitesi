using Microsoft.AspNetCore.Mvc;
using OyunSitesi.VeriTabani;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<oyunApiController>
        [HttpGet]
        public IEnumerable<Oyun> Get()
        {
            return context.Oyunlar.ToList();
        }

        // GET api/<oyunApiController>/5
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

        // POST api/<oyunApiController>
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

        // PUT api/<oyunApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<oyunApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
