using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class ProductsVM
    {
        public List<Products> ErkekList { get; set; }
        public List<Products> KadınList { get; set; }
        public List<Products> CocukList { get; set; }


        public string KatBirAd { get; set; }
        public List<Products> UrunListe { get; set; }
        public List<ProductCatOne> KategoriBirListe { get; set; }
        public List<ProductCateTwo> KategoriIkiListe { get; set; }
    }
}