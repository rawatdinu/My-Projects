<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="DemoProject.ForgetPassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width:1000px; height:330px;">
<br />
<p style="color:Black; padding-left:10px">Enter your registered email address to receive an email with the link to reset your password. </p>
<p style="color:Black; padding-left:250px" >     
    Email Address&nbsp;&nbsp;<asp:TextBox ID="txtEmailAddress"
        runat="server" Width="200px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="* Enter e-mail address" ControlToValidate="txtEmailAddress" 
        Display="Dynamic" SetFocusOnError="True">* Enter e-mail address</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="* Invalid e-mail address" 
        ControlToValidate="txtEmailAddress" Display="Dynamic" 
        SetFocusOnError="True" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">* 
    Invalid e-mail address</asp:RegularExpressionValidator><br /><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" 
        onclick="ButtonSubmit_Click" /><br />
    
    <asp:Label ID="lblResult" runat="server" EnableViewState="False" 
        Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
</p>

</div>
</asp:Content>
