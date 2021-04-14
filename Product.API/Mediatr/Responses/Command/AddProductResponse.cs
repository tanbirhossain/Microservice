using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Mediatr.Responses.Command
{
    public class AddProductResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
    }
}
