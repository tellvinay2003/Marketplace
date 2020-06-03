using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MarketPlaceService.BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketPlaceService.API.Controllers
{
    //[Authorize]
    // [Route("api/[controller]")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/site")]
    [ApiVersion("1.0")]
    [ApiController]

    public class SiteController : ControllerBase
    {
        readonly ILogger<SiteController> _logger;
        readonly ISiteService _siteService;
        public SiteController(ISiteService siteService, ILogger<SiteController> logger)
        {
            _logger = logger;
            _siteService = siteService;
        }


        /// <summary>
        /// Get list of all publishers
        /// </summary>
        /// <returns></returns>
        // [HttpGet("GetAll")]
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetRegisteredSites()
        {
            return Ok();
        }

    }
}