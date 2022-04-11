using GameLibrary.Data.Configuration;
using GameLibrary.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Data
{
    public class Context : DbContext
    {
        public DbSet<Game> Game => this.Set<Game>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GameConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=games.sqlite");
        }
    }
}