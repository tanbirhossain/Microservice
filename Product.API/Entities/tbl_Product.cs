using System;
using System.Collections.Generic;

#nullable disable

namespace Product.API.Entities
{
    public partial class tbl_Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}
