using MarketPlaceService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.BLL.Contracts
{
    public interface ISiteService
    {
        Task<SiteDataModel> GetSiteById(Guid id);

        Task<SiteDataModel> AddNewSite(SiteDataModel siteData);

        Task<IEnumerable<SiteDataModel>> GetRegisteredSitesAsync();
    }
}
