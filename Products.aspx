<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Web_App_1_Binary_Semantics.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div class="form-group" style="margin-bottom:10px; margin:auto; margin-top:10px;">
           <asp:Button runat="server" ID="btnCreate" Text="Create Product" CssClass="btn btn-primary" PostBackUrl="/AddProduct.aspx" />
    </div>




     <div style="margin-top:20px;">
        <asp:GridView ID="GridProducts" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="GridProducts_RowCommand">
            <Columns>

                <asp:TemplateField HeaderText="Product_Id">
                    <ItemTemplate>
                        <asp:Label ID="LabelProductId" runat="server" Text='<%# Bind("product_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product Name">
                    <ItemTemplate>
                        <asp:Label ID="LabelProductName" runat="server" Text='<%# Bind("product_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                        <asp:Label ID="LabelCategoryName" runat="server" Text='<%# Bind("category_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brand Name">
                    <ItemTemplate>
                        <asp:Label ID="LabelBrandName" runat="server" Text='<%# Bind("brand_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="List Price">
                    <ItemTemplate>
                        <asp:Label ID="LabelListPrice" runat="server" Text='<%# Bind("list_price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnUpdate" runat="server" CommandName="Update" CommandArgument='<%# Bind("product_id") %>' Text="Update" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Bind("product_id") %>' Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        </div>


</asp:Content>
