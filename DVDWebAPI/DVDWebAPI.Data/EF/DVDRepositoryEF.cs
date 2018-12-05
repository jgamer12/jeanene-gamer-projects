using DVDWebAPI.Data.Interfaces;
using DVDWebAPI.Models.EF;
using DVDWebAPI.Models.Queries;
using DVDWebAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data.EF
{
    public class DVDRepositoryEF : IDVDRepository
    {
        public void Add(DVD dvd)
        {
            var repository = new DVDLibraryEntities();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.Title = dvd.Title;
            dvdToAdd.RealeaseYear = dvd.RealeaseYear;
            dvdToAdd.Notes = dvd.Notes;

            int? ratingId = Helpers.GetRatingId(dvd.Rating);
            if (ratingId == null)
                dvdToAdd.RatingId = null;
            else
                dvdToAdd.RatingId = ratingId;

            int? directorId = GetDirectorId(dvd.Director);
            if (directorId == null)
                dvdToAdd.DirectorId = null;
            else
                dvdToAdd.DirectorId = directorId;

            repository.Dvd.Add(dvdToAdd);
            repository.SaveChanges();

            dvd.DvdId = dvdToAdd.DvdId;
        }

        public void Delete(int dvdId)
        {
            var repository = new DVDLibraryEntities();

            string director = GetById(dvdId).Director;

            var dvd = repository.Dvd.FirstOrDefault(d => d.DvdId == dvdId);

            if (dvd != null)
            {
                repository.Dvd.Remove(dvd);
                repository.SaveChanges();
            }

            if (!string.IsNullOrEmpty(director))
                DirectorTableCleanUp(director);
        }

        public void Edit(DVD dvd)
        {
            var repository = new DVDLibraryEntities();
            Dvd dvdToEdit = new Dvd();

            dvdToEdit.DvdId = dvd.DvdId;
            dvdToEdit.Title = dvd.Title;
            dvdToEdit.RealeaseYear = dvd.RealeaseYear;
            dvdToEdit.Notes = dvd.Notes;

            int? ratingId = Helpers.GetRatingId(dvd.Rating);
            if (ratingId == null)
                dvdToEdit.RatingId = null;
            else
                dvdToEdit.RatingId = ratingId;

            int? directorId = GetDirectorId(dvd.Director);
            if (directorId == null)
                dvdToEdit.DirectorId = null;
            else
                dvdToEdit.DirectorId = directorId;

            repository.Entry(dvdToEdit).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();

            if (!string.IsNullOrEmpty(dvd.Director))
                DirectorTableCleanUp(dvd.Director);

        }

        public IEnumerable<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();

            var repository = new DVDLibraryEntities();

            var list = from dvd in repository.Dvd
                       select new DVD
                       {
                           DvdId = dvd.DvdId,
                           Title = dvd.Title,
                           RealeaseYear = dvd.RealeaseYear,
                           Notes = dvd.Notes,
                           Director = dvd.Director.DirectorFirstName + " " + dvd.Director.DirectorLastName,
                           Rating = dvd.Rating.RatingName,
                       };

            dvds = list.ToList();
            return dvds;
        }

        public DVD GetById(int dvdId)
        {
            {
                var repository = new DVDLibraryEntities();
                DVD dvd = new DVD();

                var result = repository.Dvd.SingleOrDefault(d => d.DvdId == dvdId);

                dvd.DvdId = result.DvdId;
                dvd.Title = result.Title;
                dvd.RealeaseYear = result.RealeaseYear;
                dvd.Notes = result.Notes;

                if (result.RatingId == null)
                    dvd.Rating = null;
                else
                    dvd.Rating = result.Rating.RatingName;

                if (result.DirectorId == null)
                    dvd.Director = "";
                else
                    dvd.Director = result.Director.DirectorFirstName + " " + result.Director.DirectorLastName;

                return dvd;
            }
        }

        public IEnumerable<DVD> Search(string searchCategory, string searchTerm)
        {
            var repository = new DVDLibraryEntities();
            List<DVD> result = new List<DVD>();

            switch (searchCategory)
            {
                case "title":
                    var selectedTitle = repository.Dvd.Where(d => d.Title.Contains(searchTerm)).ToList();
                    result = ConvertEFDvdListtoAPIDVDList(selectedTitle);
                    return result;
                case "year":
                    var selectedYear = repository.Dvd.Where(d => d.RealeaseYear.ToString().Contains(searchTerm)).ToList();
                    result = ConvertEFDvdListtoAPIDVDList(selectedYear);
                    return result;
                case "rating":
                    var selectedRating = repository.Dvd.Where(d => d.Rating.RatingName == searchTerm).ToList();
                    result = ConvertEFDvdListtoAPIDVDList(selectedRating);
                    return result;
                case "director":
                    var selectedDirector = repository.Dvd.Where(d => (d.Director.DirectorFirstName + " " + d.Director.DirectorLastName).Contains(searchTerm)).ToList();
                    result = ConvertEFDvdListtoAPIDVDList(selectedDirector);
                    return result;
                default:
                    throw new Exception("Invalid search category.");
            }
        }

        public List<DVD> ConvertEFDvdListtoAPIDVDList(List<Dvd> selectedList)
        {
            List<DVD> result = new List<DVD>();
            foreach (var dvd in selectedList)
            {
                DVD row = new DVD();
                row.DvdId = dvd.DvdId;
                row.Title = dvd.Title;
                row.RealeaseYear = dvd.RealeaseYear;
                row.Notes = dvd.Notes;

                if (dvd.DirectorId == null)
                    row.Director = null;
                else if (string.IsNullOrEmpty(dvd.Director.DirectorFirstName))
                    row.Director = dvd.Director.DirectorLastName;
                else
                    row.Director = dvd.Director.DirectorFirstName + " " + dvd.Director.DirectorLastName;

                if (dvd.RatingId == null)
                    row.Rating = null;
                else
                    row.Rating = dvd.Rating.RatingName;
                result.Add(row);
            }
            return result;
        }

        public int? GetDirectorId(string directorName)
        {
            if (string.IsNullOrEmpty(directorName))
                return null;
            else
            {
                int? directorId = null;
                DirectorIdRequest request = new DirectorIdRequest();
                request = Helpers.SplitDirectorName(directorName);
                directorId = FindDirectorID(request);              
                return directorId;
            }
        }

        public int? FindDirectorID(DirectorIdRequest request)
        {
            var repository = new DVDLibraryEntities();

            Director director = new Director();

            if (repository.Director.Any(dir => (dir.DirectorFirstName == request.FirstName && dir.DirectorLastName == request.LastName)))
            {
                director = repository.Director.FirstOrDefault(dir => (dir.DirectorFirstName == request.FirstName && dir.DirectorLastName == request.LastName));
                return director.DirectorID;
            }
            else
            {
                director = AddDirector(request);
                return director.DirectorID;
            }
        }

        public Director AddDirector(DirectorIdRequest newDirector)
        {
            var repository = new DVDLibraryEntities();
            var directorToAdd = new Director();

            directorToAdd.DirectorFirstName = newDirector.FirstName;
            directorToAdd.DirectorLastName = newDirector.LastName;

            repository.Director.Add(directorToAdd);
            repository.SaveChanges();

            Director addedDirector = new Director();
            addedDirector.DirectorFirstName = newDirector.FirstName;
            addedDirector.DirectorLastName = newDirector.LastName;
            addedDirector.DirectorID = directorToAdd.DirectorID;
            return addedDirector;
        }

        public void DirectorTableCleanUp(string director)
        {
            var repository = new DVDLibraryEntities();

            DirectorIdRequest request = new DirectorIdRequest();
            request = Helpers.SplitDirectorName(director);

            var directorRecord = repository.Director.FirstOrDefault(dir => (dir.DirectorFirstName == request.FirstName && dir.DirectorLastName == request.LastName));
            int? ID = directorRecord.DirectorID;            

            var count = repository.Dvd.Count(d => d.DirectorId == ID);

            if (count == 0)
                DeleteDirector(ID);
        }

        public void DeleteDirector(int? directorId)
        {
            var repository = new DVDLibraryEntities();

            var dir = repository.Director.FirstOrDefault(d => d.DirectorID == directorId);

            repository.Director.Remove(dir);
            repository.SaveChanges();
        }
    }
}
