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
    public class SongsNotInPLController : ControllerBase
    {
        private readonly SPA_DBContext _context;

        public SongsNotInPLController(SPA_DBContext context)
        {
            _context = context;
        }


        // GET: api/SongsNotInPL/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SongsWithArtists>>> GetPlaylist(int id)
        {
            //var artist_songs = await _context.Artists.FindAsync(id);

            List<int> inPL = (from a in _context.PlaylistSongLists
                              where a.PlaylistId == id
                              select a.SongId).ToList();

            var songs = from a in _context.Songs where !inPL.Contains(a.Id)
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
