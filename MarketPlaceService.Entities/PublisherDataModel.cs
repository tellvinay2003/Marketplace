using System;
using System.ComponentModel.DataAnnotations;

namespace MarketPlaceService.Entities
{
    public class PublisherDataModel
    {
        public Guid PublisherId { get; set; }
        public Guid SiteId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string PublisherName { get; set; }
        public bool Enabled { get; set; }

       
    }
}
