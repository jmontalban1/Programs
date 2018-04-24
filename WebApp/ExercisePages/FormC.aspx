<%@ Page Title="ODS- StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormC.aspx.cs" Inherits="WebApp.ExercisePages.FormC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>A03-Programs| ObjectDataSource Search & Display with a Gridview</h1>

 


    <asp:DropDownList ID="School" runat="server" DataSourceID="SchoolDataSource" DataTextField="SchoolName" DataValueField="SchoolCode"></asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Search" />
    <asp:ObjectDataSource ID="SchoolDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="School_List" TypeName="Star_TEDSystem.BLL.SchoolController"></asp:ObjectDataSource>


    <asp:GridView ID="ProgramSelectionList" runat="server" AutoGenerateColumns="False"
        CssClass="table" GridLines="Horizontal" BorderStyle="None" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="ProgramID" runat="server"
                        Text='<%# Eval("ProgramID") %>'
                        Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Program Name">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server"
                        Text='<%# Eval("ProgramName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Diploma Name">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server"
                        Text='<%# Eval("DiplomaName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="School Code">
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server"
                        Text='<%# Eval("SchoolCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tuition">
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server"
                        Text='<%# Eval("Tuition") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="International Tuition">
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server"
                        Text='<%# Eval("InternationalTuition") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <EmptyDataTemplate>
            No data available for supplied product search string
        </EmptyDataTemplate>
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
    </asp:GridView>



</asp:Content>
