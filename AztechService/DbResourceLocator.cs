using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merchant.Resolver
{
    class DbResourceLocator : ResourceLocator

    {
        static readonly String[] features = { "Id", "Price", "Currency", "Description", "Code", "Title", "Voltage", "Weight", "Brand", "Color", "Size", "Image" };
        public Node Locate(string currNode)
        {
            // search in categories
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = AztechService.Vendor.Default.ConnString;// @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\csharp\AztechService\AztechService\db\verdana.mdf;Integrated Security=True;Connect Timeout=30";
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from category where Id=@currNode";
            command.Parameters.AddWithValue("@currNode", currNode);
            command.Connection = conn;
            conn.Open();
            SqlDataReader rd = command.ExecuteReader();
            Node current = new Node();
            current.TP = Node.TN.Category;


            if (!rd.HasRows)
                return null;
            //the node itself
            while (rd.Read())
            {
                current.TP = Node.TN.Category;
                current.Id = rd.GetString(0);
                current.PreferredName = rd.GetString(1);
            }

            rd.Close();
            // direct children
            command = new SqlCommand();
            command.CommandText = "select * from Category where Parent=@currentId";
            command.Parameters.AddWithValue("@currentId", current.Id);
            command.Connection = conn;
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                Node node = new Node();
                node.TP = Node.TN.Category;
                node.Id = rd.GetString(0);
                node.PreferredName = rd.GetString(1);
                current.Childs.Add(node);
            }
            rd.Close();
            // items
            command = new SqlCommand();
            command.CommandText = "select * from Articles where code=@currNode";
            command.Parameters.AddWithValue("@currNode", currNode);
            command.Connection = conn;

            rd = command.ExecuteReader();
            while (rd.Read())
            {
                Node item = new Node();
                item.TP = Node.TN.Item;
                item.Id = rd.GetString(0);
                for (int i = 1; i <= 11; i++)
                {
                    if (!rd.IsDBNull(i))
                        AddFeature(i, item, rd.GetString(i));
                }
                current.Childs.Add(item);
            }


            rd.Close();
            //the parents

            while ((current.Id != "-1"))
            {

                command = new SqlCommand();
                command.CommandText = "select * from Category where Id=@currentId";
                command.Parameters.AddWithValue("@currentId", current.Id);
                command.Connection = conn;
                rd = command.ExecuteReader();
                while (rd.Read())
                {
                    Node node = new Node();
                    node.TP = Node.TN.Category;

                    if (!rd.IsDBNull(2))
                    {
                        node.Id = rd.GetString(2);
                        if (current.PreferredName == null)
                            current.PreferredName = rd.GetString(1);
                        node.Childs.Add(current);
                        current = node;
                    }
                }
                rd.Close();
            }
            // Division node
            Node division = new Node();
            division.TP = Node.TN.Division;
            command = new SqlCommand();
            command.CommandText = "select * from Identification";
            command.Parameters.AddWithValue("@currentId", current.Id);
            command.Connection = conn;
            rd = command.ExecuteReader();
            while (rd.Read())
            {

                if (!rd.IsDBNull(2))
                {
                    division.Id = rd.GetString(0);
                    division.PreferredName = rd.GetString(1);
                    if (!rd.IsDBNull(2))
                        division.Logo = rd.GetString(2);
                    division.Childs.Add(current);
                    current = division;
                }
            }
            rd.Close();
            conn.Close();
            Node zone = new Node();
            zone.TP = Node.TN.Zone;
            zone.Childs.Add(division);
            Node catalogue = new Node();
            catalogue.Childs.Add(zone);

            return catalogue;
        }
        void AddFeature(int f, Node item, String val)
        {
            if (f == 4)//code not assumed
                return;
            if (f == 11)
            {
                Image image = new Image(val);
                item.Images.Add(image);
                return;
            }
            Feature feature = new Feature();
            feature.PreferredName = GetName(f);
            feature.Identifier = f.ToString();
            feature.Value = val;
            item.Features.Add(feature);
        }
        String GetName(int g)
        {
            return features[g];
        }

    }
}
