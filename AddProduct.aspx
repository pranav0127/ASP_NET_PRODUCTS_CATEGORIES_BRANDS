<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Web_App_1_Binary_Semantics.AddProduct" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="HiddenId" />
    <br />
    <br />
    <br />

    <div class="form-floating mb-3">
        <label for="Product_name" runat="server">Product Name</label>
        <input type="text" class="form-control" runat="server" id="LabelProductName" placeholder="Product Name">
    </div>
    <br />

    <div class="form-floating">
         <label for="Category_Name" runat="server">Category name</label>
         <asp:DropDownList ID="DDLCategoryName" class="form-control" runat="server"></asp:DropDownList>
    </div>
    <br />

    <div class="form-floating">
         <label for="Brand_Name" runat="server">Brand name</label>
         <asp:DropDownList ID="DDLBrandName" class="form-control" runat="server"></asp:DropDownList>
    </div>
    <br />

    <div class="form-floating">
        <label for="List_Price" runat="server">List Price</label>
        <input type="text" class="form-control" runat="server" id="LabelListPrice" placeholder="List Price">
    </div>
    <br />

    <div class="form-floating">
        <label for="Model_Year" runat="server">Model Year</label>
        <input type="text" class="form-control" runat="server" id="LabelModelYear" placeholder="Model year">
    </div>
    <br />


    <div class="form-group">
        <div class="btn-group">
            <asp:Button ID="BtnSave" runat="server" class="btn btn-primary" Text="Save Brand" OnClick="BtnSave_Click" Width="350px" />
        </div>
    </div>
       <br />
        
        
        
       <div class="form-group">
           <asp:LinkButton runat="server" ID="LinkBtnPro" Text="Return to Products" PostBackUrl="~/Products.aspx"/>
       </div>
    




</asp:Content>
