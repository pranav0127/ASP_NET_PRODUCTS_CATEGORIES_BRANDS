using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_App_1_Binary_Semantics.Database;
using Web_App_1_Binary_Semantics.Model;

namespace Web_App_1_Binary_Semantics
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProducts();
            }
                
        }

        public string QuerySQL = "SELECT p.product_id, p.product_name, c.category_name, b.brand_name, p.list_price FROM products as p INNER JOIN categories as c on c.category_id = p.category_id INNER JOIN brands as b on b.brand_id = p.brand_id;";
        private void LoadProducts()
        {
            var cmd = new SqlCommand();
            cmd.CommandText = QuerySQL;
            cmd.Connection = DB_Category.conn();
            cmd.CommandType = CommandType.Text;
            List<product_s> prods = new List<product_s>();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var product = new product_s();
                        product.Product_Id = (int)reader["product_id"];
                        product.Product_Name = reader.GetString(reader.GetOrdinal("product_name"));
                        product.Brand_Name = reader.GetString(reader.GetOrdinal("brand_name"));
                        product.Category_Name = reader.GetString(reader.GetOrdinal("category_name"));
                        double listprice = Convert.ToDouble(reader["list_price"]);
                        product.List_Price = Math.Round(listprice, 2);
                        prods.Add(product);
                    }
                }
                GridProducts.DataSource = prods;
                GridProducts.DataBind();
            }
        }

        protected void GridProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Delete_Products(id);
                LoadProducts();

            }
            else if (e.CommandName == "Update")
            {
                Response.Redirect($"/AddProduct.aspx?id={e.CommandArgument}");
            }
            e.Handled = true;


        }

        private void Delete_Products(int id)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM products WHERE product_id=@id";
                cmd.Parameters.AddWithValue("@id", id.ToString());
                cmd.Connection = DB_Category.conn();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        //protected void btnCreate_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("/AddProduct.aspx");
        //}
    }
}