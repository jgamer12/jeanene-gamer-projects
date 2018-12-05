using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVDWebAPI.Models.Requests
{
    public class AddDVDRequest
    {
        [Required]
        public string Title { get; set; }
        public int? RealeaseYear { get; set; }    
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}
