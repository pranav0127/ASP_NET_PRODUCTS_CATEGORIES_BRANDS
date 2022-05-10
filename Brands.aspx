<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="Web_App_1_Binary_Semantics.Brands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:GridView ID="GridBrands" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="GridBrands_RowCommand">
            <Columns>

                <asp:TemplateField HeaderText="Brands_Id">
                    <ItemTemplate>
                        <asp:Label ID="LabelBrandsId" runat="server" Text='<%# Bind("brand_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brands_Name">
                    <ItemTemplate>
                        <asp:Label ID="LabelBrandsName" runat="server" Text='<%# Bind("brand_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnUpdate" runat="server" CommandName="Update" Text="Update" CommandArgument='<%# Bind("brand_id") %>'></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="BtnDelete" runat="server" CommandName="Delete" Text="Delete" CommandArgument='<%# Bind("brand_id") %>'></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />

    <div>
        <div>
            <asp:HiddenField ID="HiddenBrandsId" runat="server" />
        </div>
        <div>
            <asp:Label for="Brand_name" ID="Label1" runat="server" Text="Label">Brand Name: </asp:Label>
            <asp:TextBox ID="TextBrandName" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="btn-group">
            <asp:Button ID="BtnSave" runat="server" class="btn btn-primary" Text="Save Brand" OnClick="btnSave_Click" Width="350px" />
        </div>
        <br />
        <div>
            <asp:CheckBox ID="chkbrands" runat="server" OnCheckedChanged="chkbrands_CheckedChanged" AutoPostBack="true" />
        </div>
        <br />
        <div>
            <asp:DropDownList ID="DDlbrands" runat="server"></asp:DropDownList>
        </div>

    </div>

</asp:Content>
