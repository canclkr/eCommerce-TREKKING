using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrekkingMvc.Models.ViewModel;
using System.Web.Mvc;
using System.Web;

namespace TrekkingMvc.Models
{
    public class OrderOparations
    {
        TREKKINGDBEntities db = new TREKKINGDBEntities();
        /// <summary>
        /// ID si göderilen ürünü sepete ekler
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public OrderVM mtdAddtoBasket(int productID, string size, int quantity)
        {

            OrderVM od = new OrderVM();
            Products prc = new Products();
            List<OrderVM> odList = new List<OrderVM>();


            if (HttpContext.Current.Session["Basket"] != null)
            {
                odList = (List<OrderVM>)HttpContext.Current.Session["Basket"];

                bool varmi = false;
                foreach (var item in odList)
                {
                    if (item.prcID == productID && item.prcSize == size)
                    {
                        varmi = true;
                    }
                }

                if (varmi)
                {
                    foreach (var item in odList)
                    {
                        
                        if (item.prcID == productID && item.prcSize == size)
                        {
                            od.prcID = item.prcID;
                            od.prcName = item.prcName;
                            od.prcDesription = item.prcDesription;
                            od.prcQuantity = quantity;


                            item.prcQuantity += quantity;
                            item.prcSubTotal = item.prcQuantity * item.prcUnitPrice;
                            HttpContext.Current.Session["Basket"] = odList;
                        }
                    }
                }
                else
                {
                    prc = db.Products.FirstOrDefault(x => x.ProductID == productID);
                    od.prcID = prc.ProductID;
                    od.prcName = prc.ProductName;
                    od.prcDesription = prc.Description;
                    od.prcQuantity = quantity;
                    od.prcSize = size;
                    od.prcUnitPrice = Convert.ToDecimal(prc.UnitPrice);
                    od.prcSubTotal = od.prcQuantity * od.prcUnitPrice;
                    odList.Add(od);


                    HttpContext.Current.Session["Basket"] = odList;
                }
            }
            else
            {
                prc = db.Products.FirstOrDefault(x => x.ProductID == productID);
                od.prcID = prc.ProductID;
                od.prcName = prc.ProductName;
                od.prcDesription = prc.Description;
                od.prcQuantity = quantity;
                od.prcSize = size;
                od.prcUnitPrice = Convert.ToDecimal(prc.UnitPrice);
                od.prcSubTotal = od.prcQuantity * od.prcUnitPrice;
                odList.Add(od);


                HttpContext.Current.Session["Basket"] = odList;
            }

            return od;
        }

