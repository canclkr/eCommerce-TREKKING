using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class HomeVM
    {
        public List<Products> ListProduct { get; set; }
        public List<Products> ErkekProductsList { get; set; }
        public List<Products> KadınProductList { get; set; }
    }
}