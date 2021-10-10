using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballWebApi.Models;
using FootballWebApi.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using FootballWebApi.Data;
using AuthenticationPlugin;
using Microsoft.Extensions.Configuration;

namespace FootballWebApi.Controllers
{
    // Methods for V2
    public partial class MatchesController : ControllerBase
    {
        private readonly FootballAppContext _context;
        private readonly AuthService _auth;

        public MatchesController(FootballAppContext context, IConfiguration iconfiguration)
        {
            _context = context;
            _auth = new AuthService(iconfiguration);  // source: https://github.com/codewithasfend/Microsoft.AspNetCore.Authentication/wiki
        }


        // GET: api/matches
        [HttpGet]
        [MapToApiVersion("2")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatchesV2()
        {
            var matches = await _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.City)
                .ToListAsync();

            List<MatchDto> matchesDto = new();

            matchesDto.AddRange(matches.Select(x => new MatchDto()
                {
                    Id = x.Id,
                    Team1 = x.Team1.Name,
                    Team2 = x.Team2.Name,
                    Team1Score = x.Team1Score,
                    Team2Score = x.Team2Score,
                    WinnerTeam = x.WinnerTeam,
                    MatchKLocation = x.City.Location,
                    DateOfMatch = x.DateOfMatch.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
            }));


            return Ok(matchesDto);
        }

        // GET: api/matches/5
        [HttpGet("{id}")]
        [MapToApiVersion("2")]
        [AllowAnonymous]
        public async Task<ActionResult<MatchDto>> GetMatchV2(int id)
        {
            var match = await _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .Include(m => m.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (match == null)
            {
                return NotFound();
            }

            var matchDto = new MatchDto()
            {
                Id = match.Id,
                Team1 = match.Team1.Name,
                Team2 = match.Team2.Name,
                Team1Score = match.Team1Score,
                Team2Score = match.Team2Score,
                WinnerTeam = match.WinnerTeam,
                MatchKLocation = match.City.Location,
                DateOfMatch = match.DateOfMatch.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
            };
            
            return Ok(matchDto);
        }

        // POST: api/matches/addteam
        [HttpPost("addteam"), Authorize]
        [MapToApiVersion("2")]
        public async Task<ActionResult<TeamDto>> AddTeam([FromBody]Team newTeam)
        {

            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Name == newTeam.Name);
            if (team != null)
            {
                return Conflict("Team already exists");
            }

            await _context.Teams.AddAsync(newTeam);  
            await _context.SaveChangesAsync();

            var teamDto = new TeamDto() { Name = newTeam.Name };  

            return Created(nameof(AddTeam), teamDto);
        } 


        // POST: api/matches/postRandomMatch/{number}
        [HttpPost("addRandomMatches/{number:int}"), Authorize(Roles = "Admin")]
        [MapToApiVersion("2")]
        public async Task<ActionResult<List<MatchDto>>> AddRandomMatchesV2(int number)
        {
            List<MatchDto> matchesDto = new();

            for (int i = 0; i < number; i++)
            {
                var matchBuilder = new MatchBuilder(_context);
                var match = await matchBuilder.BuildMatch();

                var matchDto = new MatchDto()
                {
                    Id = match.Id,
                    Team1 = match.Team1.Name,
                    Team2 = match.Team2.Name,
                    MatchKLocation = match.City.Location,
                    Team1Score = match.Team1Score,
                    Team2Score = match.Team2Score,
                    WinnerTeam = match.WinnerTeam,
                    DateOfMatch = match.DateOfMatch.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                };

                matchesDto.Add(matchDto);
            }
            
            
            return Created("GetMatchV2", matchesDto);
        }


        // DELETE: api/matches/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> DeleteMatchV2(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            
            return Ok(new  { Type = "MatchObject", Id = match.Id,  Status = "deleted"});
        }


        // POST: api/matches/register
        [HttpPost("register"), AllowAnonymous]
        [MapToApiVersion("2")]
        public async Task<IActionResult> RegisterV2([FromBody] User userCredentials)  // [from body] auto-validating [Required]
        {

            bool userAlreadyExists = await _context.Users.AnyAsync(u => u.Username == userCredentials.Username);

            if (userAlreadyExists)
            {
                return Conflict("Username is busy.");
            }

            userCredentials.Password = PasswordHasher.Hash(userCredentials.Password);

            await _context.Users.AddAsync(userCredentials);
            await _context.SaveChangesAsync();

            var userDto = new UserDto()
            {
                Username = userCredentials.Username,
                Role = userCredentials.Role
            };

            return Created("register", userDto);
        }

        // POST: api/matches/getAuthToken

        [HttpPost("getAuthToken"), AllowAnonymous]
        [MapToApiVersion("2")]
        public async Task<IActionResult> GetAuthenticationTokenV2([FromBody] User userCredentials)  
        {

            User user = await _context.Users.FirstOrDefaultAsync(user => user.Username == userCredentials.Username);
            if (user == null)
            {
                return NotFound("Wrong username");
            }
            var hashedPassword = PasswordHasher.Hash(userCredentials.Password);

            if (user.Password != hashedPassword)
            {
                return Unauthorized("Wrong password");
            }

            var claims = new[]
           {
               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Name, user.Username),
               new Claim(ClaimTypes.Role,user.Role),
            };

            var token = _auth.GenerateAccessToken(claims);

            return Created("getAuthToken", new ObjectResult(new
            {
                access_token = "Bearer " + token.AccessToken,
                expires_in = (token.ExpiresIn / 60 / 60).ToString() + "hours",
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = user.Id,
            }));
        }

        

    }
}
