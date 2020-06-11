using MarketPlaceService.BLL.Contracts;
using MarketPlaceService.DAL.MySql.Contract;
using MarketPlaceService.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.BLL
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository  _siteRepository;

        private readonly ILogger<SiteService> _logger;
        public SiteService(ISiteRepository siteRepository, ILogger<SiteService> logger)
        {
            _siteRepository = siteRepository;
            _logger = logger;
        }


        public async Task<SiteDataModel> AddNewSite(SiteDataModel siteData)
        {
            _logger.LogInformation("Repository call for GetPublisherById started");
            var watch = Stopwatch.StartNew();
            var result = await _siteRepository.AddNewSite(siteData);
            watch.Stop();
            _logger.LogInformation("Execution Time of GetPublisherById repository call is: {duration}ms", watch.ElapsedMilliseconds);
            return result;
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
