using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WPFtextGUI.Model;

namespace MinAPI.Data
{
    public class StatsDb : DbContext // 
    {

        /// <summary>
        /// Kostruktor naší třídy, 
        /// </summary>
        /// <param name="options">Nastavení např connstring</param>
        public StatsDb(DbContextOptions<StatsDb> options) : base(options) { }

        /// <summary>
        /// DbSet<StatsResult> vrací tabulku
        /// </summary>
        public DbSet<StatsResult> StatsResults => Set<StatsResult>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //fluent api 
            //ukládání slovníku do databáze jako Json a převod zpět
            modelBuilder.Entity<StatsResult>()
                .Property(b => b.Top10Words)
                .HasConversion(
                   v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                   v => JsonSerializer.Deserialize<Dictionary<string, int>>(v, (JsonSerializerOptions)null));
        }

        //dependenci injection 

    }
}
