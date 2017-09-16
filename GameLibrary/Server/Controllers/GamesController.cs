using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        [HttpGet]
        public IEnumerable<Models.Game> GetAll()
        {
            return _context.Games.OrderBy(x => x.Name).ToList();
        }

        [Authorize]
        [HttpPost("GetByFilter")]
        public IEnumerable<Models.Game> GetAllByFilter([FromBody] Models.Game item)
        {
            return _context.Games.Where(x => (x.Name.Contains(item.Name) || String.IsNullOrEmpty(item.Name))
            && (x.Publisher.Contains(item.Publisher) || String.IsNullOrEmpty(item.Publisher))
            && (x.Category.Contains(item.Category) || String.IsNullOrEmpty(item.Category))
            )
                .OrderBy(x => x.Name).ToList();
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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