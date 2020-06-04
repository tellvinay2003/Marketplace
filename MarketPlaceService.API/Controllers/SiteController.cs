using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MarketPlaceService.API.CustomEntities;
using MarketPlaceService.BLL.Contracts;
using MarketPlaceService.Entities;
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
            _logger.LogInformation("GetSiteById is called.");
            Response<IEnumerable<SiteDataModel>> response = new Response<IEnumerable<SiteDataModel>>();
            try
            {
                _logger.LogInformation("Site service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _siteService.GetRegisteredSitesAsync();
                watch.Stop();
                _logger.LogInformation("Execution Time of Site service for GetRegisteredSites call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<IEnumerable<SiteDataModel>> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("GetRegisteredSites executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<IEnumerable<SiteDataModel>> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
                return BadRequest(response);
            }
        }


        /// <summary>
        /// Get specific publisher details by PublisherId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PublisherDataModel), Description = "Returns finded Publisher")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid Publisher id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetSiteById([FromRoute] Guid id)
        {
            _logger.LogInformation("GetSiteById is called.");
            Response<SiteDataModel> response = new Response<SiteDataModel>();
            try
            {
                _logger.LogInformation("Site service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _siteService.GetSiteById(id);
                watch.Stop();
                _logger.LogInformation("Execution Time of Site service for GetSiteById call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<SiteDataModel> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("GetSiteById executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<SiteDataModel> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
                return BadRequest(response);
            }

        }


        /// <summary>
        /// Create new publisher
        /// </summary>
        /// <returns></returns>
        // [HttpPost("CreatePublisher")]
        [HttpPost("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> AddNewSite([FromBody] SiteDataModel siteData)
        {
            _logger.LogInformation("GetSiteById is called.");
            Response<SiteDataModel> response = new Response<SiteDataModel>();
            try
            {
                _logger.LogInformation("Site service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _siteService.AddNewSite(siteData);
                watch.Stop();
                _logger.LogInformation("Execution Time of Site service for AddNewSite call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<SiteDataModel> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("AddNewSite executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<SiteDataModel> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
                return BadRequest(response);
            }
        }

    }
}