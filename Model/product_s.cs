using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_App_1_Binary_Semantics.Model
{
    public class product_s
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Category_Name { get; set; }
        public string Brand_Name { get; set; }
        public double List_Price { get; set; }
    }
}