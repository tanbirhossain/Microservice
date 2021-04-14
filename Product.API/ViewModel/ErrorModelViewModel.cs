using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.ViewModel
{
    public class ErrorModelViewModel
    {
        public string Message { get; set; }
        public int Code { get; set; } =  400;
    }
}
