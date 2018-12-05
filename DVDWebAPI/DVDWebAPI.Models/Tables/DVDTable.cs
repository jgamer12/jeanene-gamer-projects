using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Models.Tables
{
    public class DVDTable
    {
        public int DvdId { get; set; }
        public int? RatingId { get; set; }
        public int? DirectorId { get; set; }
        public string Title { get; set; }
        public int? RealeaseYear { get; set; }
        public string Notes { get; set; }
    }
}
