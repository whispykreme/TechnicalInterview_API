using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalInterview_API.DataLayer.Context;
using TechnicalInterview_API.DataLayer.Models;

namespace TechnicalInterview_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StatusesController
    {
        private readonly DataContext _context;
        public StatusesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Status>>> Get()
        {
            return await _context.Statuses.ToListAsync();
        }
    }
}
