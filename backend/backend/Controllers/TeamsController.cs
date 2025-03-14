using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private BowlerDbContext _context;
        public TeamsController(BowlerDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTeams")]
        public IEnumerable<Team> Get()
        {
            var teamList = _context.Teams
                .ToList();
            return teamList;
        }
    }
}
