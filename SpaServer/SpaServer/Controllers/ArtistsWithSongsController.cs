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
    public class ArtistsWithSongsController : ControllerBase
    {
        private readonly SPA_DBContext _context;

        public ArtistsWithSongsController(SPA_DBContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistsWithSongs>>> GetArtistsWithSongs()
        {
            var artists_songs = from a in _context.Artists
                                select new ArtistsWithSongs
                                {
                                    Id = a.Id,
                                    Name = a.FirstName + (a.LastName==null? "": " " + a.LastName),
                                    Songs = a.Songs.Select(b => b.Name).ToList()
                                };
            return await artists_songs.ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistsWithSongs>> GetArtist(int id)
        {
            //var artist_songs = await _context.Artists.FindAsync(id);

            var artist_songs = from a in _context.Artists where id==a.Id
                                select new ArtistsWithSongs
                                {
                                    Id = a.Id,
                                    Name = a.FirstName + (a.LastName == null ? "" : " " + a.LastName),
                                    Songs = a.Songs.Select(b => b.Name).ToList()
                                };

            if (artist_songs == null)
                return NotFound();

            ArtistsWithSongs artist = await artist_songs.FirstAsync();

            return artist;
        }

       
    }
}
