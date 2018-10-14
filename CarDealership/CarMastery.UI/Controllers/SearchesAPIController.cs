using CarMastery.Data.Factories;
using CarMastery.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarMastery.UI.Controllers
{
    public class SearchesAPIController : ApiController
    {

        [Route("api/vehicles/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchForInventory(string newUsed, string makeModelYear, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            var repo = InventoryRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    NewUsed = newUsed,
                    MakeModelYear = makeModelYear,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };
                var result = repo.SearchInventory(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/reports/sales/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchForSalesReport (string userId, string fromDate, string toDate)
        {
            var repo = SalesRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SalesReportSearchParameters()
                {
                    UserId = userId,
                    FromDate = fromDate,
                    ToDate = toDate
                };
                var result = repo.GetSalesForReport(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/models/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchForModels(int makeId)
        {
            var repo = ModelsRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetModelsForMake(makeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
