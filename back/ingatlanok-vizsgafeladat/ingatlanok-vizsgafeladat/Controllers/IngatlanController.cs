using ingatlanok_vizsgafeladat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ingatlanok_vizsgafeladat.Controllers
{
    [EnableCors]
    [Route("api/ingatlan")]
    [ApiController]
    public class IngatlanController : ControllerBase
    {
        IngatlanContext _context;
        public IngatlanController(IngatlanContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public IActionResult IngatlanList()
        {
            try
            {
                var ingatlanList = _context.Ingatlanoks.ToList();

                if (ingatlanList.Count() == 0)
                {
                    return NotFound("Ingatlan not found.");
                }
                return Ok(ingatlanList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("new")]

        public IActionResult newIngatlan([FromBody] Ingatlan ingatlan)
        {
            try
            {
                var newIngatlan = _context.Ingatlanoks.FromSqlInterpolated($"newIngatlan {ingatlan.Kategoria}, {ingatlan.Leiras}, {ingatlan.HirdetesDatuma}, {ingatlan.Tehermentes}, {ingatlan.Ar}, {ingatlan.KepUrl}").ToList();
                return Ok(newIngatlan);
            }
            catch (Exception e)
            {
                return StatusCode(404, e);
            }
        }

        [HttpDelete("delete")]

       public async Task<IActionResult> deleteIngatlan(int id)
        {
            var ingatlan = await _context.Ingatlanoks.FindAsync(id);
            if (ingatlan == null)
            {
                return BadRequest("A törlendő ingatlan nem létezik");
            }
            _context.Ingatlanoks.Remove(ingatlan);
            await _context.SaveChangesAsync();
            return Ok();

        }

        public class Ingatlan
        {
            public int Kategoria { get; set; }

            public string? Leiras { get; set; }

            public string? HirdetesDatuma { get; set; }

            public bool Tehermentes { get; set; }

            public int Ar { get; set; }

            public string? KepUrl { get; set; }

        }
    }
}
