<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="Frame.aspx.cs" Inherits="DemoProject.Frame" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #frame1
        {
            width: 980px;
            height: 350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; width: 1000px">
        <br />
       <iframe id="frame1" scrolling="auto" runat="server">
</iframe>
    </div>

</asp:Content>
