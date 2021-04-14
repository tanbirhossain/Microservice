using MediatR;
using Product.API.Mediatr.Responses.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Mediatr.Requests.Command
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {

        public string Name { get; set; }
        public int? Quantity { get; set; }
    }
}
