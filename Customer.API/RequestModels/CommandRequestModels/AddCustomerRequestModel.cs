using Customer.API.ResponseModels.CommandResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.RequestModels.CommandRequestModels
{
    public class AddCustomerRequestModel : IRequest<AddCustomerResposeModel>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
    }

}
