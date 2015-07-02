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
            var explorers = ExplorerService.GetExplorers();

            return Ok(explorers);
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

                if (updatedExplorer == null)
                    return NotFound();

                return Ok(updatedExplorer);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
