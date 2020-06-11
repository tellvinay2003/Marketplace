using MarketPlaceService.DAL.MySql.Models;
using MarketPlaceService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.DAL.MySql.Contract
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<SubscriberDataModel>> GetSubscribersListAsync();
    }
}
