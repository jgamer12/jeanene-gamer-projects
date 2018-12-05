using DVDWebAPI.Data.EF;
using DVDWebAPI.Models.EF;
using DVDWebAPI.Models.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Tests.IntegrationTests
{
    [TestFixture]
    public class EFTests
    {
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public static void EFCanGetAllDVDs()
        {

            var repo = new DVDRepositoryEF();

            var dvds = repo.GetAll().ToList();

            Assert.AreEqual(6, dvds.Count);

            Assert.AreEqual(2, dvds[1].DvdId);
            Assert.AreEqual("A Good Tale", dvds[1].Title);
            Assert.AreEqual(2012, dvds[1].RealeaseYear);
            Assert.AreEqual("Joe Smith", dvds[1].Director);
            Assert.AreEqual("This is a good tale!", dvds[1].Notes);
        }

        [Test]
        public static void EFCanGetDVDById()
        {
            var repo = new DVDRepositoryEF();
            var dvd = new DVD();

            dvd = repo.GetById(1);

            Assert.IsNotNull(dvd);

            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("A Great Tale", dvd.Title);
            Assert.AreEqual(2015, dvd.RealeaseYear);
            Assert.AreEqual("Sam Jones", dvd.Director);
            Assert.AreEqual("This really is a great tale!", dvd.Notes);
        }

        [Test]
        public static void EFCanSearchDVDs()
        {
            var repo = new DVDRepositoryEF();
            var dvds = repo.Search("title", "A Super Tale").ToList();

            Assert.AreEqual(2, dvds.Count);

            dvds = repo.Search("year", "2015").ToList();

            Assert.AreEqual(4, dvds.Count);

            dvds = repo.Search("director", "Sam Jones").ToList();

            Assert.AreEqual(2, dvds.Count);

            dvds = repo.Search("rating", "PG").ToList();

            Assert.AreEqual(4, dvds.Count);
        }

        //[Test]
        //public static void EFCanGetDirector()
        //{
            //var repo = new DVDRepositoryEF();

            //var directorName = "Murphy";
            //var result = repo.GetDirectorId(directorName);
            //Assert.AreEqual(5, result);

            //directorName = "Ponce de Leon";
            //result = repo.GetDirectorId(directorName);
            //Assert.AreEqual(6, result);

            //directorName = "John Doe";
            //result = repo.GetDirectorId(directorName);
            //Assert.AreEqual(7, result);

            //var directorName = "Sam Jones";
            //var result = repo.GetDirectorId(directorName);
            //Assert.AreEqual(1, result);

            //directorName = "";
            //result = repo.GetDirectorId(directorName);
            //Assert.AreEqual(null, result);
        //}

        //[Test]
        //public static void EFCanAddAndDeleteDVD()
        //{
        //    var repo = new DVDRepositoryEF();
        //    var dvds = repo.GetAll().ToList();
        //    DVD dvdToAdd2 = new DVD();

        //    dvdToAdd2.Title = "A New Tale";
         //   dvdToAdd2.RealeaseYear = 2016;
         //   dvdToAdd2.Director = "Jack Jameson";
         //   dvdToAdd2.Rating = "PG-13";
         //   dvdToAdd2.Notes = "Brand new!";

        //    repo.Add(dvdToAdd2);
        //    dvds = repo.GetAll().ToList();
       //     var dvd = repo.GetById(7);

        //    Assert.IsNotNull(dvd);
        //    Assert.AreEqual(7, dvds.Count);

        //    Assert.AreEqual(7, dvd.DvdId);
        //    Assert.AreEqual("A New Tale", dvd.Title);
        //    Assert.AreEqual(2016, dvd.RealeaseYear);
        //    Assert.AreEqual("Jack Jameson", dvd.Director);
        //    Assert.AreEqual("PG-13", dvd.Rating);
       //     Assert.AreEqual("Brand new!", dvd.Notes);
       // }

        [Test]
        public static void EFCanEditDVD()
        {
            DVD dvdToEdit = new DVD();
            var repo = new DVDRepositoryEF();

            dvdToEdit.DvdId =31;
            dvdToEdit.Title = "2001:  A Space Odyssey";
            dvdToEdit.RealeaseYear = 1968;
            dvdToEdit.Director = "Stanley Kubrick";
            dvdToEdit.Rating = "G";
            dvdToEdit.Notes = "Classic sci-fi.";

            repo.Edit(dvdToEdit);
            var dvd = repo.GetById(31);

            Assert.AreEqual(31, dvd.DvdId);
            Assert.AreEqual("2001:  A Space Odyssey", dvd.Title);
            Assert.AreEqual(1968, dvd.RealeaseYear);
            Assert.AreEqual("Stanley Kubrick", dvd.Director);
            Assert.AreEqual("G", dvd.Rating);
            Assert.AreEqual("Classic sci-fi.", dvd.Notes);
        }
    }
}
