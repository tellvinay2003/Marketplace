using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class PublishedProductsHistory
    {
        public Guid PublishedProductHistoryId { get; set; }
        public Guid PublishedProductId { get; set; }
        public string ProductData { get; set; }
        public DateTime ProcessedOn { get; set; }
        public string ProcessedBy { get; set; }
        public int ProductVersion { get; set; }
        public long ProcessingStatusId { get; set; }

        public virtual PublishedProducts PublishedProduct { get; set; }
    }
}
