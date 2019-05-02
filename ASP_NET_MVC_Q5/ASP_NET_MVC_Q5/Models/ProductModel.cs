using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q5.Models
{
    public class ProductModel
    {
        
            public int Id { get; set; }
            public string Locale { get; set; }
            public string Product_Name { get; set; }
            public float Price { get; set; }
            public DateTime Create_Date { get; set; }
    
    }
}