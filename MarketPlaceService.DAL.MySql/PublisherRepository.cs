using MarketPlaceService.DAL.MySql.Contract;
using MarketPlaceService.DAL.MySql.Models;
using MarketPlaceService.Entities;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketPlaceService.DAL.MySql
{
    public class PublisherRepository : IPublisherRepository, IHealthCheck
    {
        public Task<PublisherDataModel> AddNewPublisher(PublisherDataModel publisher)
        {
            throw new NotImplementedException();
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCarAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PublisherDataModel> GetPublisherByIdAsync(Guid id)
        {
            PublisherDataModel publisherDataModel = new PublisherDataModel
            {
                PublisherName = "Piblisher1",
                Description = "Description",
                ShortName = "Pub1",
                PublisherId = Guid.NewGuid(),
                StatusId = Guid.NewGuid()
            };

            return await Task.FromResult(publisherDataModel);
        }

        public Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCarAsync(PublisherDataModel publisher)
        {
            throw new NotImplementedException();
        }
    }
}
