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
    public class SubscriberRepository : ISubscriberRepository, IHealthCheck
    {
        protected readonly MarketplaceDbContext _context;

        public SubscriberRepository(MarketplaceDbContext context) 
        {
            _context = context;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubscriberDataModel>> GetSubscribersListAsync()
        {
            IList<SubscriberDataModel> subscriberDataModels = new List<SubscriberDataModel>();

            var result = _context.Subscriber.Where(x => !string.IsNullOrEmpty(x.SubscriberName)).ToList();

            foreach (Subscriber item in result)
            {
                var dataModel = new SubscriberDataModel
                {
                    SubscriberName = item.SubscriberName
                };
                subscriberDataModels.Add(dataModel);
            }
            return await Task.FromResult(subscriberDataModels);
        }
    }
}
