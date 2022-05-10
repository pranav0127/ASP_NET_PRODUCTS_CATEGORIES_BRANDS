using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Web_App_1_Binary_Semantics.Database;
using Web_App_1_Binary_Semantics.Model;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_App_1_Binary_Semantics
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCategory();
                // GridCategories.DataSource = Session["ListCategories"];
                // GridCategories.DataBind();
            }

        }

        private void LoadCategory()
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "Select category_id, category_name from categories";
            cmd.Connection = DB_Category.conn();
            cmd.CommandType = CommandType.Text;
            List<Category_> categories = new List<Category_>();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var category = new Category_();
                        category.category_id = (int)reader["category_id"];
                        category.category_name = reader.GetString(reader.GetOrdinal("category_name"));
                        categories.Add(category);
                    }
                }
                // Session["ListCategories"] = categories;
                GridCategories.DataSource = categories;
                GridCategories.DataBind();
            }
        }

        private List<Category_> LoadCategory_()
        {
            List<Category_> categories = new List<Category_>();
            var cmd = new SqlCommand();
            cmd.CommandText = "Select category_id, category_name from categories";
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
                        var category = new Category_();
                        category.category_id = Convert.ToInt32(item["category_id"]);
                        category.category_name = Convert.ToString(item["category_name"]);
                        categories.Add(category);
                    }
                }

            }
            return categories;
        }


        private void Save_Category(string categoryname)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "Insert into categories(category_name) values(@categoryname)";
                cmd.Parameters.AddWithValue("@categoryname", categoryname);
                cmd.Connection = DB_Category.conn();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadCategory();
            }
            catch (Exception ex)
            {

            }
        }

        private void Update_Category(int id, string name)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "Update categories set category_name=@categoryname where category_id=@categoryid";
                cmd.Parameters.AddWithValue("@categoryname", name);
                cmd.Parameters.AddWithValue("@categoryid", id.ToString());
                cmd.Connection = DB_Category.conn();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadCategory();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HiddenCategoryId.Value))
            {
                Save_Category(TextCategoryName.Text);
                HiddenCategoryId.Value = string.Empty;
            }
                
            else
            {
                Update_Category(Convert.ToInt32(HiddenCategoryId.Value), TextCategoryName.Text);
            }
            HiddenCategoryId.Value = string.Empty;
            TextCategoryName.Text = string.Empty;
        }

        private void Delete_Category(int id)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM categories where category_id=@category_id";
                cmd.Parameters.AddWithValue("@category_id", id.ToString());
                cmd.Connection = DB_Category.conn();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                LoadCategory();
            }
            catch (Exception ex)
            {

            }
        }

        private Category_ LoadCategoryById(int id)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = "Select category_id, category_name FROM categories where category_id = @category_id";
            cmd.Connection = DB_Category.conn();
            cmd.Parameters.AddWithValue("@category_id", id.ToString());
            cmd.CommandType = CommandType.Text;
            var category = new Category_();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        category.category_id = (int)reader["category_id"];
                        category.category_name = reader.GetString(reader.GetOrdinal("category_name"));

                    }
                }
            }
            return category;
        }

        protected void GridCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                // var category = Session["ListCategories"] as List<Category_>;
                int id = Convert.ToInt32(e.CommandArgument);
                var selectedCategory = LoadCategoryById(id);
                if (selectedCategory != null)
                {
                    HiddenCategoryId.Value = selectedCategory.category_id.ToString();
                    TextCategoryName.Text = selectedCategory.category_name;
                }
            }
            else if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Delete_Category(id);
                LoadCategory();

            }
            e.Handled = true;
        }

        protected void chkcategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcategory.Checked)
            {
                DDlcategory.Items.Clear();
                var cate = LoadCategory_();
                foreach (var cat in cate)
                {
                    ListItem li = new ListItem();
                    li.Text = cat.category_name;
                    li.Value = cat.category_id.ToString();
                    DDlcategory.Items.Add(li);
                }
                AddNoneInStarting();
            }
            else
            {
                DDlcategory.Items.Clear();
                AddNoneInStarting();
            }
        }

        protected void AddNoneInStarting()
        {
            DDlcategory.Items.Insert(0, "None");
        }
    }
}