using Customer.API.ResponseModels.QueryResponseModels;
using MediatR;
using System.Collections.Generic;

namespace Customer.API.RequestModels.QueryRequestModels
{
    public class GetAllCustomersRequestModel : IRequest<IList<GetAllCustomersResponseModel>>
    {
      
    }
}
