using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Resolver

{
    public class Image
    {
        public Image(String url)
        {
            Url = url;
        }
        public String Url { get; set; }
    }
}
