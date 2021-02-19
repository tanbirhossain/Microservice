using System;

namespace Customer.API.ResponseModels.CommandResponseModels
{
    public class UpdateCustomerResposeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
    }
}
