using DVDWebAPI.Models.EF;
using DVDWebAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data
{
    public class Helpers
    {
        public static int? GetRatingId(string ratingName)
        {
            switch (ratingName)
            {
                case "G":
                    return 1;
                case "PG":
                    return 2;
                case "PG-13":
                    return 3;
                case "R":
                    return 4;
                case "NC-17":
                    return 5;
                default:
                    return null;
            }
        }        

        public static DirectorIdRequest SplitDirectorName(string directorName)
        {
            string firstName = null;
            string lastName = null;
            var names = directorName.Split(' ');
            var length = names.Length;

            if (length == 1)
            {
                lastName = names[0].Trim();
            }

            else
            {
                firstName = names[0];
                for (int i = 1; i < length; i++)
                {
                    lastName = lastName + ' ' + names[i];
                }
                lastName = lastName.Trim();
            }
            DirectorIdRequest result = new DirectorIdRequest();
            if (string.IsNullOrEmpty(firstName))
                result.FirstName = "";
            else
                result.FirstName = firstName;
            result.LastName = lastName;
            return result;
        }
    }
}
