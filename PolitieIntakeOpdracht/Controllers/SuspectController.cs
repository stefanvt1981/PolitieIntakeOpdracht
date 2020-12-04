using Microsoft.AspNetCore.Mvc;
using PolitieIntakeOpdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolitieIntakeOpdracht.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuspectController : ControllerBase
    {
        public readonly SuspectContext _context;

        public SuspectController(SuspectContext context) => _context = context;

        [HttpGet]
        public IEnumerable<Suspect> Get() => _context.Suspects;            
        
        [HttpGet("{id}")]
        public ActionResult<Suspect> Get(long id)
        {
            var suspect = _context.Suspects.Where(s => s.Id == id).SingleOrDefault();
            if (suspect == null)
            {
                return NotFound();
            }
            return Ok(suspect);
        }

        [HttpPost]
        public ActionResult<Suspect> Post([FromBody] Suspect suspect)
        {
            _context.Suspects.Add(suspect);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = suspect.Id }, suspect);
        }

    }
}
