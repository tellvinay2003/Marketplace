using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class PublishedStatus
    {
        public PublishedStatus()
        {
            PublishedProducts = new HashSet<PublishedProducts>();
        }

        public Guid PublishStatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PublishedProducts> PublishedProducts { get; set; }
    }
}
