using MarketPlaceService.DAL.MySql.Models;
using MarketPlaceService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.DAL.MySql.Contract
{
    public interface IPublisherRepository
    {
        Task<PublisherDataModel> AddNewPublisher(PublisherDataModel publisher);
        Task<PublisherDataModel> GetPublisherByIdAsync(Guid id);
        Task<bool> UpdatePublisherAsync(PublisherDataModel publisher);
        Task<bool> DeletePublisherAsync(Guid id);
        Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync(int pageNumber, int pageSize);
        Task<IEnumerable<PublisherDataModel>> GetPublishersListAsync();
    }
}
