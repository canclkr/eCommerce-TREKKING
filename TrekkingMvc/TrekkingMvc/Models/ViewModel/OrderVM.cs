using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class OrderVM
    {
        public int prcID { get; set; }
        public string prcName { get; set; }
        public string prcDesription { get; set; }
        public int prcQuantity { get; set; }
        public decimal prcUnitPrice { get; set; }
        public decimal prcSubTotal { get; set; }
        public string prcSize { get; set; }
    }
}