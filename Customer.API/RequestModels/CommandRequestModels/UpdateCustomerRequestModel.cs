using System;

namespace Customer.API.RequestModels.CommandRequestModels
{
    public class UpdateCustomerRequestModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
    }

}
