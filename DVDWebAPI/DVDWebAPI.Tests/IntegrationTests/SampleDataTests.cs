using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DVDWebAPI.Data.SampleData;
using DVDWebAPI.Models.Queries;

namespace DVDWebAPI.Tests.IntegrationTests
{
    [TestFixture]
    public class SampleDataTests
    {
        [Test]
        public static void CanGetAllDVDs()
        {

            var repo = new DVDRepositorySampleData();

            var dvds = repo.GetAll().ToList();

            Assert.AreEqual(7, dvds.Count);

            Assert.AreEqual(2, dvds[1].DvdId);
            Assert.AreEqual("A Good Tale", dvds[1].Title);
            Assert.AreEqual(2012, dvds[1].RealeaseYear);
            Assert.AreEqual("Joe Smith", dvds[1].Director);
            Assert.AreEqual("This is a good tale!", dvds[1].Notes);
        }

        [Test]
        public static void CanGetDVDById()
        {
            var repo = new DVDRepositorySampleData();

            var dvd = repo.GetById(1);

            Assert.IsNotNull(dvd);

            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("A Great Tale", dvd.Title);
            Assert.AreEqual(2015, dvd.RealeaseYear);
            Assert.AreEqual("Sam Jones", dvd.Director);
            Assert.AreEqual("This really is a great tale!", dvd.Notes);
        }

        [Test]
        public static void CanAddAndDeleteDVD()
        {
            DVD dvdToAdd = new DVD();
            var repo = new DVDRepositorySampleData();

            dvdToAdd.Title = "A New Tale";
            dvdToAdd.RealeaseYear = 2016;
            dvdToAdd.Director = "Jack Jameson";
            dvdToAdd.Rating = "PG-13";
            dvdToAdd.Notes = "Brand spanking new";

            repo.Add(dvdToAdd);
            var dvds = repo.GetAll().ToList();
            var dvd = repo.GetById(8);

            Assert.IsNotNull(dvd);
            Assert.AreEqual(8, dvds.Count);

            Assert.AreEqual(8, dvd.DvdId);
            Assert.AreEqual("A New Tale", dvd.Title);
            Assert.AreEqual(2016, dvd.RealeaseYear);
            Assert.AreEqual("Jack Jameson", dvd.Director);
            Assert.AreEqual("PG-13", dvd.Rating);
            Assert.AreEqual("Brand spanking new", dvd.Notes);

            repo.Delete(8);

            dvds = repo.GetAll().ToList();
            dvd = repo.GetById(8);
            Assert.IsNull(dvd);
            Assert.AreEqual(7, dvds.Count);
        }

        [Test]
        public static void CanEditDVD()
        {

            var repo = new DVDRepositorySampleData();
            var dvdToEdit = repo.GetById(7);

            dvdToEdit.DvdId = 7;
            dvdToEdit.Title = "A New Tale";
            dvdToEdit.RealeaseYear = 2016;
            dvdToEdit.Director = "Jack Jameson";
            dvdToEdit.Rating = "PG-13";
            dvdToEdit.Notes = "Major revision!";

            repo.Edit(dvdToEdit);

            var dvds = repo.GetAll().ToList();
            var dvd = repo.GetById(7);

            Assert.IsNotNull(dvd);
            Assert.AreEqual(7, dvds.Count);

            Assert.AreEqual(7, dvd.DvdId);
            Assert.AreEqual("A New Tale", dvd.Title);
            Assert.AreEqual(2016, dvd.RealeaseYear);
            Assert.AreEqual("Jack Jameson", dvd.Director);
            Assert.AreEqual("PG-13", dvd.Rating);
            Assert.AreEqual("Major revision!", dvd.Notes);
        }

        [Test]
        public static void CanSelectDVDs()
        {
            var repo = new DVDRepositorySampleData();
            var dvds = repo.Search("title", "A Super Tale").ToList();

            Assert.AreEqual(2, dvds.Count);

            dvds = repo.Search("year", "2015").ToList();

            Assert.AreEqual(4, dvds.Count);

            dvds = repo.Search("director", "Sam Jones").ToList();

            Assert.AreEqual(2, dvds.Count);

            dvds = repo.Search("rating", "PG").ToList();

            Assert.AreEqual(4, dvds.Count);
        }
    }
}
