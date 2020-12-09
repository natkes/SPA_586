using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaServer.Models;

namespace SpaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistSongListsController : ControllerBase
    {
        private readonly SPA_DBContext _context;

        public PlaylistSongListsController(SPA_DBContext context)
        {
            _context = context;
        }

        // GET: api/PlaylistSongLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistSongList>>> GetPlaylistSongLists()
        {
            return await _context.PlaylistSongLists.ToListAsync();
        }

        // GET: api/PlaylistSongLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistSongList>> GetPlaylistSongList(int id)
        {
            var playlistSongList = await _context.PlaylistSongLists.FindAsync(id);

            if (playlistSongList == null)
            {
                return NotFound();
            }

            return playlistSongList;
        }

        // PUT: api/PlaylistSongLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistSongList(int id, PlaylistSongList playlistSongList)
        {
            if (id != playlistSongList.PlaylistId)
            {
                return BadRequest();
            }

            _context.Entry(playlistSongList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistSongListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlaylistSongLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlaylistSongList>> PostPlaylistSongList(PlaylistSongList playlistSongList)
        {
            _context.PlaylistSongLists.Add(playlistSongList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlaylistSongListExists(playlistSongList.PlaylistId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlaylistSongList", new { id = playlistSongList.PlaylistId }, playlistSongList);
        }

        // DELETE: api/PlaylistSongLists/5
        [HttpDelete("{PLID}/{SONGID}")]
        public async Task<ActionResult<PlaylistSongList>> DeletePlaylistSongList(int PLID, int SONGID)
        {
            var playlistSongList = (from a in _context.PlaylistSongLists
                                    where a.PlaylistId == PLID && a.SongId == SONGID
                                    select a).ToArray();
            if (playlistSongList == null)
            {
                return NotFound();
            }

            _context.PlaylistSongLists.Remove(playlistSongList.First());
            await _context.SaveChangesAsync();

            return playlistSongList.First();
        }

        private bool PlaylistSongListExists(int id)
        {
            return _context.PlaylistSongLists.Any(e => e.PlaylistId == id);
        }
    }
}
