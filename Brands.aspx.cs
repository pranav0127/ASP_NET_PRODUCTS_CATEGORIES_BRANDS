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
    public partial class Brands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadBrands();
            }
                

        }

        private void LoadBrands()
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "Select brand_id, brand_name from brands";
            cmd.Connection = DB_Category.conn();
            cmd.CommandType = CommandType.Text;
            List<Brands_> brands = new List<Brands_>();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var brand = new Brands_();
                        brand.brand_id = (int)reader["brand_id"];
                        brand.brand_name = reader.GetString(reader.GetOrdinal("brand_name"));
                        brands.Add(brand);
                    }
                }
                GridBrands.DataSource = brands;
                GridBrands.DataBind();
            }
        }

        private List<Brands_> LoadBrands_List()
        {
            List<Brands_> brands = new List<Brands_>();
            var cmd = new SqlCommand();
            cmd.CommandText = "Select brand_id, brand_name from brands";
            cmd.Connection = DB_Category.conn();
            cmd.CommandType = CommandType.Text;
            using (var dt = new DataTable())
            {
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (da != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        var brand = new Brands_();
                        brand.brand_id = Convert.ToInt32(item["brand_id"]);
                        brand.brand_name = Convert.ToString(item["brand_name"]);
                        brands.Add(brand);
                    }
                }

            }
            return brands;
        }

        

        private void Update_Brand(int id, string name)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "Update brands set brand_name=@brandname where brand_id=@brandid";
                cmd.Parameters.AddWithValue("@brandname", name);
                cmd.Parameters.AddWithValue("@brandid", id.ToString());
                cmd.Connection = DB_Category.conn();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadBrands();
            }
            catch (Exception ex)
            {

            }
        }

        private void Save_Brands(string brandname)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "Insert into brands(brand_name) values(@brandname)";
                cmd.Parameters.AddWithValue("@brandname", brandname);
                cmd.Connection = DB_Category.conn();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadBrands();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HiddenBrandsId.Value))
            {
                Save_Brands(TextBrandName.Text);
                
                
            }
                
            else
            {
                Update_Brand(Convert.ToInt32(HiddenBrandsId.Value), TextBrandName.Text);
            }
            HiddenBrandsId.Value = string.Empty;
            TextBrandName.Text = string.Empty;
        }

        private void Delete_Brands(int id)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM brands where brand_id=@brand_id";
                cmd.Parameters.AddWithValue("@brand_id", id.ToString());
                cmd.Connection = DB_Category.conn();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadBrands();
            }
            catch (Exception ex)
            {

            }
        }

        private Brands_ LoadBrandById(int id)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "Select brand_id, brand_name FROM brands where brand_id = @brand_id";
            cmd.Connection = DB_Category.conn();
            cmd.Parameters.AddWithValue("@brand_id", id.ToString());
            cmd.CommandType = CommandType.Text;
            var brand = new Brands_();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        brand.brand_id = (int)reader["brand_id"];
                        brand.brand_name = reader.GetString(reader.GetOrdinal("brand_name"));
                    }
                }
            }
            return brand;
        }

        protected void GridBrands_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
               
                int id = Convert.ToInt32(e.CommandArgument);
                var selectedBrand = LoadBrandById(id);
                if (selectedBrand != null)
                {
                    HiddenBrandsId.Value = selectedBrand.brand_id.ToString();
                    TextBrandName.Text = selectedBrand.brand_name;
                }
            }
            else if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Delete_Brands(id);
                LoadBrands();

            }
            e.Handled = true;
        }

        protected void chkbrands_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbrands.Checked)
            {
                DDlbrands.Items.Clear();
                var cate = LoadBrands_List();
                foreach (var cat in cate)
                {
                    ListItem li = new ListItem();
                    li.Text = cat.brand_name;
                    li.Value = cat.brand_id.ToString();
                    DDlbrands.Items.Add(li);
                }
                AddNoneInStarting();
            }
            else
            {
                DDlbrands.Items.Clear();
                AddNoneInStarting();
            }
        }

        protected void AddNoneInStarting()
        {
            DDlbrands.Items.Insert(0, "None");
        }


    }


}