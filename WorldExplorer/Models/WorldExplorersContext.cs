using Microsoft.EntityFrameworkCore;

namespace WorldExplorer.Models
{
    public class WorldExplorersContext : DbContext
    {
        public WorldExplorersContext()
        {

        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=WorldExplorersWithMigrations;uid=root;pwd=root;");
        }

        public WorldExplorersContext(DbContextOptions<WorldExplorersContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
