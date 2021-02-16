using Customer.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Services
{
    public interface ISeedService
    {
        void DoSeed();
    }
    public class CustomerSeedService : ISeedService
    {
        private readonly ISeedRepository _seedRepository;

        public CustomerSeedService(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }
        public void DoSeed()
        {
             _seedRepository.DoSeed();

        }
    }
}
