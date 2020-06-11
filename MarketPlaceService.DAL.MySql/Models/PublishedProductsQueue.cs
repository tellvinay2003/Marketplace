using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class PublishedProductsQueue
    {
        public Guid PublishedProductQueueId { get; set; }
        public Guid PublishedProductTypeId { get; set; }
        public Guid PublishedProductId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid ProcessingStatusId { get; set; }
        public string ProcessingNote { get; set; }
        public int RetryCount { get; set; }

        public virtual ProcessingStatus ProcessingStatus { get; set; }
        public virtual PublishedProducts PublishedProduct { get; set; }
        public virtual ProductType PublishedProductType { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
