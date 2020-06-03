﻿using MarketPlaceService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceService.BLL.Contracts
{
   public interface IProfileService
    {
        Task<PublisherDataModel> GetPublisherById(Guid id);
    }
}
