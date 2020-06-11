using MarketPlaceService.Entities;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.DAL.MySql.Contract
{
    public interface ISiteRepository
    {
        Task<SiteDataModel> AddNewSite(SiteDataModel siteData);
    }
}
