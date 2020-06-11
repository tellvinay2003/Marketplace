using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class Site
    {
        public Site()
        {
            Publisher = new HashSet<Publisher>();
            Subscriber = new HashSet<Subscriber>();
        }

        public Guid SiteId { get; set; }
        public string SiteName { get; set; }
        public string Url { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Publisher> Publisher { get; set; }
        public virtual ICollection<Subscriber> Subscriber { get; set; }
    }
}
