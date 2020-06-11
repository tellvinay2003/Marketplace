using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class Subscriber
    {
        public Guid SubscriberId { get; set; }
        public Guid SiteId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string SubscriberName { get; set; }
        public bool Enabled { get; set; }

        public virtual Site Site { get; set; }
    }
}
