using DVDWebAPI.Data.Interfaces;
using DVDWebAPI.Models;
using DVDWebAPI.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data.SampleData
{
    public class DVDRepositorySampleData : IDVDRepository
    {
        public static List<DVD> _DVDs = new List<DVD>
        {
            new DVD
                {DvdId=1, Title="A Great Tale", RealeaseYear=2015, Director="Sam Jones", Rating="PG", Notes="This really is a great tale!" },
            new DVD
                {DvdId=2, Title="A Good Tale", RealeaseYear=2012, Director="Joe Smith", Rating="PG-13", Notes="This is a good tale!" },
            new DVD
                {DvdId=3, Title="A Super Tale", RealeaseYear=2015, Director="Sam Jones", Rating="PG", Notes="A great remake!" },
            new DVD
                {DvdId=4, Title="A Super Tale", RealeaseYear=1985, Director="Joe Smith", Rating="PG", Notes="The original!" },
            new DVD
                {DvdId=5, Title="A Wonderful Tale", RealeaseYear=2015, Director="Joe Smith", Rating="PG-13", Notes="Wonderful, just wonderful!" },
            new DVD
                {DvdId=6, Title="Just A Tale", RealeaseYear=2015, Director="Joe Baker", Rating="PG", Notes="This is a tale!" },
            new DVD
                {DvdId=7, Title="To be edited"}
        };

        public void Add(DVD dvd)
        {
            dvd.DvdId = _DVDs.Max(d => d.DvdId) + 1;
            _DVDs.Add(dvd); ;
        }

        public void Delete(int dvdId)
        {
            _DVDs.RemoveAll(d => d.DvdId == dvdId);
        }

        public void Edit(DVD dvd)
        {
            {
                var found = _DVDs.FirstOrDefault(d => d.DvdId == dvd.DvdId);

                if (found != null)
                    found = dvd;
            }
        }

        public IEnumerable<DVD> GetAll()
        {
            {
                return _DVDs;
            }
        }

        public DVD GetById(int dvdId)
        {
            return _DVDs.FirstOrDefault(d => d.DvdId == dvdId); ;
        }

        public IEnumerable<DVD> Search(string searchCategory, string searchTerm)
        {
            switch (searchCategory)
            {
                case "title":
                    return _DVDs.Where(d => d.Title == searchTerm);
                case "year":
                    return _DVDs.Where(d => d.RealeaseYear.ToString() == searchTerm);
                case "director":
                    return _DVDs.Where(d => d.Director == searchTerm);
                case "rating":
                    return _DVDs.Where(d => d.Rating == searchTerm);
                default:
                    throw new Exception("Could not find valid search category.");
            }
        }
    }
}
