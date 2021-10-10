using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballWebApi.Models;
using Microsoft.AspNetCore.Authorization;


namespace FootballWebApi.Controllers
{
    [Route("api/matches")]
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1", Deprecated = true)]
    [ApiVersion("2")]
    [Authorize]
    public partial class MatchesController : ControllerBase
    {

        // GET: api/matches
        [HttpGet]
        [MapToApiVersion("1")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            return await _context.Matches.ToListAsync();
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]
        [MapToApiVersion("1")]
        [AllowAnonymous]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }
    }
}
