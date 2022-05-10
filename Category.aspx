<%@ Page Title="Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Web_App_1_Binary_Semantics.Category" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div>
        <asp:GridView ID="GridCategories" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="GridCategories_RowCommand">
            <Columns>

                <asp:TemplateField HeaderText="Category Id">
                    <ItemTemplate>
                        <asp:Label ID="LabelCategoryId" runat="server" Text='<%# Bind("category_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                        <asp:Label ID="LabelCategoryName" runat="server" Text='<%# Bind("category_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnUpdate" runat="server" CommandName="Update" CommandArgument='<%# Bind("category_id") %>' Text="Update" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Bind("category_id") %>' Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
     <hr />
    <div>
        <div>
            <asp:HiddenField ID="HiddenCategoryId" runat="server" />
        </div>
        <div>
            <asp:Label for="category_name" runat="server" Text="Label">Category Name: </asp:Label>
            <asp:TextBox ID="TextCategoryName" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="btn-group">
            <asp:Button ID="BtnSave" runat="server" class="btn btn-primary" Text="Save Category" OnClick="btnSave_Click" BorderColor="red" BorderStyle="Dotted" Width="250px" />
        </div>
        <div>
            <asp:CheckBox ID="chkcategory" runat="server" OnCheckedChanged="chkcategory_CheckedChanged" AutoPostBack="true" />
        </div>
        <div>
            <asp:DropDownList ID="DDlcategory" runat="server"></asp:DropDownList>
        </div>
     </div>

</asp:Content>
