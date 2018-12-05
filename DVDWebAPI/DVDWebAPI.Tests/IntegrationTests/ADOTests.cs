using DVDWebAPI.Data;
using DVDWebAPI.Data.ADO;
using DVDWebAPI.Models.Queries;
using DVDWebAPI.Models.Requests;
using DVDWebAPI.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }


        [Test]
        public static void CanGetAllDVDsADO()
        {

            var repo = new DVDRepositoryADO();

            var dvds = repo.GetAll().ToList();

            Assert.AreEqual(7, dvds.Count);

            Assert.AreEqual(2, dvds[1].DvdId);
            Assert.AreEqual("A Good Tale", dvds[1].Title);
            Assert.AreEqual(2012, dvds[1].RealeaseYear);
            Assert.AreEqual("Joe Smith", dvds[1].Director);
            Assert.AreEqual("This is a good tale!", dvds[1].Notes);
        }

        [Test]
        public static void CanGetDVDByIdADO()
        {
            var repo = new DVDRepositoryADO();

            var dvd = repo.GetById(1);

            Assert.IsNotNull(dvd);

            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("A Great Tale", dvd.Title);
            Assert.AreEqual(2015, dvd.RealeaseYear);
            Assert.AreEqual("Sam Jones", dvd.Director);
            Assert.AreEqual("This really is a great tale!", dvd.Notes);
        }

        [Test]
        public static void CanSearchDVDsADO()
        {
            var repo = new DVDRepositoryADO();
            var dvds = repo.Search("title", "A Super Tale").ToList();

            Assert.AreEqual(2, dvds.Count);

            dvds = repo.Search("year", "2015").ToList();

            Assert.AreEqual(4, dvds.Count);

            dvds = repo.Search("director", "Sam Jones").ToList();

            Assert.AreEqual(2, dvds.Count);

            dvds = repo.Search("rating", "PG").ToList();

            Assert.AreEqual(4, dvds.Count);
        }

        [Test]
        public static void CanGetDirectorADO()
        {
            var repo = new DVDRepositoryADO();

            var directorName = "Murphy";
            var result = repo.GetDirectorId(directorName);
            Assert.AreEqual(4, result);

            directorName = "Ponce de Leon";
            result = repo.GetDirectorId(directorName);
            Assert.AreEqual(5, result);

            directorName = "John Doe";
            result = repo.GetDirectorId(directorName);
            Assert.AreEqual(6, result);

            directorName = "Sam Jones";
            result = repo.GetDirectorId(directorName);
            Assert.AreEqual(1, result);

            directorName = "";
            result = repo.GetDirectorId(directorName);
            Assert.AreEqual(null, result);
        }

        [Test]
        public static void CanGetRatingIdADO()
        {
            var repo = new DVDRepositoryADO();

            Assert.AreEqual(4, Helpers.GetRatingId("R"));
        }

        [Test]
        public static void CanAddAndDeleteDVDADO()
        {
            DVD dvdToAdd = new DVD();
            var repo = new DVDRepositoryADO();

            dvdToAdd.Title = "A Null Test";
            dvdToAdd.RealeaseYear = null;
            dvdToAdd.Director = null;
            dvdToAdd.Rating = null;
            dvdToAdd.Notes = null;

            repo.Add(dvdToAdd);
            var dvds = repo.GetAll().ToList();
            var dvd = repo.GetById(8);

            Assert.IsNotNull(dvd);
            Assert.AreEqual(8, dvds.Count);

            Assert.AreEqual(8, dvd.DvdId);
            Assert.AreEqual("A Null Test", dvd.Title);
            Assert.AreEqual(null, dvd.RealeaseYear);
            Assert.AreEqual("", dvd.Director);
            Assert.AreEqual("", dvd.Rating);
            Assert.AreEqual("", dvd.Notes);

            DVD dvdToAdd2 = new DVD();


            dvdToAdd2.Title = "A New Tale";
            dvdToAdd2.RealeaseYear = 2016;
            dvdToAdd2.Director = "Jack Jameson";
            dvdToAdd2.Rating = "PG-13";
            dvdToAdd2.Notes = "Brand new!";

            repo.Add(dvdToAdd2);
            dvds = repo.GetAll().ToList();
            dvd = repo.GetById(9);

            Assert.IsNotNull(dvd);
            Assert.AreEqual(9, dvds.Count);

            Assert.AreEqual(9, dvd.DvdId);
            Assert.AreEqual("A New Tale", dvd.Title);
            Assert.AreEqual(2016, dvd.RealeaseYear);
            Assert.AreEqual("Jack Jameson", dvd.Director);
            Assert.AreEqual("PG-13", dvd.Rating);
            Assert.AreEqual("Brand new!", dvd.Notes);

            repo.Delete(8);

            dvds = repo.GetAll().ToList();
            dvd = repo.GetById(8);
            Assert.IsNull(dvd);
            Assert.AreEqual(8, dvds.Count);

            repo.Delete(9);

            dvds = repo.GetAll().ToList();
            dvd = repo.GetById(9);
            Assert.IsNull(dvd);
            Assert.AreEqual(7, dvds.Count);

            repo.Delete(6);

            dvds = repo.GetAll().ToList();
            dvd = repo.GetById(6);
            Assert.IsNull(dvd);
            Assert.AreEqual(6, dvds.Count);
            Assert.AreEqual(5, repo.GetDirectorId("Joe Baker"));
        }

        [Test]
        public static void CanEditDVDADO()
        {
            DVD dvdToEdit = new DVD();
            var repo = new DVDRepositoryADO();

            dvdToEdit.DvdId = 7;
            dvdToEdit.Title = "2001:  A Space Odyssey";
            dvdToEdit.RealeaseYear = 1968;
            dvdToEdit.Director = "Stanley Kubrick";
            dvdToEdit.Rating = "G";
            dvdToEdit.Notes = "Classic sci-fi.";

            repo.Edit(dvdToEdit);
            var dvd = repo.GetById(7);

            Assert.AreEqual(7, dvd.DvdId);
            Assert.AreEqual("2001:  A Space Odyssey", dvd.Title);
            Assert.AreEqual(1968, dvd.RealeaseYear);
            Assert.AreEqual("Stanley Kubrick", dvd.Director);
            Assert.AreEqual("G", dvd.Rating);
            Assert.AreEqual("Classic sci-fi.", dvd.Notes);
        }
    }
}

