using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YugiohApi.Models;

namespace YugiohApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YugiohCardsController : ControllerBase
    {
        private readonly YugiohContext _context;

        public YugiohCardsController(YugiohContext context)
        {
            _context = context;
        }

        // GET: api/YugiohCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YugiohCard>>> GetYugiohCards()
        {
            return await _context.YugiohCards.ToListAsync();
        }

        // GET: api/YugiohCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YugiohCard>> GetYugiohCard(Guid id)
        {
            var yugiohCard = await _context.YugiohCards.FindAsync(id);

            if (yugiohCard == null)
            {
                return NotFound();
            }

            return yugiohCard;
        }

        // PUT: api/YugiohCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYugiohCard(Guid id, YugiohCard yugiohCard)
        {
            if (id != yugiohCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(yugiohCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YugiohCardExists(id))
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

        // POST: api/YugiohCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YugiohCard>> PostYugiohCard(YugiohCard yugiohCard)
        {
            _context.YugiohCards.Add(yugiohCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetYugiohCard), new { id = yugiohCard.Id }, yugiohCard);
        }

        // DELETE: api/YugiohCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYugiohCard(Guid id)
        {
            var yugiohCard = await _context.YugiohCards.FindAsync(id);
            if (yugiohCard == null)
            {
                return NotFound();
            }

            _context.YugiohCards.Remove(yugiohCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YugiohCardExists(Guid id)
        {
            return _context.YugiohCards.Any(e => e.Id == id);
        }
    }
}
