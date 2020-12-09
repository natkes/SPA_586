using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpaServer.Models
{
    public partial class SPA_DBContext : DbContext
    {
        public SPA_DBContext()
        {
        }

        public SPA_DBContext(DbContextOptions<SPA_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistSongList> PlaylistSongLists { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

 
            });

            modelBuilder.Entity<PlaylistSongList>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.SongId });

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistSongLists)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistSongLists_Playlists");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.PlaylistSongLists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlaylistSongLists_Songs");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Artists");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
