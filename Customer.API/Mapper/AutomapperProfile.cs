using AutoMapper;
using Customer.API.Database;
using Customer.API.Handlers.CommandHandlers;
using Customer.API.RequestModels.CommandRequestModels;
using Customer.API.ResponseModels.CommandResponseModels;
using Customer.API.ResponseModels.QueryResponseModels;
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
            CreateMap<AddCustomerRequestModel, tbl_Customer>();

            // table to model
            CreateMap<tbl_Customer, CustomerViewModel>();
            CreateMap<tbl_Customer, AddCustomerResposeModel>();
            CreateMap<tbl_Customer, GetAllCustomersResponseModel>();
        }
    }
}
