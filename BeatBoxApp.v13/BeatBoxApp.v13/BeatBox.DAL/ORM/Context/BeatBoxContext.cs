using BeatBox.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBox.DAL.ORM.Context
{
   public  class BeatBoxContext : DbContext
    {
        public BeatBoxContext()
        {

            Database.Connection.ConnectionString = @"Server=.;Database=DbBeatBox; User Id=sa; Password=1234;";
            //Database.Connection.ConnectionString = @"Server=DESKTOP-GGJ17V6\AKTASSERVER;Database=DbBeatBox;Trusted_Connection=True";
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Melodist> Melodists { get; set; }

        public DbSet<Singer> Singers { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<SongWriter> SongWriters { get; set; }

        public DbSet<WebUser> WebUsers{ get; set; }

        public DbSet<SongDetail> SongDetails { get; set; }

    }
}
