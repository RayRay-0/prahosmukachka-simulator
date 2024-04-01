using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceCleaner.API.Data;
using SpaceCleaner.API.Data.Entities;

namespace SpaceCleaner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkinsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SkinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Skins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skin>>> GetSkins()
        {
          if (_context.Skins == null)
          {
              return NotFound();
          }
            return await _context.Skins.ToListAsync();
        }

        // GET: api/Skins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skin>> GetSkin(int id)
        {
          if (_context.Skins == null)
          {
              return NotFound();
          }
            var skin = await _context.Skins.FindAsync(id);

            if (skin == null)
            {
                return NotFound();
            }

            return skin;
        }

        // PUT: api/Skins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkin(int id, Skin skin)
        {
            if (id != skin.Id)
            {
                return BadRequest();
            }

            _context.Entry(skin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkinExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Skins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skin>> PostSkin(Skin skin)
        {
          if (_context.Skins == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Skins'  is null.");
          }
            _context.Skins.Add(skin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkin", new { id = skin.Id }, skin);
        }

        // DELETE: api/Skins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkin(int id)
        {
            if (_context.Skins == null)
            {
                return NotFound();
            }
            var skin = await _context.Skins.FindAsync(id);
            if (skin == null)
            {
                return NotFound();
            }

            _context.Skins.Remove(skin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkinExists(int id)
        {
            return (_context.Skins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
