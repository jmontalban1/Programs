<%@ Page Title="CRUD-StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormA.aspx.cs" Inherits="WebApp.ExercisePages.FormA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>A03-Programs| CRUD</h1>

    <div class="col-md-12">
        <asp:Label ID="Label5" runat="server" Text="Select a School"></asp:Label>&nbsp;&nbsp;
         <asp:DropDownList ID="SchoolList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
         <asp:Button ID="Search" runat="server" Text="Search"  OnClick="Search_Click"/> &nbsp;&nbsp;
        <asp:Button ID="Clear" runat="server" Text="Clear" />&nbsp;&nbsp;
        <asp:LinkButton ID="AddProgram" runat="server" Font-Size="X-Large">Add</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="UpdateProgram" runat="server" Font-Size="X-Large">Update</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="RemoveProgram" runat="server" Font-Size="X-Large">Remove</asp:LinkButton>&nbsp;&nbsp;<br />
         <asp:Label ID="Label8" runat="server" Text="Select a program"></asp:Label>&nbsp;&nbsp;
         <asp:DropDownList ID="ProgramList" runat="server" OnSelectedIndexChanged="ProgramList_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="PSearch" runat="server" Text="Program Search"  OnClick="PSearch_Click"/> &nbsp;&nbsp;
        &nbsp;<asp:DataList ID="MessageList" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>

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
