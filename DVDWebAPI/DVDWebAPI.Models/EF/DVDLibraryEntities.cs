using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Models.EF
{
    public class DVDLibraryEntities : DbContext
    {
        public DVDLibraryEntities() : base("DefaultConnection")
        {
        }

        public DbSet<Dvd> Dvd { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Rating> Rating { get; set; }
    }
}
