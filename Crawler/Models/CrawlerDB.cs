using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Crawler.Models
{
    public class CrawlerDB : DbContext
    {

        public CrawlerDB() : base("CrawlerDB") { }

        public DbSet<PostTwitter> PostTwitters { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}