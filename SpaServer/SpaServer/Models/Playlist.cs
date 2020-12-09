using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SpaServer.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistSongLists = new HashSet<PlaylistSongList>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(PlaylistSongList.Playlist))]
        public virtual ICollection<PlaylistSongList> PlaylistSongLists { get; set; }
    }
}