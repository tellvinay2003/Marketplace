using MarketPlaceService.BLL.Contracts;
using MarketPlaceService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.BLL
{
    public class SiteService : ISiteService
    {
        public Task<SiteDataModel> AddNewSite(SiteDataModel siteData)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SiteDataModel>> GetRegisteredSitesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SiteDataModel> GetSiteById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
