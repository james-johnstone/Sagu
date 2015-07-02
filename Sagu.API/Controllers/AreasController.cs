using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sagu.DTO;
using Sagu.Services;

namespace Sagu.API
{
    public class AreasController : ApiController
    {
        AreaService AreaService = new AreaService();

        public IHttpActionResult Get()
        {
            var areas = AreaService.GetAreas();

            return Ok(areas);
        }

        public IHttpActionResult Get(Guid id)
        {
            var area = AreaService.GetArea(id);

            if (area == null)
                return NotFound();

            return Ok(area);
        }

        public IHttpActionResult Post([FromBody] Area area)
        {
            if (area == null)
                return BadRequest();

            try
            {
                var newArea = AreaService.CreateArea(area);

                return Created(string.Format("{0}/{1}", Request.RequestUri, newArea.Id), newArea);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put([FromBody] Area area)
        {
            if (area == null)
                return BadRequest();

            try
            {
                var updatedArea = AreaService.UpdateArea(area);

                return Ok(updatedArea);
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

        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                AreaService.DeleteArea(id);
                return StatusCode(HttpStatusCode.NoContent);
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
