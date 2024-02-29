using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechnicalInterview_API.DataLayer.Context;
using TechnicalInterview_API.DataLayer.Models;

namespace TechnicalInterview_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VoterActivityController
    {
        private readonly DataContext _context;

        public VoterActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VoterActivity?>> GetVoterById(int id)
        {
            return await _context.VoterActivities.FindAsync(id);
        }

        [HttpGet("Name")]
        public async Task<ActionResult<List<VoterActivity>>> GetVoterByName(string? FName, string? LName)
        {
            return await _context.VoterActivities
                .Where(voter => voter.FirstName.StartsWith(FName) || voter.LastName.StartsWith(LName))
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<VoterActivity>> PostVoter(VoterActivity voter)
        {
            _context.Add<VoterActivity>(voter);
            await _context.SaveChangesAsync();

            return voter;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVoter(VoterActivity voter)
        {
            EntityEntry<VoterActivity> updateVoter = _context.Attach<VoterActivity>(voter);
            updateVoter.State = EntityState.Modified;

            try
            { 
                await _context.SaveChangesAsync();
            }
            catch
            {
                return new BadRequestResult();
            }

            return new OkResult();
        }
    }
}
