using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalInterview_API.DataLayer.Context;
using TechnicalInterview_API.DataLayer.Models;

namespace TechnicalInterview_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DistrictsController : ControllerBase
    {
        private readonly DataContext _context;
        public DistrictsController(DataContext context) 
        { 
            _context = context; 
        }

        // Get all districts
        [HttpGet]
        public async Task<ActionResult<List<District>>> Get()
        {
            return await _context.Districts.ToListAsync();
        }
    }
}
