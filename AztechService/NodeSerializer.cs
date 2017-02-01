using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchant.Resolver
{
    public class NodeSerializer
    {
        public int Format { get; set; }
        public enum Formats { JSON,XML}
        public String GetXml(Node node)
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Serialize(node);
        }
        public string Serialize(Node node)
        {
            String s = "";

           // if ((node.Id != "-1"))
            //{
                s = "<" + node.Name;
                if (node.PreferredName != null)
                    s = s + " preferredName=\"" + node.PreferredName + "\"";
                if (node.Id != null)
                    s = s + " id=\"" + node.Id + "\"";
                s = s + ">";
                if (node.Logo != null)
                    s += "<Logo>" + node.Logo + "</Logo>";
                foreach (Feature f in node.Features)
                {
                    s += "<Feature id=\"" + f.Identifier + "\" preferredName=\"" + f.PreferredName + "\">" + f.Value + "</Feature>"; 
                }
                foreach (Image img in node.Images)
                {
                    s += "<Image>" + img.Url + "</Image>";
                }

                foreach (Node n in node.Childs)
                {
                    s = s + Serialize(n);
                }
                s = s + "</" + node.Name + ">";
            //}
            //else
              //  foreach (Node n in node.Childs)
                //    s += Serialize(n);
            return s;
        }
    }
}