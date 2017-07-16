using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class AddressVM
    {
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
    }
}