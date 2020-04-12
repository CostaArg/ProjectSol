using ProjectMusic.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMusic.Database
{
    public class MyDatabase : DbContext
    {
        public MyDatabase() : base("musicConnection")
        {

        }

        #region DATA TABLES

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        #endregion
    }
}
