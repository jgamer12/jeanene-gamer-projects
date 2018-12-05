using DVDWebAPI.Data.Factories;
using DVDWebAPI.Models.Queries;
using DVDWebAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace DVDWebAPI.UI.Controllers
{
    public class DVDAPIController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var repo = DVDRepositoryFactory.GetRepository();

            return Ok(repo.GetAll());
        }
        
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int dvdId)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                var result = repo.GetById(dvdId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/{searchCategory}/{searchTerm}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string searchCategory, string searchTerm)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                var result = repo.Search(searchCategory, searchTerm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddDVDRequest request)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                DVD dvd = new DVD()
                {
                    Title = request.Title,
                    RealeaseYear = request.RealeaseYear,
                    Director = request.Director,
                    Rating = request.Rating,
                    Notes = request.Notes
                };
                repo.Add(dvd);
                return Created($"dvd/get/{dvd.DvdId}", dvd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                DVD dvd = repo.GetById(dvdId);

                repo.Delete(dvdId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(EditDVDRequest request)
        {
            var repo = DVDRepositoryFactory.GetRepository();
            try
            {
                DVD dvd = repo.GetById(request.DvdId);

                dvd.Title = request.Title;
                dvd.RealeaseYear = request.RealeaseYear;
                dvd.Director = request.Director;
                dvd.Rating = request.Rating;
                dvd.Notes = request.Notes;
               
                repo.Edit(dvd);
                return Ok(dvd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}