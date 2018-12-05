namespace DVDWebAPI.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDWebAPI.Models.EF.DVDLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDWebAPI.Models.EF.DVDLibraryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Rating.AddOrUpdate(
                r => r.RatingName,
                new EF.Rating { RatingName = "G" },
                new EF.Rating { RatingName = "PG" },
                new EF.Rating { RatingName = "PG-13" },
                new EF.Rating { RatingName = "R" },
                new EF.Rating { RatingName = "NC-17" }
                );

            context.Director.AddOrUpdate(
                dir => new { dir.DirectorFirstName, dir.DirectorLastName },
                new EF.Director { DirectorFirstName = "Sam", DirectorLastName = "Jones" },
                new EF.Director { DirectorFirstName = "Joe", DirectorLastName = "Smith" },
                new EF.Director { DirectorFirstName = "Joe", DirectorLastName = "Baker" }
                );

            context.SaveChanges();

            context.Dvd.AddOrUpdate(
                dvd => new { dvd.Title, dvd.RealeaseYear },
                new EF.Dvd
                {
                    Title = "A Great Tale",
                    RealeaseYear = 2015,
                    Notes = "This really is a great tale!",
                    DirectorId = context.Director.FirstOrDefault(d => d.DirectorFirstName == "Sam" && d.DirectorLastName == "Jones").DirectorID,
                    RatingId = context.Rating.FirstOrDefault(r => r.RatingName == "PG").RatingId
                },
                 new EF.Dvd
                 {
                     Title = "A Good Tale",
                     RealeaseYear = 2012,
                     Notes = "This is a good tale!",
                     DirectorId = context.Director.FirstOrDefault(d => d.DirectorFirstName == "Joe" && d.DirectorLastName == "Smith").DirectorID,
                     RatingId = context.Rating.FirstOrDefault(r => r.RatingName == "PG-13").RatingId
                 },
                  new EF.Dvd
                  {
                      Title = "A Super Tale",
                      RealeaseYear = 2015,
                      Notes = "A great remake!",
                      DirectorId = context.Director.FirstOrDefault(d => d.DirectorFirstName == "Sam" && d.DirectorLastName == "Jones").DirectorID,
                      RatingId = context.Rating.FirstOrDefault(r => r.RatingName == "PG").RatingId
                  },
                   new EF.Dvd
                   {
                       Title = "A Super Tale",
                       RealeaseYear = 1985,
                       Notes = "The original!",
                       DirectorId = context.Director.FirstOrDefault(d => d.DirectorFirstName == "Joe" && d.DirectorLastName == "Smith").DirectorID,
                       RatingId = context.Rating.FirstOrDefault(r => r.RatingName == "PG").RatingId
                   },
                    new EF.Dvd
                    {
                        Title = "A Wonderful Tale",
                        RealeaseYear = 2015,
                        Notes = "Wonderful, just wonderful!",
                        DirectorId = context.Director.FirstOrDefault(d => d.DirectorFirstName == "Joe" && d.DirectorLastName == "Smith").DirectorID,
                        RatingId = context.Rating.FirstOrDefault(r => r.RatingName == "PG-13").RatingId
                    },
                     new EF.Dvd
                     {
                         Title = "Just A Tale",
                         RealeaseYear = 2015,
                         Notes = "This is a tale!",
                         DirectorId = context.Director.FirstOrDefault(d => d.DirectorFirstName == "Joe" && d.DirectorLastName == "Baker").DirectorID,
                         RatingId = context.Rating.FirstOrDefault(r => r.RatingName == "PG").RatingId
                     } 
                     );
        }
    }
}
