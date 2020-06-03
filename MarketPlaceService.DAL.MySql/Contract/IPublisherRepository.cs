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
        Task<PublisherDbEntity> AddNewPublisher(PublisherDbEntity publisher);
        Task<PublisherDataModel> GetPublisherByIdAsync(Guid id);
        Task<bool> UpdateCarAsync(PublisherDbEntity publisher);
        Task<bool> DeleteCarAsync(Guid id);
        Task<IEnumerable<PublisherDbEntity>> GetPublishersListAsync(int pageNumber, int pageSize);
        Task<IEnumerable<PublisherDbEntity>> GetPublishersListAsync();
    }
}
