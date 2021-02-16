using System;
using System.Collections.Generic;

#nullable disable

namespace Customer.API.DBModel
{
    public partial class tbl_Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
    }
}
