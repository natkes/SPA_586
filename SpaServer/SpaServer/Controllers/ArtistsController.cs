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
    public class ArtistsController : ControllerBase
    {
        private readonly SPA_DBContext _context;

        public ArtistsController(SPA_DBContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistsVM>>> GetArtists()
        {
            var artists = from a in _context.Artists
                          select new ArtistsVM
                          {
                              Id = a.Id,
                              Name = a.FirstName + (a.LastName == null ? "" : " " + a.LastName)

                          };

            return await artists.ToListAsync();
        }

       
    }
}
