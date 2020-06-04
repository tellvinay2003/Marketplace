using MarketPlaceService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.BLL.Contracts
{
   public interface IProfileService
    {
        Task<PublisherDataModel> GetPublisherById(Guid id);
        Task<PublisherDataModel> AddNewPublisher(PublisherDataModel publisherItem);
        Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync(int pageNumber, int pageSize);
        Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync();

        Task<PublisherDataModel> UpdatePublisher(Guid id);

        Task<PublisherDataModel> DeletePublisher(Guid id);
    }
}
