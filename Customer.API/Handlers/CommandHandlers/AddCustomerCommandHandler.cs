using AutoMapper;
using Customer.API.Database;
using Customer.API.RequestModels.CommandRequestModels;
using Customer.API.ResponseModels.CommandResponseModels;
using CustomerService.API.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Handlers.CommandHandlers
{

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerRequestModel,AddCustomerResposeModel>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async  Task<AddCustomerResposeModel> Handle(AddCustomerRequestModel request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.Add(_mapper.Map<tbl_Customer>(request));
            return _mapper.Map<AddCustomerResposeModel>(result);
        }
    }
}
