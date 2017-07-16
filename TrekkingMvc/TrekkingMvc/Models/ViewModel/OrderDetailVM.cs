using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class OrderDetailVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string FullAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }

        public List<OrderVM> ProductList { get; set; }
    }
}