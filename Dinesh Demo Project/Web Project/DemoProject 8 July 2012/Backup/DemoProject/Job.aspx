<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="DemoProject.Job" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style7
        {
            height: 18px;
        }
        .style8
        {
            height: 18px;
            width: 229px;
        }
        .style9
        {
            width: 864px;
        }
        .style10
        {
            width: 841px;
        }
        .style11
        {
            width: 229px;
        }
        .style12
        {
            height: 18px;
            width: 329px;
        }
        .style13
        {
            width: 329px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border: thin hidden #000000; height:auto;  margin-top: 5px;">
  <div style="border: thin hidden #000000; height:auto;  margin-top: 5px;">
    <table style='border-width: medium; margin-bottom:2px; margin-top:0px; margin-left:8px; margin-right:8px; width: 98%;'><tr>
<td colspan="3" class="style9"  valign="top">
<h3>Search Job</h3>
        </td>
</tr>
        <tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Accountancy  	  
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > Armed Forces
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Admin & Secretarial 	
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Banking and Finance
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Construction 	
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Design
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Education
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Engineering
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Insurance
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Health Sector
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Catering
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Charities and voluntary
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Leisure and Tourism
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> HR and Training
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> IT and ICT
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Legal and Professional
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > Manufacturing
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx" > Marketing and PR
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > Media and Publishing
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > Pharmaceuticals
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > Supply chain
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx" > Recruitment
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > Retail 	Social Care
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"> Scientific
</a> (0)</td>
</tr>
<tr>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > Government
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx"  > MOD
</a> (0)</td>
<td width="33.33%">

<a style='font-size:10px' href="Profile.aspx" > Utilities (Gas/Electric)
</a> (0)</td>
</tr>
<tr>
<td width="33.33%" class="style10">

<a style='font-size:10px' href="Profile.aspx" > Transport 	
</a> (0)</td>
<td width="33.33%" class="style10">

<a style='font-size:10px' href="Profile.aspx" > Other</a> (0)</td>
</table>
    
    </div>
   
   <div style="border: thin hidden #000000; height:auto; width:1000;  margin-top: 5px;">
       <table style="width: 99%;">
           <tr>
               <td colspan="3" valign="top">
                  
               <h3>Apply for Job</h3>
               </td>
           </tr>
           <tr>
               <td class="style8">
                   &nbsp;JOb Title</td>
               <td class="style12">
                   &nbsp;Job Description</td>
               <td class="style7">
                   &nbsp;Category</td>
           </tr>
           <tr>
               <td class="style11">
                  
                   <asp:TextBox ID="txtJobTitle" runat="server" Width="200px"></asp:TextBox>
               </td>
               <td class="style13">
                  
                   <asp:TextBox ID="txtJobDesc" runat="server" Width="200px"></asp:TextBox>
               </td>
               <td>
                
                   <asp:DropDownList ID="DropDownLLocation" runat="server" Width="200px">
                       <asp:ListItem>---Select----</asp:ListItem>
                       <asp:ListItem>Armed Forces</asp:ListItem>
                   </asp:DropDownList>
               </td>
           </tr>
           <tr>
               <td class="style11">
                   Location</td>
               <td class="style13">
                   Company Name</td>
               <td>
                   Company Description</td>
           </tr>
           <tr>
               <td class="style11">
                   <asp:DropDownList ID="DropDownCategory" runat="server" Width="200px">
                       <asp:ListItem>---select---</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td class="style13">
                   <asp:TextBox ID="txtCompanyName" runat="server" Width="200px"></asp:TextBox>
               </td>
               <td>
                   <asp:TextBox ID="txtComDesc" runat="server" Width="200px"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="style11">
                   &nbsp;</td>
               <td class="style13">
                   &nbsp;</td>
               <td>
                   <asp:Button ID="btnApply" runat="server" Text="Apply" />
               </td>
           </tr>
       </table>
    
    </div>
    
    
  
  </div>
   
    <br />
    
</asp:Content>
