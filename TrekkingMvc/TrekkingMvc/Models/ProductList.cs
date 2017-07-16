using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrekkingMvc.Models.Common;

namespace TrekkingMvc.Models
{
    public class ProductList : IRepository<Products>
    {
        TREKKINGDBEntities db = new TREKKINGDBEntities();

        /// <summary>
        /// Ürün detayını getirir
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Products mtdProductDt(int ID)
        {

            return db.Products.FirstOrDefault(x => x.ProductID == ID);
        }
        /// <summary>
        /// Ürün bedenini getirir
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Size> mtdProductDtSize(int ID)
        {
            
            List<Size> szList = new List<Size>();

            var arama = (from p in db.Products
                         join ps in db.PurSize
                         on p.ProductID equals ps.ProductID
                         join s in db.Size
                         on ps.SizeID equals s.SizeID
                         where p.ProductID == ID
                         select new
                         {
                             s.SizeID,
                             s.SizeName

                         }).ToList();

            foreach (var item in arama)
            {
                Size sz = new Size();

                sz.SizeID = item.SizeID;
                sz.SizeName = item.SizeName;
               
                szList.Add(sz);
            }
            return szList;
        }

        public List<Products> Listele()
        {
            List<Products> lst = db.Products.ToList();
            return lst;
        }

        /// <summary>
        /// Bu methodta ürünleri 1.kategoriye göre listelemenize yarar.1-Erkek,2-Kadın,3-Çocuk,4-Hepsi
        /// </summary>
        /// <param name="deger">Aramak istediğiniz kategoriID yi yazınız</param>
        /// <returns></returns>
        public List<Products> KatBirUrunListele(int deger)
        {
            List<Products> lst = db.Products.Where(x => x.ProductCatOneID == deger || x.ProductCatOneID == 4).ToList();
            return lst;
        }
        /// <summary>
        /// Bu methodta ürünleri 1.kategoriye ve 2.kategoriye göre listelersiniz.
        /// </summary>
        /// <param name="deger">ProductCatOneID</param>
        /// <param name="deger2">ProductCatTwoID</param>
        /// <returns></returns>
        public List<Products> KatIkiUrunListele(int deger, int deger2)
        {
            List<Products> lst = db.Products.Where(x => x.ProductCatOneID == deger && x.ProductCatTwoID == deger2).ToList();
            return lst;
        }
        /// <summary>
        /// Tüm kategori1 in listesini getirir
        /// </summary>
        /// <returns></returns>
        public List<ProductCatOne> KatBirListe()
        {
            List<ProductCatOne> lst = db.ProductCatOne.ToList();
            return lst;
        }
        /// <summary>
        /// Tüm kategori2 in listesini getirir 
        /// </summary>
        /// <returns></returns>
        public List<ProductCateTwo> KatIkiListe()
        {
            List<ProductCateTwo> lst = db.ProductCateTwo.ToList();
            return lst;
        }
        public int Guncelle(Products deger)
        {
            throw new NotImplementedException();
        }
    }
}