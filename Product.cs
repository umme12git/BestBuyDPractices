﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyDPractices
{
    public class Product
    {
        public Product()
        {

        }
        public int ProductID {get; set;}
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; } = 0;
        public string StockLevel { get; set; } = null;


    }
}
