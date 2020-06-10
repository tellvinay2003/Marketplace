using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MarketPlaceService.API.CustomEntities;
using MarketPlaceService.BLL.Contracts;
using MarketPlaceService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketPlaceService.API.Controllers
{
    // [Authorize]
    // [Route("api/[controller]")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/subscriber")]
    [ApiVersion("1.0")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        readonly ILogger<SubscriberController> _logger;
        readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService, ILogger<SubscriberController> logger)
        {
            _logger = logger;
            _subscriberService = subscriberService;
        }


        /// <summary>
        /// Get list of all publishers
        /// </summary>
        /// <returns></returns>
        // [HttpGet("GetAll")]
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetRegisteredSubscribers()
        {
            _logger.LogInformation("GetPublisherById is called.");
            Response<IEnumerable<SubscriberDataModel>> response = new Response<IEnumerable<SubscriberDataModel>>();
            try
            {
                _logger.LogInformation("Subscriber service is called.");
                var watch = Stopwatch.StartNew();
                // Service call
                var result = await _subscriberService.GetSubscribersListAsync();
                watch.Stop();
                _logger.LogInformation("Execution Time of Subscriber service for GetRegisteredSubscribers call is: {duration}ms", watch.ElapsedMilliseconds);
                response = new Response<IEnumerable<SubscriberDataModel>>
                            { 
                                ResponseCode = (int)Code.success, 
                                Status = "Success", 
                                ResponseMessage = result, 
                                ExecutionTime = watch.ElapsedMilliseconds,
                                TraceId = Guid.NewGuid() 
                                 
                            };
                _logger.LogInformation("GetRegisteredSubscribers executed successfully.");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                response = new Response<IEnumerable<SubscriberDataModel>> 
                            { 
                                ResponseCode = (int)Code.exceptionError, 
                                Status = "Failure", 
                                Message = ex.ToString(), 
                                TraceId = Guid.NewGuid()  
                            };
                return BadRequest(response);
            }
        }

    }
}