        /// <summary>
        /// Sepetteki toplam ürün sayısını getirir
        /// </summary>
        /// <returns></returns>
        public int mtdTotalProducCount()
        {
            List<OrderVM> odList = new List<OrderVM>();
            odList = (List<OrderVM>)HttpContext.Current.Session["Basket"];
            int sayi = 0;
            foreach (var item in odList)
            {
                sayi += item.prcQuantity;
            }
            return sayi;
        }
        public int mtdSepetGuncelle(int _prcID, string _size, int _quantity)
        {
            
            int sayi = 0;
            List<OrderVM> odList = new List<OrderVM>();
            odList = (List<OrderVM>)HttpContext.Current.Session["Basket"];
            foreach (var item in odList)
            {
                if (item.prcID == _prcID && item.prcSize == _size)
                {
                    int adt = (int)db.Products.FirstOrDefault(x => x.ProductID == _prcID).ProductQuantity;
                    if (adt < _quantity)
                    {
                        return sayi;
                    }
                    item.prcQuantity = _quantity;
                    item.prcSubTotal = item.prcQuantity * item.prcUnitPrice;
                    HttpContext.Current.Session["Basket"] = odList;
                    sayi = 1;
                }
            }

            return sayi;
        }
        public int mtdSepetSil(int _prcID, string _size)
        {
            List<OrderVM> odList = new List<OrderVM>();
            odList = (List<OrderVM>)HttpContext.Current.Session["Basket"];
            foreach (var item in odList)
            {
                if (item.prcID == _prcID && item.prcSize == _size)
                {
                    odList.Remove(item);
                    if (odList.Count == 0)
                    {
                        HttpContext.Current.Session.Remove("Basket");
                    }
                    return 1;
                }
            }

            return 0;
        }
        public int mtdAdresEkle(string adSoyad, string ulke, string sehir, string postaKodu, string adres)
        {
            try
            {
                AddressVM ad = new AddressVM();
                ad.ContactName = adSoyad;
                ad.Country = ulke;
                ad.City = sehir;
                ad.PostCode = postaKodu;
                ad.Address = adres;
                HttpContext.Current.Session["Address"] = ad;
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        /// <summary>
        /// Siparişi veritabanına kaydeder
        /// </summary>
        /// <returns></returns>
        public int SiparisTamamla()
        {
            try
            {
                Random rnd = new Random();
                string orderNumber = "";
                for (int i = 0; i < 10; i++)
                {
                    int sayi = 0;
                    sayi = rnd.Next(9);
                    orderNumber += sayi.ToString();
                }
                HttpContext.Current.Session["OrderNumber"] = orderNumber;
                List<OrderVM> odList = new List<OrderVM>();
                AddressVM add = new AddressVM();
                odList = (List<OrderVM>)HttpContext.Current.Session["Basket"];
                add = (AddressVM)HttpContext.Current.Session["Address"];

                foreach (var item in odList)
                {
                    int userID = (int)HttpContext.Current.Session["UserID"];
                    db.spStokAzalt(item.prcID, item.prcQuantity);
                    db.spAddOrder(userID, item.prcID, item.prcQuantity, item.prcSubTotal, add.Country, add.City, add.PostCode, add.Address, add.ContactName, DateTime.Now, orderNumber, item.prcSize);
                }
                HttpContext.Current.Session.Remove("Basket");
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        public OrderDetailVM SiparisDetay(string OrderNumber)
        {
            TREKKINGDBEntities db = new TREKKINGDBEntities();
            OrderDetailVM odvm = new OrderDetailVM();
            //List<OrderVM> odrVMlist = new List<OrderVM>();
            odvm.ProductList = new List<OrderVM>();
            Orders od = new Orders();
            od = db.Orders.FirstOrDefault(x => x.OrderNumber == OrderNumber);

            var OdrList = (from o in db.Orders
                           join p in db.Products
                           on o.ProductID equals p.ProductID
                           join u in db.Users
                           on o.UserID equals u.UserID
                           join us in db.UserDetails
                           on u.UserID equals us.UserID
                           where o.OrderNumber == OrderNumber
                           select new
                           {
                               us.Name_Surname,
                               u.Email,
                               o.ContactName,
                               o.Country,
                               o.City,
                               o.PostCode,
                               o.FullAddress,
                               o.OrderDate,
                               o.OrderNumber,
                               p.ProductName,
                               p.UnitPrice,
                               o.OrderPrcSize,
                               o.Quantity,
                               o.SubTotal


                           }).ToList();


            foreach (var item in OdrList)
            {
                odvm.UserName = item.Name_Surname;
                odvm.Email = item.Email;
                odvm.ContactName = item.ContactName;
                odvm.Country = item.Country;
                odvm.City = item.City;
                odvm.PostCode = item.PostCode;
                odvm.FullAddress = item.FullAddress;
                odvm.OrderDate = Convert.ToDateTime(item.OrderDate);
                odvm.OrderNumber = item.OrderNumber;

                OrderVM odrvm = new OrderVM();
                odrvm.prcName = item.ProductName;
                odrvm.prcUnitPrice = Convert.ToDecimal(item.UnitPrice);
                odrvm.prcSize = item.OrderPrcSize;
                odrvm.prcQuantity = Convert.ToInt32(item.Quantity);
                odrvm.prcSubTotal = Convert.ToDecimal(item.SubTotal);
                odvm.ProductList.Add(odrvm);
            }


            return odvm;
        }
        public List<MyOrderVM> Siparislerim(int userID)
        {
            List<MyOrderVM> myodList = new List<MyOrderVM>();

            var OdrList = (from o in db.Orders
                           join p in db.Products
                           on o.ProductID equals p.ProductID
                           where o.UserID == userID
                           orderby o.OrderNumber
                           select new
                           {
                               o.OrderID,
                               p.ProductName,
                               p.Description,
                               o.Quantity,
                               p.UnitPrice,
                               o.SubTotal,
                               o.OrderNumber

                           }).ToList();


            foreach (var item in OdrList)
            {
                MyOrderVM myod = new MyOrderVM();
                myod.OrderID = item.OrderID;
                myod.ProductName = item.ProductName;
                myod.Description = item.Description;
                myod.Quantity = Convert.ToInt32(item.Quantity);
                myod.UnitPrice = Convert.ToDecimal(item.UnitPrice);
                myod.SubTotal = Convert.ToDecimal(item.SubTotal);
                myod.OrderNumber = item.OrderNumber;
                myodList.Add(myod);
            }

            return myodList;
        }


    }
}