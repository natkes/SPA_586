using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaServer.Models;
using SpaServer.ViewModels;

namespace SpaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsWithArtistsController : ControllerBase
    {
        private readonly SPA_DBContext _context;

        public SongsWithArtistsController(SPA_DBContext context)
        {
            _context = context;
        }

        // GET: api/SongsWithArtists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongsWithArtists>>> GetSongs()
        {

            var songs = from a in _context.Songs
                        select new SongsWithArtists
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Artist_Name = a.Artist.FirstName + (a.Artist.LastName == null ? "" : " " + a.Artist.LastName),
                            Year = a.YearCreated
                        };
            
            return await songs.ToListAsync();
        }
}
}

