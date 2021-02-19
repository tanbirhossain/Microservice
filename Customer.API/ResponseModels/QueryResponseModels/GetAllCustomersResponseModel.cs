using System;
using System.Collections.Generic;

namespace Customer.API.ResponseModels.QueryResponseModels
{
    public class GetAllCustomersResponseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
    }

}
