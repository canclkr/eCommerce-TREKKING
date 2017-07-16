using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class MyOrderVM
    {
        //    o.OrderID,
        //    p.ProductName,
        //    o.Quantity,
        //    p.UnitPrice,
        //    o.SubTotal,
        //    o.OrderDate


        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public string OrderNumber { get; set; }



    }
}