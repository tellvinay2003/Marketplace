using System;
using System.Collections.Generic;

namespace MarketPlaceService.DAL.MySql.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            PublishedProducts = new HashSet<PublishedProducts>();
            PublishedProductsQueue = new HashSet<PublishedProductsQueue>();
        }

        public Guid ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public virtual ICollection<PublishedProducts> PublishedProducts { get; set; }
        public virtual ICollection<PublishedProductsQueue> PublishedProductsQueue { get; set; }
    }
}
