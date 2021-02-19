using AutoMapper;
using Customer.API.RequestModels.QueryRequestModels;
using Customer.API.ResponseModels.QueryResponseModels;
using CustomerService.API.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Handlers.QueryHandlers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomersRequestModel, IList<GetAllCustomersResponseModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<IList<GetAllCustomersResponseModel>> Handle(GetAllCustomersRequestModel request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<GetAllCustomersResponseModel>>(await _customerRepository.GetCustomers());
            return result;
        }
    }
}
