using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            PublishedProducts = new HashSet<PublishedProducts>();
            PublishedProductsQueue = new HashSet<PublishedProductsQueue>();
        }

        public Guid PublisherId { get; set; }
        public Guid SiteId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string PublisherName { get; set; }
        public bool Enabled { get; set; }

        public virtual Site Site { get; set; }
        public virtual ICollection<PublishedProducts> PublishedProducts { get; set; }
        public virtual ICollection<PublishedProductsQueue> PublishedProductsQueue { get; set; }
    }
}
