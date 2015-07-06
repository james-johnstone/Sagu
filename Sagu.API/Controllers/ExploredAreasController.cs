using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sagu.DTO;
using Sagu.Services;

namespace Sagu.API.Controllers
{
    [RoutePrefix("api")]
    public class ExploredAreasController : ApiController
    {
        ExploredAreaService ExploredAreaService = new ExploredAreaService();

        // GET: api/explorers/id/ExploredAreas
        [Route("explorers/{explorerId}/exploredAreas")]
        public IHttpActionResult GetAreas(Guid explorerId)
        {
            var areas = ExploredAreaService.GetExploredAreas(explorerId);

            return Ok(areas);
        }

        public IHttpActionResult Get(Guid id)
        {
            var area = ExploredAreaService.GetExploredArea(id);

            if (area == null)
                return NotFound();

            return Ok(area);
        }

        public IHttpActionResult Post([FromBody] ExploredArea area)
        {
            if (area == null)
                return BadRequest();

            try
            {
                area.Id = Guid.NewGuid();
                var newExplorer = ExploredAreaService.CreateExploredArea(area);

                return Created(string.Format("{0}/{1}", Request.RequestUri, newExplorer.Id), newExplorer);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put([FromBody] ExploredArea area)
        {
            if (area == null)
                return BadRequest();

            try
            {
                var updatedExplorer = ExploredAreaService.UpdateExploredArea(area);

                return Ok(updatedExplorer);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
