using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlaceService.Entities
{
    public class SiteDataModel
    {
        public Guid SiteId { get; set; }
        public string SiteName { get; set; }
        public string Url { get; set; }
        public bool Enabled { get; set; }
    }
}
