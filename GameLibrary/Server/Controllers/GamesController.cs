using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private readonly Database.DatabaseContext _context;

        public GamesController(Database.DatabaseContext context)
        {
            _context = context;

            if (_context.Games.Count() == 0)
            {
                _context.Games.Add(new Models.Game { Name = "Destiny 2", Publisher = "Bungie", Category = "FPS" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Models.Game> GetAll()
        {
            return _context.Games.ToList();
        }

        [HttpGet("{id}", Name = "GetGame")]
        public IActionResult GetById(long id)
        {
            var item = _context.Games.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.Game item)
        {
            if (item == null || String.IsNullOrEmpty(item.Name))
            {
                return BadRequest();
            }

            _context.Games.Add(item);
            _context.SaveChanges();
            
            return CreatedAtRoute("GetGame", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Models.Game item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var game = _context.Games.FirstOrDefault(t => t.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            game.Publisher = item.Publisher;
            game.Name = item.Name;
            game.Category = item.Category;

            _context.Games.Update(game);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var game = _context.Games.FirstOrDefault(t => t.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}