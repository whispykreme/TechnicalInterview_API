using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalInterview_API.DataLayer.Context;
using TechnicalInterview_API.DataLayer.Models;

namespace TechnicalInterview_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> Get(string username, string password)
        {
            return await _context.Users.AnyAsync(credentials => credentials.Username.Equals(username) && credentials.Password.Equals(password));
        }
    }
}
