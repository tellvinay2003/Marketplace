using MarketPlaceService.BLL.Contracts;
using MarketPlaceService.DAL.MySql.Contract;
using MarketPlaceService.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.BLL
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        private readonly ILogger<SubscriberService> _logger;

        public SubscriberService(ISubscriberRepository subscriberRepository, ILogger<SubscriberService> logger)
        {
            _subscriberRepository = subscriberRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<SubscriberDataModel>> GetSubscribersListAsync()
        {
            _logger.LogInformation("Repository call for GetSubscribersList started");
            var watch = Stopwatch.StartNew();
            var result = await _subscriberRepository.GetSubscribersListAsync();
            watch.Stop();
            _logger.LogInformation("Execution Time of GetSubscribersList repository call is: {duration}ms", watch.ElapsedMilliseconds);
            return result;
        }
    }
}
