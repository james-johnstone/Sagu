﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sagu.DTO;
using Sagu.Services;

namespace Sagu.API
{
    public class ExplorersController : ApiController
    {
        ExplorerService ExplorerService = new ExplorerService();

        public IHttpActionResult Get()
        {
            try
            {
                var explorers = ExplorerService.GetExplorers();
                return Ok(explorers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IHttpActionResult Get(Guid id)
        {
            var explorer = ExplorerService.GetExplorer(id);

            if (explorer == null)
                return NotFound();

            return Ok(explorer);
        }

        public IHttpActionResult Post([FromBody] Explorer explorer)
        {
            if (explorer == null)
                return BadRequest();

            try
            {                
                var newExplorer = ExplorerService.CreateExplorer(explorer);

                return Created(string.Format("{0}/{1}", Request.RequestUri, newExplorer.Id), newExplorer);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put([FromBody] Explorer explorer)
        {
            if (explorer == null)
                return BadRequest();

            try
            {
                var updatedExplorer = ExplorerService.UpdateExplorer(explorer);

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

        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                ExplorerService.DeleteExplorer(id);
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
