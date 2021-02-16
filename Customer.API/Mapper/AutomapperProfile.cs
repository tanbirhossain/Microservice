using AutoMapper;
using Customer.API.Database;
using Customer.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Mapper
{
  
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Model to table
            CreateMap<CustomerViewModel, tbl_Customer>();

            // table to model
            CreateMap<tbl_Customer, CustomerViewModel>();
        }
    }
}
