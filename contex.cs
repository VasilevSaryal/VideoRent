using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Videorent
{
    public class VideoContext : DbContext
    {

        public VideoContext()
            : base("Laptop")
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Disc> Discs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DiscFilms> DiscFilms { get; set; }
        public DbSet<FilmType> FilmTypes { get; set; }
        public DbSet<FilmGenres> FimsGenres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
