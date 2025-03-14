using backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private BowlerDbContext _context;
        public BowlersController(BowlerDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBowlers")]
        public IEnumerable<Bowler> Get()
        {
            var bowlerList = _context.Bowlers
                .Select(b => new Bowler
                {
                    BowlerID = b.BowlerID,
                    BowlerLastName = b.BowlerLastName,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerMiddleInit = b.BowlerMiddleInit ?? "",
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity ?? "Unknown", // Handle NULL values
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber,
                    TeamID = b.TeamID
                })
                .Where(t => t.TeamID == 1 || t.TeamID == 2) // Filter by TeamID
                .ToList();
            return bowlerList;
        }

    }
}
