using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CardGames
{
     class Context : DbContext
    {
        public DbSet<HighScore> DHighScore { get; set; }
        public DbSet<Player> DPlayer { get; set; }

        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                // Om webappen skapar en SamuraiContext så kommer inte detta köras
                // Detta är default. Körs alltså när du använda Update-Database eller från EfSamurai.App-projektet

                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CardGame; Trusted_Connection = True; ");
            }
            optionsBuilder.EnableSensitiveDataLogging();

        }

    }
}