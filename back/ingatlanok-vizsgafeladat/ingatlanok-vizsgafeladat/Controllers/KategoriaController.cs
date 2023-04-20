using ingatlanok_vizsgafeladat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ingatlanok_vizsgafeladat.Controllers
{
    [EnableCors]
    [Route("api/kategoria")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        IngatlanContext _context;

        public KategoriaController(IngatlanContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public IActionResult KategoriaList()
        {
            try
            {
                var kategoriaList = _context.Kategoriaks.ToList();

                if (kategoriaList.Count() == 0)
                {
                    return NotFound("Kategoria not found.");
                }
                return Ok(kategoriaList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    
    }
}
