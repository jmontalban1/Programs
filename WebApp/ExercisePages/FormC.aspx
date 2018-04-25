<%@ Page Title="ODS- StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormC.aspx.cs" Inherits="WebApp.ExercisePages.FormC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>A03-Programs| ObjectDataSource Search & Display with a Gridview</h1>


    <asp:ObjectDataSource ID="SchoolCodeODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="School_List" TypeName="Star_TEDSystem.BLL.SchoolController"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SchoolDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="School_List" TypeName="Star_TEDSystem.BLL.SchoolController"></asp:ObjectDataSource>
    <div class="row">
        <div class="col-md-6">
            <asp:DropDownList ID="School" runat="server" DataSourceID="SchoolDataSource" DataTextField="SchoolName" DataValueField="SchoolCode" AppendDataBoundItems="true">
                <asp:ListItem>Select...</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Search" runat="server" Height="25px" Text="Search" OnClick="Search_Click" />
        </div>
        <asp:DataList ID="MessageList" runat="server">          
            
            <ItemTemplate>
                <%# Container.DataItem %>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
        <div class="col-md-12">
            <asp:GridView ID="ProgramSelectionList" runat="server" AutoGenerateColumns="False"
                CssClass="table" GridLines="Horizontal" DataSourceID="ProgramSelectionODS" BorderStyle="None" AllowPaging="True" PageSize ="3">
                <Columns>
                    <asp:BoundField DataField="ProgramID" HeaderText="ProgramID" SortExpression="ProgramID"></asp:BoundField>
                    <asp:BoundField DataField="ProgramName" HeaderText="ProgramName" SortExpression="ProgramName"></asp:BoundField>
                    <asp:BoundField DataField="DiplomaName" HeaderText="DiplomaName" SortExpression="DiplomaName"></asp:BoundField>
                    <asp:TemplateField HeaderText="SchoolCode">
                        <ItemTemplate>
                            <asp:DropDownList ID="SchoolCodeList" runat="server" DataSourceID="SchoolCodeODS" DataTextField="SchoolCode" DataValueField="SchoolCode"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Tuition" HeaderText="Tuition" SortExpression="Tuition"></asp:BoundField>
                    <asp:BoundField DataField="InternationalTuition" HeaderText="InternationalTuition" SortExpression="InternationalTuition"></asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    No data available for supplied product search string
                </EmptyDataTemplate>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
            </asp:GridView>
        </div>
        <asp:ObjectDataSource ID="ProgramSelectionODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Programs_FindBySchool" TypeName="Star_TEDSystem.BLL.SchoolController">
            <SelectParameters>
                <asp:ControlParameter ControlID="School" PropertyName="SelectedValue" Name="schoolid" Type="String"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>

</asp:Content>
