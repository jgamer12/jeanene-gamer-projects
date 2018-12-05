using DVDWebAPI.Data.Interfaces;
using DVDWebAPI.Models.Queries;
using DVDWebAPI.Models.Requests;
using DVDWebAPI.Models.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPI.Data.ADO
{
    public class DVDRepositoryADO : IDVDRepository
    {
        public void Add(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibraryAddDVD", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                int? ratingId = Helpers.GetRatingId(dvd.Rating);
                if (ratingId == null)
                    cmd.Parameters.AddWithValue("@RatingId", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RatingId", Helpers.GetRatingId(dvd.Rating));
                int? directorId = GetDirectorId(dvd.Director);
                if (directorId == null)
                    cmd.Parameters.AddWithValue("@DirectorId", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DirectorId", directorId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                if (dvd.RealeaseYear == null)
                    cmd.Parameters.AddWithValue("@RealeaseYear", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                if (string.IsNullOrEmpty(dvd.Notes))
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }

        public void Delete(int dvdId)
        {
            string director = GetById(dvdId).Director;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibraryDeleteDVDById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                cn.Open();

                cmd.ExecuteNonQuery();
            }

            if (!string.IsNullOrEmpty(director))
                DirectorTableCleanUp(director);
        }

        public void Edit(DVD dvd)
        {
            string director = GetById(dvd.DvdId).Director;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibraryEditDVD", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                int? ratingId = Helpers.GetRatingId(dvd.Rating);
                if (ratingId == null)
                    cmd.Parameters.AddWithValue("@RatingId", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RatingId", Helpers.GetRatingId(dvd.Rating));
                int? directorId = GetDirectorId(dvd.Director);
                if (directorId == null)
                    cmd.Parameters.AddWithValue("@DirectorId", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DirectorId", directorId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                if (dvd.RealeaseYear == null)
                    cmd.Parameters.AddWithValue("@RealeaseYear", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                if (string.IsNullOrEmpty(dvd.Notes))
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();
            }

            if (!string.IsNullOrEmpty(director))
                DirectorTableCleanUp(director);
        }

        public IEnumerable<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibrarySelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD row = new DVD();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        if (dr["RealeaseYear"] != DBNull.Value)
                            row.RealeaseYear = (int)dr["RealeaseYear"];

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public DVD GetById(int dvdId)
        {
            DVD dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibrarySelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new DVD();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.Director = dr["Director"].ToString();
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                        if (dr["RealeaseYear"] != DBNull.Value)
                            dvd.RealeaseYear = (int)dr["RealeaseYear"];

                    }
                }
            }
            return dvd;
        }

        public IEnumerable<DVD> Search(string searchCategory, string searchTerm)
        {
            List<DVD> dvds = new List<DVD>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibrarySearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SearchCategory", searchCategory);
                if (searchCategory != "rating")
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm +"%");
                else
                    cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD row = new DVD();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.Director = dr["Director"].ToString();
                        row.Rating = dr["Rating"].ToString();
                        row.Notes = dr["Notes"].ToString();

                        if (dr["RealeaseYear"] != DBNull.Value)
                            row.RealeaseYear = (int)dr["RealeaseYear"];

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public int? GetDirectorId(string directorName)
        {
            int? directorId = null;

            if (string.IsNullOrEmpty(directorName))
                return null;
            else
            {
                DirectorIdRequest request = new DirectorIdRequest();
                request = Helpers.SplitDirectorName(directorName);
                directorId = FindDirectorID(request);
                if (directorId == null)
                {
                    Director director = new Director();
                    director.DirectorFirstName = request.FirstName;
                    director.DirectorLastName = request.LastName;
                    directorId = AddDirector(director);
                }
                return directorId;
            }
        }

        public int? FindDirectorID(DirectorIdRequest request)
        {
            int? directorId = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibraryFindDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (string.IsNullOrEmpty(request.FirstName))
                    cmd.Parameters.AddWithValue("@FirstName", "");
                else
                    cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                cmd.Parameters.AddWithValue("@LastName", request.LastName);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        directorId = (int)dr["DirectorID"];
                    }
                }
                return directorId;
            }
        }

        public int? AddDirector(Director director)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibraryAddDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DirectorID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                if (string.IsNullOrEmpty(director.DirectorFirstName))
                    cmd.Parameters.AddWithValue("@FirstName", "");
                else
                    cmd.Parameters.AddWithValue("@FirstName", director.DirectorFirstName);
                cmd.Parameters.AddWithValue("@LastName", director.DirectorLastName);

                cn.Open();

                cmd.ExecuteNonQuery();

                director.DirectorID = (int)param.Value;
            }
            int? addedDirector = director.DirectorID;
            return addedDirector;
        }

        public void DirectorTableCleanUp(string director)
        {
            int? directorId = null;
            int? count = null;

            DirectorIdRequest request = new DirectorIdRequest();
            request = Helpers.SplitDirectorName(director);
            directorId = FindDirectorID(request);

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibraryNumberOfDirectorRecords", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@NumberOfRecords", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@DirectorId", directorId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        count = (int)dr["@NumberOfRecords"];
                    }
                }
            }
            if (count == null)
                DeleteDirector(directorId);
        }

        public void DeleteDirector(int? directorId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDLibraryDeleteDirectorById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DirectorId", directorId);
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
