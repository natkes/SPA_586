using System.Collections.Generic;

#nullable disable

namespace SpaServer.ViewModels
{
    public class ArtistsWithSongs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Songs { get; set; }
    }
}
