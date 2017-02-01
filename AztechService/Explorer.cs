using Merchant.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AztechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Explorer : IExplorer
    {
        public String Explore(String currentNode)
        {
            DbResourceLocator locator = new DbResourceLocator();
            Node result = locator.Locate(currentNode);
            NodeSerializer ser = new NodeSerializer();
            ser.Format = (int)NodeSerializer.Formats.XML;
            String s = ser.GetXml(result);
            s = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
            return s;
        }

    }
}
