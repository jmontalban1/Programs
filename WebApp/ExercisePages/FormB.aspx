<%@ Page Title="Query-StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormB.aspx.cs" Inherits="WebApp.ExercisePages.FormB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>A03-Programs| Gridview Lookup with Code-Behind</h1>

    <%-- Gridview for Form C --%>



    <div class="row col-md-12">
        <asp:DataList ID="MessageList" runat="server">
            <ItemTemplate>
                <%# Container.DataItem %>
            </ItemTemplate>
        </asp:DataList>
        <br />
    </div>

    <div class="col-md-2">
        <asp:Label ID="Label9" runat="server" Text="Enter partial program name:"></asp:Label><br />
        <asp:TextBox ID="SearchPartialName" runat="server"></asp:TextBox><br />
        <asp:Button ID="SearchProgram" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchProgram_Click" />
    </div>
    <div class="col-md-6">



        <asp:GridView ID="ProgramSelectionList" runat="server" AutoGenerateColumns="False"
            CssClass="table" GridLines="Horizontal" BorderStyle="None" AllowPaging="True" OnPageIndexChanging="ProgramSelectionList_PageIndexChanging" PageSize="5">
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
    </div>

</asp:Content>
