<%@ Page Title="CRUD-StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormA.aspx.cs" Inherits="WebApp.ExercisePages.FormA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>A03-Programs| CRUD</h1>
    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="Label5" runat="server" Text="Select a School"></asp:Label>&nbsp;&nbsp;
         <asp:DropDownList ID="SchoolList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <%-- Search and Clear Button --%>
            <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
            &nbsp;&nbsp;
      
        <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" />&nbsp;&nbsp;

        <%-- Link Buttons --%>
            <asp:LinkButton ID="AddProgram" runat="server" Font-Size="X-Large" OnClick="Add_Click">Add</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="UpdateProgram" runat="server" Font-Size="X-Large" OnClick="Update_Click">Update</asp:LinkButton>&nbsp;&nbsp;
         <asp:LinkButton ID="RemoveProgram" runat="server" Font-Size="X-Large" OnClick="Remove_Click">Remove</asp:LinkButton>&nbsp;&nbsp;<br />

         <asp:Label ID="Label8" runat="server" Text="Select a program"></asp:Label>&nbsp;&nbsp;
         <asp:DropDownList ID="ProgramList" runat="server"></asp:DropDownList>

            <%-- Program Search Button --%>
            <asp:Button ID="PSearch" runat="server" Text="Program Search" OnClick="PSearch_Click" />
            &nbsp;&nbsp;
        &nbsp;<asp:DataList ID="MessageList" runat="server">          
            
            <ItemTemplate>
                <%# Container.DataItem %>
            </ItemTemplate>
        </asp:DataList>
            <br />
            <br />

            
            <%-- Validation --%>

              <ajaxToolkit:ConfirmButtonExtender ID="RemoveProgram_ConfirmButtonExtender" runat="server" BehaviorID="RemoveProgram_ConfirmButtonExtender" ConfirmText="Do you wish to remove this program?" TargetControlID="RemoveProgram" />
            <asp:ValidationSummary ID="ProgramValidation" runat="server"
                HeaderText="Please correct your input to resolve the following issues." />
            <asp:RequiredFieldValidator ID="RequiredFieldProgramName" runat="server"
                ErrorMessage="Program Name is required."
                Display="None" ControlToValidate="ProgramName" SetFocusOnError="True">
            </asp:RequiredFieldValidator>

            <asp:RequiredFieldValidator ID="RequiredFieldSchoolCode" runat="server"
                ErrorMessage="School Code is required."
                Display="None" ControlToValidate="SchoolCode" SetFocusOnError="True">
            </asp:RequiredFieldValidator>

            <asp:CompareValidator ID="CompareTuition" runat="server"
                ErrorMessage="Tuition is a dollar amount of 0 or greater"
                Display="None" SetFocusOnError="True"
                ControlToValidate="Tuition" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0">
            </asp:CompareValidator>
            <asp:CompareValidator ID="CompareInternationalTuition" runat="server"
                ErrorMessage="International Tuition is a dollar amount of 0 or greater"
                Display="None" SetFocusOnError="True"
                ControlToValidate="InternationalTuition" Operator="GreaterThanEqual" Type="Double" ValueToCompare="0">
            </asp:CompareValidator>




        </div>
        <%--  this will be the entity CRUD area--%>
        <div class="col-md-12">
            <fieldset class="form-horizontal">
                <legend>Program Information</legend>
                <asp:Label ID="Label1" runat="server" Text="ProgramID"
                    AssociatedControlID="ProgramID"></asp:Label>
                <asp:Label ID="ProgramID" runat="server"></asp:Label>

                <asp:Label ID="Label2" runat="server" Text="Name"
                    AssociatedControlID="ProgramName"></asp:Label>
                <asp:TextBox ID="ProgramName" runat="server"></asp:TextBox>


                <asp:Label ID="Label3" runat="server" Text="Diploma Name"
                    AssociatedControlID="DiplomaName"></asp:Label>
                <asp:TextBox ID="DiplomaName" runat="server"></asp:TextBox>


                <asp:Label ID="Label4" runat="server" Text="School Code"
                    AssociatedControlID="SchoolCode"></asp:Label>
                <asp:TextBox ID="SchoolCode" runat="server"></asp:TextBox>

                <asp:Label ID="Label6" runat="server" Text="Tuition"
                    AssociatedControlID="Tuition"></asp:Label>
                <asp:TextBox ID="Tuition" runat="server"></asp:TextBox>

                <asp:Label ID="Label7" runat="server" Text="International Tuition"
                    AssociatedControlID="InternationalTuition"></asp:Label>
                <asp:TextBox ID="InternationalTuition" runat="server"></asp:TextBox>


            </fieldset>
        </div>



    </div>

    <script src="../Scripts/bootwrap-freecode.js"></script>


</asp:Content>
