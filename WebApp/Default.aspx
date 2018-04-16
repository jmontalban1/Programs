<%@ Page Title="DefaultPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>John Montalban</h1>
    <h2>A03- Programs</h2>

    <h2>Form A - CRUD</h2>
    <p>Single Item Create/Read/Update/Delete</p>
    <ul>
        <li>Programs</li>
    </ul>
    <h2>Form B Search and Display with a Gridview</h2>
    <p>Gridview Lookup with Code-Behind.</p>
    <ul>
        <li>Programs by Program Name (or partial program name)</li>
    </ul>
    <h2>Form C - ObjectDataSource Search & Display with a Gridview</h2>
    <p>Gridview Lookup with ObjectDataSource controls.</p>
    <ul>
        <li>Programs by School</li>
    </ul>
    <h2>List of Know Bugs</h2>
    <ul>
        <li>No know bugs</li>
    </ul>

    <h2>ERD</h2>
    <img src="ProgramIMG/Programs_img.png" />

    <h2>Entity Class Diagram</h2>
    <img src="ProgramIMG/ClassDiagram.png" />

    <h2>Application Class Diagram</h2>
    <img src="ProgramIMG/ApplicationDiagram.png" />

    <h2>Stored Procedures</h2>
    <p>The following specialty stored procedures are available:

Programs_FindBySchool Returns zero or more Programs records matching the supplied school code

Programs_FindByProgramName Returns zero or more Programs records containing the supplied partial program name.</p>

</asp:Content>
