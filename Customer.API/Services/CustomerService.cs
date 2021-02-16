using AutoMapper;
using Customer.API.DBModel;
using Customer.API.ViewModel;
using CustomerService.API.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.API.Service
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> Add(CustomerViewModel customer);
        Task<CustomerViewModel> GetById(long id);
        Task<List<CustomerViewModel>> GetCustomers();
        Task<CustomerViewModel> RemoveById(long id);
        Task<CustomerViewModel> Update(CustomerViewModel customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> Add(CustomerViewModel customer)
        {
            var result = await _customerRepository.Add(_mapper.Map<tbl_Customer>(customer));
            return _mapper.Map<CustomerViewModel>(result);
        }

        public async Task<CustomerViewModel> GetById(long id)
        {
            var result = _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id));
            return result;
        }

        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            var result = _mapper.Map<List<CustomerViewModel>>(await _customerRepository.GetCustomers());
            return result;
        }

        public async Task<CustomerViewModel> RemoveById(long id)
        {
            var result = _mapper.Map<CustomerViewModel>(await _customerRepository.RemoveById(id));
            return result;
        }

        public async Task<CustomerViewModel> Update(CustomerViewModel customer)
        {
            var result = await _customerRepository.Add(_mapper.Map<tbl_Customer>(customer));
            return _mapper.Map<CustomerViewModel>(result);
        }
    }
}
