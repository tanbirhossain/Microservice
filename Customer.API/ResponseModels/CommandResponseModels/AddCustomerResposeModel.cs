﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.ResponseModels.CommandResponseModels
{
    public class AddCustomerResposeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
    } 
}
