using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sagu.Services;

namespace Sagu.API.Controllers
{
    public class ExplorersController : ApiController
    {
        ExplorerService ExplorerService = new ExplorerService();

        public IHttpActionResult Get()
        {
            var explorers = ExplorerService.GetExplorers();

            return Ok(explorers);
        }
    }
}
