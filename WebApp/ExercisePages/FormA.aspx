<%@ Page Title="CRUD-StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormA.aspx.cs" Inherits="WebApp.ExercisePages.FormA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>A03-Programs| CRUD</h1>
<div class="row">
    <div class="col-md-12">
        <asp:Label ID="Label5" runat="server" Text="Select a School"></asp:Label>&nbsp;&nbsp;
         <asp:DropDownList ID="SchoolList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
         <asp:Button ID="Search" runat="server" Text="Search"  OnClick="Search_Click"/> &nbsp;&nbsp;
        <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" />&nbsp;&nbsp;
        <asp:LinkButton ID="AddProgram" runat="server" Font-Size="X-Large" OnClick="Add_Click">Add</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="UpdateProgram" runat="server" Font-Size="X-Large" OnClick="Update_Click">Update</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="RemoveProgram" runat="server" Font-Size="X-Large" OnClick="Remove_Click">Remove</asp:LinkButton>&nbsp;&nbsp;<br />
         <asp:Label ID="Label8" runat="server" Text="Select a program"></asp:Label>&nbsp;&nbsp;
         <asp:DropDownList ID="ProgramList" runat="server"></asp:DropDownList>
        <asp:Button ID="PSearch" runat="server" Text="Program Search"  OnClick="PSearch_Click"/> &nbsp;&nbsp;
        &nbsp;<asp:DataList ID="MessageList" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
          <br /><br />

         <div class="col-md-2">
            <asp:Label ID="Label9" runat="server" Text="Enter partial program name:"></asp:Label><br />
            <asp:TextBox ID="SearchPartialName" runat="server"></asp:TextBox><br />
            <asp:Button ID="SearchProgram" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchProgram_Click" />
        </div>
               <div class="col-md-6">
                   
            <asp:GridView ID="ProgramSelectionList" runat="server" OnSelectedIndexChanged="ProgramList_SelectedIndexChanged" AutoGenerateColumns="False"
                CssClass="table" GridLines="Horizontal" BorderStyle="None" AllowPaging="True" OnPageIndexChanging="ProgramList_PageIndexChanging" PageSize="5" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:TemplateField >
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
                                Text='<%# Eval("International Tuition") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  
                </Columns>
                <EmptyDataTemplate>
                    No data available for supplied product search string
                </EmptyDataTemplate>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
            </asp:GridView>
        </div>


        
        <%-- Validation --%>





        </div>
             <%--  this will be the entity CRUD area--%>
        <div class ="col-md-12">
            <fieldset class="form-horizontal">
                <legend>Program Information</legend>
<%--                each control group will consist of a label and the associated control--%>
                <asp:Label ID="Label1" runat="server" Text="ProgramID"
                     AssociatedControlID="ProgramID"></asp:Label>
                <asp:Label ID="ProgramID" runat="server" ></asp:Label> 
                  
                  <asp:Label ID="Label2" runat="server" Text="Name"
                     AssociatedControlID="ProgramName"></asp:Label>
                <asp:TextBox ID="ProgramName" runat="server" ></asp:TextBox> 
                  
                
                  <asp:Label ID="Label3" runat="server" Text="Diploma Name"
                     AssociatedControlID="DiplomaName"></asp:Label>
                <asp:TextBox ID="DiplomaName" runat="server" ></asp:TextBox> 

                 
                  <asp:Label ID="Label4" runat="server" Text="School Code"
                     AssociatedControlID="SchoolCode"></asp:Label>
                <asp:TextBox ID="SchoolCode" runat="server" ></asp:TextBox> 
                 
                  <asp:Label ID="Label6" runat="server" Text="Tuition"
                     AssociatedControlID="Tuition"></asp:Label>
                <asp:TextBox ID="Tuition" runat="server" ></asp:TextBox> 
                 
                  <asp:Label ID="Label7" runat="server" Text="International Tuition"
                     AssociatedControlID="InternationalTuition"></asp:Label>
                <asp:TextBox ID="InternationalTuition" runat="server" ></asp:TextBox> 
             
            
            </fieldset>
        </div>



    </div>

        <script src="../Scripts/bootwrap-freecode.js"></script>


</asp:Content>
