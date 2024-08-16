using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class ProductDAL
    {
        string cf = ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString;
        SqlConnection conn;

        public ProductDAL()
        {
            conn = new SqlConnection(cf);
            conn.Open();    
        }
        public List<Product> GetAllProducts()
        {
            
            SqlDataAdapter adapter  = new SqlDataAdapter("Exec sp_show", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<Product> products = new List<Product>();
            foreach (DataRow dr in dt.Rows) {
                products.Add(new Product
                {
                    Id = int.Parse(dr["pid"].ToString()),
                    pname = dr["pname"].ToString(),
                    pcat= dr["pcat"].ToString(),
                    price = double.Parse(dr["price"].ToString())

                });
            }
            return products;
        }

        public void AddProduct(Product p)
        {
            string query = $"exec sp_insert {p.pname},{p.pcat},{p.price}";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
        }

        public void DeleteProduct(int id)
        {
            string query = $"exec sp_del {id}";
            SqlCommand cmd = new SqlCommand (query,conn);
            cmd.ExecuteNonQuery ();
        }

        public void UpdateProduct(Product p)
        {
            string query = $"exec sp_update {p.Id},{p.pname},{p.pcat},{p.price}";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery ();
        }

        

        
    }
}