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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkbrands();
                chkcategories();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                if (id > 0)
                {
                    LoadProducts(id);
                }
                
            }
        }

       

        private void LoadProducts(int id)
        {
            var cmd = new SqlCommand();
            cmd.Connection = DB_Category.conn();
            cmd.CommandText = "Load_Products";
            cmd.Parameters.AddWithValue("@PRODUCT_ID", id.ToString());
            cmd.CommandType = CommandType.StoredProcedure;
            using (var dt = new DataTable())
            {
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    HiddenId.Value = id.ToString();
                    LabelProductName.Value = Convert.ToString(row["product_name"]);
                    DDLBrandName.SelectedValue = Convert.ToString(row["brand_id"]);
                    DDLCategoryName.SelectedValue = Convert.ToString(row["category_id"]);
                    LabelListPrice.Value = Convert.ToString(row["list_price"]);
                    LabelModelYear.Value = Convert.ToString(row["model_year"]);
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "Product_Upsert";
                if (!string.IsNullOrEmpty(HiddenId.Value))
                {
                    cmd.Parameters.AddWithValue("@Id", HiddenId.Value);
                }

                cmd.Parameters.AddWithValue("@Product_Name", LabelProductName.Value);
                cmd.Parameters.AddWithValue("@Brand_Id", DDLBrandName.SelectedValue);
                cmd.Parameters.AddWithValue("@Category_Id", DDLCategoryName.SelectedValue);
                cmd.Parameters.AddWithValue("@List_Price", LabelListPrice.Value);
                cmd.Parameters.AddWithValue("Model_Year", LabelModelYear.Value);
                cmd.Connection = Database.DB_Category.conn();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                Response.Redirect("/Products.aspx");

            }
            catch (Exception ex)
            {

            }
            HiddenId.Value = string.Empty;
            LabelProductName.Value = string.Empty;
            LabelModelYear.Value = string.Empty;
            LabelListPrice.Value = string.Empty;
            DDLBrandName.SelectedValue = string.Empty;
            DDLCategoryName.SelectedValue = string.Empty;
        }

        protected void AddNoneInStarting_Brand()
        {
            DDLBrandName.Items.Insert(0, "None");
        }
        protected void AddNoneInStarting_Category()
        {
            DDLCategoryName.Items.Insert(0, "None");
        }

        protected void chkcategories()
        {
            DDLCategoryName.Items.Clear();
            var category = new List<Category_>();
            var cmd = new SqlCommand();
            cmd.Connection = Database.DB_Category.conn();
            cmd.CommandText = "Load_Categories";
            cmd.CommandType = CommandType.StoredProcedure;
            using (var dt = new DataTable())
            {
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (da != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        DDLCategoryName.Items.Add(new ListItem
                        {
                            Text = Convert.ToString(item["category_name"]),
                            Value = Convert.ToString(item["category_id"])
                        });
                    }
                    AddNoneInStarting_Category();
                }
            }
        }

        protected void chkbrands()
        {
            DDLBrandName.Items.Clear();
            var brand = new List<Brands_>();
            var cmd = new SqlCommand();
            cmd.Connection = Database.DB_Category.conn();
            cmd.CommandText = "Load_Brands";
            cmd.CommandType = CommandType.StoredProcedure;
            using (var dt = new DataTable())
            {
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (da != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        DDLBrandName.Items.Add(new ListItem
                        {
                            Text = Convert.ToString(item["brand_name"]),
                            Value = Convert.ToString(item["brand_id"])
                        });
                    }
                    AddNoneInStarting_Brand();
                }
            }
        }
    }
}