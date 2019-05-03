using ASP_NET_MVC_Q5.Models;
using ASP_NET_MVC_Q5.ViewModel;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q5.Controllers
{
    public class HomeController : Controller
    {


        List<SelectListItem> items = new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "Unite State", Value = "US"},
                    new SelectListItem(){Text = "Germany",Value = "DE"},
                    new SelectListItem(){Text = "Canada",Value = "CA"},
                    new SelectListItem(){Text = "Spain",Value = "ES"},
                    new SelectListItem(){Text = "France",Value = "FR"},
                    new SelectListItem(){Text = "Japan",Value = "JP"}
                };



        public ViewResult Index(int? page,string searchLocale, string searchName, string searchMinPrice, string searchMaxPrice)
        {

            var data = new List<ProductModel>();
            data = list();

            //搜尋結果列表
            var searchResult = new List<string>();

            
            var query = from d in data
                        orderby d.Id
                        select d.Product_Name;

            var query2 = from d in data
                         join o in items on d.Locale equals o.Value
                         orderby d.Locale
                         select o.Value;

            var select = from m in data
                         select m;

            searchResult.AddRange(query.Distinct());
            ViewBag.SearchLocale = new SelectList(query2.Distinct());

         

            //輸入搜尋條件
            if (!String.IsNullOrEmpty(searchLocale))
            {
                select = select.Where(s => s.Locale.Contains(searchLocale));
            }

            if (!String.IsNullOrEmpty(searchName))
            {
                select = select.Where(s => s.Product_Name.ToLower().Contains(searchName.ToLower()));
            }

            if (!string.IsNullOrEmpty(searchMinPrice)&&float.TryParse(searchMinPrice, out float num))
            {
                float price = Convert.ToSingle(searchMinPrice);
                select = select.Where(x => x.Price >= price);

            }
            if (!string.IsNullOrEmpty(searchMaxPrice)&& float.TryParse(searchMaxPrice,out float num2))
            {
                float price = Convert.ToSingle(searchMaxPrice);
                select = select.Where(x => x.Price <= price);                
            }

            ViewBag.searchName = searchName;
            ViewBag.searchMinPrice = searchMinPrice;
            ViewBag.searchMaxPrice = searchMaxPrice;

            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //var result = select.ToPagedList(pageNumber, pageSize);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(select.ToPagedList(pageNumber, pageSize));



            //return View(result);
            
        }


        //讀取 data.json
        public List<ProductModel> list()
        {
            string file = Server.MapPath("~/App_Data/data.json");
            string json = System.IO.File.ReadAllText(file);
            List<ProductModel> _list = JsonConvert.DeserializeObject<List<ProductModel>>(json);


            return _list;
        }
    }
}