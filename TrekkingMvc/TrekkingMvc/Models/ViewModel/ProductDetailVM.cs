using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrekkingMvc.Models.ViewModel
{
    public class ProductDetailVM
    {

        public Products ProductDt { get; set; }
        public List<Size> Sizes { get; set; }
        public List<ProductCatOne> KategoriBirListe { get; set; }
        public List<ProductCateTwo> KategoriIkiListe { get; set; }

    }
}