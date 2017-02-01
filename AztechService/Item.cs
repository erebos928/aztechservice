using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Resolver
{
    public class Item
    {
        public String Identifier { get; set; }
        public Item(String id)
        {
            Identifier = id;
        }
    }
}