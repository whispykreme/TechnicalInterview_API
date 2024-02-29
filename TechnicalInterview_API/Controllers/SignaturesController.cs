using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using TechnicalInterview_API.DataLayer.Context;
using TechnicalInterview_API.DataLayer.Models;

namespace TechnicalInterview_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SignaturesController
    {
        private readonly DataContext _context;
        public SignaturesController(DataContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Gets the most recent Voter Signature by VoterId.
        /// </summary>
        /// <param name="id">VoterId</param>
        /// <returns><see cref="Signature"/></returns>
        [HttpGet("{id}")] // https://BaseAddress/signatures/id
        public async Task<ActionResult<Signature?>> GetByVoterId(int id)
        {
            // A voter can have multiple signatures in the database.
            // A voter signs for a ballot every time they receive a new one or spoil their old one. 
            if (await _context.Signatures.AnyAsync(signature => signature.VoterId == id))
            {
                return _context.Signatures
                    .Where(signature => signature.VoterId == id && signature.TimeStamp == _context.Signatures.Max(x => x.TimeStamp))
                    .FirstOrDefault();
            }

            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Signature>> PostSignature([FromBody] Signature signature)
        {            
            _context.Signatures.Add(signature);
            await _context.SaveChangesAsync();

            return signature;
        } 
    }
}
