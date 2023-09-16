﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CustomerBasket
    {

        public CustomerBasket()
        {
        }

        //this would let the Id generated by the customer ie FE
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();


        public CustomerBasket(string id)
        {
            Id = id;
           
        }

      
    }
}
