/*using Microsoft.EntityFrameworkCore;
using DRental.Models;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Hosting;
using Humanizer;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Data;

namespace DRental.Data

{
    public class DVDRentalContext : DbContext
    {
        public DVDRentalContext(DbContextOptions<DVDRentalContext> options)
            : base(options)
        {
        }

        public DbSet<DRental.Models.Movie> Movies { get; set; } 
        public DbSet<DRental.Models.Genre> Genres { get; set; }
        public DbSet<DRental.Models.MovieGenre> MoviesGenres { get; set;}
        public DbSet<DRental.Models.Director> Directors { get; set; }
        public DbSet<DRental.Models.Member> Members { get; set; }
        public DbSet<DRental.Models.Item> Items { get; set; }   
        public DbSet<DRental.Models.Location> Locations { get; set; }
        public DbSet<DRental.Models.Stock> Stock { get; set; }
        public DbSet<DRental.Models.Order> Order { get; set; }
        public DbSet<DRental.Models.OrderDetail> OrderDetail { get; set; }
        public DbSet<DRental.Models.Invoice> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            *//*modelBuilder.Entity<Movie>()
                .ToTable("Movie")
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity<MovieGenre>(
                    l => l.HasOne<Movie>(mg => mg.Movies).WithMany(m => m.MovieGenres),
                    r => r.HasOne<Genre>(mg => mg.Genres).WithMany(g => g.MovieGenres));*//*
            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Genres)
                .WithMany(e => e.Movies)
                .UsingEntity<MovieGenre>(
                    l => l.HasOne<Genre>(e => e.Genres).WithMany(e => e.MovieGenres).HasForeignKey(e => e.GenreId),
                    r => r.HasOne<Movie>(e => e.Movies).WithMany(e => e.MovieGenres).HasForeignKey(e => e.MovieId));
            *//*CREATE TABLE "PostTag"(
            "PostId" INTEGER NOT NULL,
            "TagId" INTEGER NOT NULL,
            CONSTRAINT "PK_PostTag" PRIMARY KEY("PostId", "TagId"),
            CONSTRAINT "FK_PostTag_Posts_PostId" FOREIGN KEY("PostId") REFERENCES "Posts"("Id") ON DELETE CASCADE,
            CONSTRAINT "FK_PostTag_Tags_TagId" FOREIGN KEY("TagId") REFERENCES "Tags"("Id") ON DELETE CASCADE);*//*
            modelBuilder.Entity<Genre>()
            .ToTable("Genre")
                .HasMany(m => m.Movies)
                .WithMany(g => g.Genres);
            modelBuilder.Entity<MovieGenre>().ToTable("MovieGenre");
            modelBuilder.Entity<Director>()
                .ToTable("Director")
                .HasMany(e => e.Movies)
                .WithOne()
                .HasForeignKey(e => e.DirectorId);
            modelBuilder.Entity<Member>()
                .ToTable("Member")
                .HasOne<Location>()
                .WithMany(e => e.Members)
                .HasForeignKey(e => e.LocationId);
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<StockCount>().ToTable("StockCount");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Invoice>().ToTable("Invoice");

        }
    }
}
*/