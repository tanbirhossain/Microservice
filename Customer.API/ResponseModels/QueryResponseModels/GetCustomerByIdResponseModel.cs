using System;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.ResponseModels.QueryResponseModels
{
    public class GetCustomerByIdResponseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
    } 
}
