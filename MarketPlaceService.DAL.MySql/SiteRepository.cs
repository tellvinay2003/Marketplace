using MarketPlaceService.DAL.MySql.Contract;
using MarketPlaceService.DAL.MySql.Models;
using MarketPlaceService.Entities;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketPlaceService.DAL.MySql
{
    public class SiteRepository : ISiteRepository, IHealthCheck
    {
        protected readonly MarketplaceDbContext _context;

        public SiteRepository(MarketplaceDbContext context) 
        {
            _context = context;
        }

        public async Task<SiteDataModel> AddNewSite(SiteDataModel siteData)
        {
            var siteItem = new Site
            {
                SiteName = siteData.SiteName,
                Url = siteData.Url,
                Enabled = true,
            };

            _context.Site.Add(siteItem);
            await _context.SaveChangesAsync();
            siteData.SiteId = siteItem.SiteId;
            return await Task.FromResult(siteData);

        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


    }
}
