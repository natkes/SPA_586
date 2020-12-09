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
    public class PlaylistsWithSongsController : ControllerBase
    {
        private readonly SPA_DBContext _context;

        public PlaylistsWithSongsController(SPA_DBContext context)
        {
            _context = context;
        }

        // GET: api/PlaylistsWithSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistsWithSongs>>> GetPlaylistsWithSongs()
        {
            var Playlists_songs = from a in _context.Playlists
                                  let songs = (from b in _context.PlaylistSongLists where b.PlaylistId == a.Id select new SongsWithArtists
                                  {
                                      Id = b.Song.Id,
                                      Name = b.Song.Name,
                                      Artist_Name = b.Song.Artist.FirstName + (b.Song.Artist.LastName == null ? "" : " " + b.Song.Artist.LastName),
                                      Year = b.Song.YearCreated

                                  }).ToList()
                                  select new PlaylistsWithSongs
                                  {
                                      Id = a.Id,
                                      Name = a.Name,
                                      Songs = songs
                                };
            return await Playlists_songs.ToListAsync();
        }

        // GET: api/PlaylistsWithSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistsWithSongs>> GetPlaylist(int id)
        {
            //var artist_songs = await _context.Artists.FindAsync(id);

            var playlist_songs = from a in  _context.Playlists where id==a.Id
                                 let songs = (from b in _context.PlaylistSongLists
                                              where b.PlaylistId == a.Id
                                              select new SongsWithArtists
                                              {
                                                  Id = b.Song.Id,
                                                  Name = b.Song.Name,
                                                  Artist_Name = b.Song.Artist.FirstName + (b.Song.Artist.LastName == null ? "" : " " + b.Song.Artist.LastName),
                                                  Year = b.Song.YearCreated

                                              }).ToList()
                                 select new PlaylistsWithSongs
                                {
                                    Id = a.Id,
                                    Name = a.Name,
                                    Songs = songs
                                 };

            if (playlist_songs == null)
                return NotFound();

            PlaylistsWithSongs playlist = await playlist_songs.FirstAsync();
                
            return  playlist;
        }
   }
}
