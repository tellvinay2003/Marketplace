using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class ProcessingStatus
    {
        public ProcessingStatus()
        {
            PublishedProducts = new HashSet<PublishedProducts>();
            PublishedProductsQueue = new HashSet<PublishedProductsQueue>();
        }

        public Guid ProcessingStatusId { get; set; }
        public string ProcessingStatusName { get; set; }

        public virtual ICollection<PublishedProducts> PublishedProducts { get; set; }
        public virtual ICollection<PublishedProductsQueue> PublishedProductsQueue { get; set; }
    }
}
