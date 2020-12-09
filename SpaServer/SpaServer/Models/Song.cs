using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SpaServer.Models
{
    public partial class Song
    {
        public Song()
        {
            PlaylistSongLists = new HashSet<PlaylistSongList>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("ArtistID")]
        public int ArtistId { get; set; }
        public int YearCreated { get; set; }

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("Songs")]
        public virtual Artist Artist { get; set; }
        [InverseProperty(nameof(PlaylistSongList.Song))]
        public virtual ICollection<PlaylistSongList> PlaylistSongLists { get; set; }
    }
}
