using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlaceService.API.CustomEntities
{
    public class Response<T>
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public T ResponseMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
