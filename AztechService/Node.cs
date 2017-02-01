using System.Collections.Generic;

namespace Merchant.Resolver
{
    public class Node
    {
        public string[] NodeType = {"Catalogue","Zone","Division", "Category", "Item","Image" };
        public enum TN {Catalogue,Zone,Division,Category,Item,Image};//type of node
        public TN TP { get; set; } //Node type
        public List<Feature> Features { get; set; } = new List<Feature>();
        public string PreferredName { get; set; }
        public string Logo { get; set; }
        public List<Node> Childs { get; set; } = new List<Node>();
        public string Name { get { return NodeType[(int)TP]; } }
        public string Id { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        
    }
}