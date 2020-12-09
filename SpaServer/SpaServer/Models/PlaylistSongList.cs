using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SpaServer.Models
{
    [Table("PlaylistSongList")]
    public partial class PlaylistSongList
    {
        [Key]
        [Column("PlaylistID")]
        public int PlaylistId { get; set; }
        [Key]
        [Column("SongID")]
        public int SongId { get; set; }

        [ForeignKey(nameof(PlaylistId))]
        [InverseProperty("PlaylistSongLists")]
        public virtual Playlist Playlist { get; set; }
        [ForeignKey(nameof(SongId))]
        [InverseProperty("PlaylistSongLists")]
        public virtual Song Song { get; set; }
    }
}
