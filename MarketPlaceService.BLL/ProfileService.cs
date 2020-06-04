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
    public class ProfileService : IProfileService
    {
        private readonly IPublisherRepository _publisherRepository;

        private readonly ILogger<ProfileService> _logger;
        public ProfileService(IPublisherRepository publisherRepository, ILogger<ProfileService> logger)
        {
            _publisherRepository = publisherRepository;
            _logger = logger;
        }

        public Task<PublisherDataModel> AddNewPublisher(PublisherDataModel publisherItem)
        {
            throw new NotImplementedException();
        }

        public Task<PublisherDataModel> DeletePublisher(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PublisherDataModel> GetPublisherById(Guid id)
        {
            _logger.LogInformation("Repository call for GetPublisherById started");
            var watch = Stopwatch.StartNew();
            var result = await _publisherRepository.GetPublisherByIdAsync(id);
            watch.Stop();
            _logger.LogInformation("Execution Time of GetPublisherById repository call is: {duration}ms", watch.ElapsedMilliseconds);
            return result;
        }

        public Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PublisherDataModel> UpdatePublisher(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
