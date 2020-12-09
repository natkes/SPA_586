using System.Collections.Generic;

#nullable disable

namespace SpaServer.ViewModels
{
    public class PlaylistsWithSongs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SongsWithArtists> Songs { get; set; }
    }
}
