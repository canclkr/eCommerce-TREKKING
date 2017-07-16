using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class OrderSummaryVM
    {
        public List<OrderVM> _odList{ get; set; }
        public AddressVM _add { get; set; }
    }
}