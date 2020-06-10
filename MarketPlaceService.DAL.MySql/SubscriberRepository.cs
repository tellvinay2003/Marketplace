using MarketPlaceService.DAL.MySql.Contract;
using MarketPlaceService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.DAL.MySql
{
    public class SubscriberRepository : ISubscriberRepository
    {
        public async Task<IEnumerable<SubscriberDataModel>> GetSubscribersListAsync()
        {
            IList<SubscriberDataModel> subscriberDataModels = new List<SubscriberDataModel>();
            subscriberDataModels.Add(new SubscriberDataModel { 
                SubscriberId = Guid.NewGuid(), 
                SubscriberName = "Subscriber1",
                 Description = "subscriber description1",
                  ShortName = "subs1 Short name"
            
            });
            return await Task.FromResult(subscriberDataModels);
        }
    }
}
