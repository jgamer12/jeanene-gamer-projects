using DVDWebAPI.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data.Interfaces
{
    public interface IDVDRepository
    {
        IEnumerable<DVD> GetAll();
        DVD GetById(int dvdId);
        void Add(DVD dvd);
        void Edit(DVD dvd);
        void Delete(int dvdId);
        IEnumerable<DVD> Search(string searchCategory, string searchTerm);
    }
}
