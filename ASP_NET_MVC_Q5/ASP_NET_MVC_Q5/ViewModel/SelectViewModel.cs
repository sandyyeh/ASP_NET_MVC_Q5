using ASP_NET_MVC_Q5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q5.ViewModel
{
    public class SelectViewModel
    {
        public List<ProductModel> productModel { get; set; }
        public string Locale { get; set; }
        public IEnumerable<SelectListItem> LocaleListItem { get; set; }
        public string Product_Name { get; set; }
        public float Price { get; set;}
    }
   
}