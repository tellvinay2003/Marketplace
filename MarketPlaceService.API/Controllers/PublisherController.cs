using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MarketPlaceService.API.CustomEntities;
using MarketPlaceService.API.Models;
using MarketPlaceService.BLL.Contracts;
using MarketPlaceService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketPlaceService.API.Controllers
{
    //[Authorize]
    // [Route("api/[controller]")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/publisher")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        readonly ILogger<PublisherController> _logger;
        readonly IProfileService _profileService;
        public PublisherController(IProfileService profileService, ILogger<PublisherController> logger)
        {
            _logger = logger;
            _profileService = profileService;
        }

        /// <summary>
        /// Get list of all publishers
        /// </summary>
        /// <returns></returns>
        // [HttpGet("GetAll")]
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetRegisteredPublishers()
        {
            _logger.LogInformation("GetPublisherById is called.");
            Response<IEnumerable<PublisherDataModel>> response = new Response<IEnumerable<PublisherDataModel>>();
            try
            {
                _logger.LogInformation("Publisher service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _profileService.GetPublishersListAsync();
                watch.Stop();
                _logger.LogInformation("Execution Time of Publisher service for GetRegisteredPublishers call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<IEnumerable<PublisherDataModel>> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("GetRegisteredPublishers executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<IEnumerable<PublisherDataModel>> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
                return BadRequest(response);
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pageNumber"></param>
        ///// <param name="pageSize"></param>
        ///// <returns></returns>
        //[HttpGet("")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        //// [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid id")]
        //[SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        //public async Task<IActionResult> GetRegisteredPublishers(int pageNumber, int pageSize)
        //{
        //    return Ok();
        //}


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
        public async Task<IActionResult> GetPublisherById([FromRoute] Guid id)
        {
            _logger.LogInformation("GetPublisherById is called.");
            Response<PublisherDataModel> response = new Response<PublisherDataModel>();
            try
            {
                _logger.LogInformation("Publisher service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _profileService.GetPublisherById(id);
                watch.Stop();
                _logger.LogInformation("Execution Time of Publisher service for GetPublisherById call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("GetPublisherById executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
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
        public async Task<IActionResult> AddNewPublisher([FromBody] PublisherDataModel publisherItem)
        {
            _logger.LogInformation("AddNewPublisher is called.");
            Response<PublisherDataModel> response = new Response<PublisherDataModel>();
            try
            {
                _logger.LogInformation("Publisher service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _profileService.AddNewPublisher(publisherItem);
                watch.Stop();
                _logger.LogInformation("Execution Time of Publisher service for GetPublisherById call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("AddNewPublisher executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
                return BadRequest(response);
            }
        }


        /// <summary>
        /// Update existing publisher details by PublisherId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // [HttpPut("UpdatePublisher")]
        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid Publisher id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> UpdatePublisher([FromBody] Guid id)
        {
            _logger.LogInformation("UpdatePublisher is called.");
            Response<PublisherDataModel> response = new Response<PublisherDataModel>();
            try
            {
                _logger.LogInformation("Publisher service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _profileService.UpdatePublisher(id);
                watch.Stop();
                _logger.LogInformation("Execution Time of Publisher service for UpdatePublisher call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("UpdatePublisher executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
                return BadRequest(response);
            }
        }


        /// <summary>
        /// Delete existing publisher by PublisherId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // [HttpDelete("DeletePublisher")]
        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid Publisher id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> DeletePublisher([FromBody] Guid id)
        {
            _logger.LogInformation("DeletePublisher is called.");
            Response<PublisherDataModel> response = new Response<PublisherDataModel>();
            try
            {
                _logger.LogInformation("Publisher service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _profileService.DeletePublisher(id);
                watch.Stop();
                _logger.LogInformation("Execution Time of Publisher service for DeletePublisher call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.success, ResponseMessage = result };
                _logger.LogInformation("DeletePublisher executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<PublisherDataModel> { ResponseCode = (int)Code.exceptionError, Message = ex.ToString() };
                return BadRequest(response);
            }
        }

    }
}