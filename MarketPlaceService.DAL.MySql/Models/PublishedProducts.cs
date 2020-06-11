using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class PublishedProducts
    {
        public PublishedProducts()
        {
            PublishedProductsHistory = new HashSet<PublishedProductsHistory>();
            PublishedProductsQueue = new HashSet<PublishedProductsQueue>();
        }

        public Guid PublishedProductId { get; set; }
        public Guid PublisherId { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductVersion { get; set; }
        public byte[] ProductData { get; set; }
        public Guid PublishedStatusId { get; set; }
        public DateTime ProcessedOn { get; set; }
        public Guid ProcessingStatusId { get; set; }
        public string ProcessingNote { get; set; }
        public string ProcessedBy { get; set; }

        public virtual ProcessingStatus ProcessingStatus { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual PublishedStatus PublishedStatus { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<PublishedProductsHistory> PublishedProductsHistory { get; set; }
        public virtual ICollection<PublishedProductsQueue> PublishedProductsQueue { get; set; }
    }
}
