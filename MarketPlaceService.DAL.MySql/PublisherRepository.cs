using MarketPlaceService.DAL.MySql.Contract;
using MarketPlaceService.DAL.MySql.Models;
using MarketPlaceService.Entities;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketPlaceService.DAL.MySql
{
    public class PublisherRepository : IPublisherRepository, IHealthCheck
    {
        protected readonly MarketplaceDbContext _context;

        public PublisherRepository(MarketplaceDbContext context)
        {
            _context = context;
        }
        public Task<PublisherDataModel> AddNewPublisher(PublisherDataModel publisher)
        {
            throw new NotImplementedException();
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePublisherAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PublisherDataModel> GetPublisherByIdAsync(Guid id)
        {
            // var result = _context.Publisher.Where(x => x.PublisherId == id).FirstOrDefault();

            PublisherDataModel publisherDataModel = new PublisherDataModel
            {
                // PublisherName = result.PublisherName,
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

        public Task<bool> UpdatePublisherAsync(PublisherDataModel publisher)
        {
            throw new NotImplementedException();
        }
    }
}
