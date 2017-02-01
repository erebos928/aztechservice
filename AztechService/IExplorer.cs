using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace AztechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IExplorer
    {
        [OperationContract]
        [WebInvoke(Method ="POST",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        String Explore(String currentNode);

 
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "AztechService.ContractType".
    [DataContract]
    public class Catalogue
    {
        
        
        [DataMember, ]
        public string id { get; set; }
        
        [DataMember, XmlAttribute]
        public string preferredName { get; set; }
        [DataMember]
        public Zone Zone;
    }
    [DataContract]
    public class Zone
    {
        [DataMember]
       public Division Division;
    }
    [DataContract]
    public class Division
    {
       [DataMember, XmlAttribute]
        public string id;
       
        [DataMember, XmlAttribute]
        public string preferredName;
        [DataMember]
        public string Logo;

    }
}
