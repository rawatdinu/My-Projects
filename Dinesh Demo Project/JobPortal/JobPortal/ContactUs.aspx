<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="DemoProject.ContactUs" Title="Contact Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .TextArea
        { max-height:106px;
          min-height:106px;
          max-width:378px;
          min-width:378px;
            
            }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; width: 1000px">
        <table style="width: 100%;" bgcolor="White">
            <tr>
                <td  style="width:29px;">
                    &nbsp;
                </td>
                <td style="width:354px;">
                   <h3>Address</h3>
                </td>
                <td>
                   <h3>Enquiry</h3>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width:29px;">
                    &nbsp;</td>
                <td style="width:354px;" valign="top">
                   <div style="width: 446px; height: 243px">
                   <asp:Table ID="Table1" runat="server" BackColor="Silver" 
            CaptionAlign="Left" Font-Names="Verdana" Font-Size="11pt" ForeColor="Black" 
            Width="356px">
                        <asp:TableRow ID="row1" runat="server">
                            <asp:TableCell ID="TableCell1" runat="server">8591,Qutab Road</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row2" runat="server">
                            <asp:TableCell ID="TableCell2" runat="server">Near New Delhi Railway Station</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row3" runat="server">
                            <asp:TableCell ID="TableCell3" runat="server">New Delhi 110055
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row4" runat="server">
                            <asp:TableCell ID="TableCell4" runat="server">India 011 2353 1125</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row5" runat="server">
                            <asp:TableCell ID="TableCell5" runat="server">Ph:45869652,45863210</asp:TableCell>
                        </asp:TableRow>
        </asp:Table>
                   </div>
                   </td>
                <td valign="top">
                 <div>
                 <table style="width:100%;">
            <tr>
                <td style="width:83px;" align="right">
                    Subject<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtSubject" Display="Dynamic" ErrorMessage="*" Font-Bold="True" 
                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:83px;" align="right">
                    Name<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" Font-Bold="True" 
                        SetFocusOnError="True">*</asp:RequiredFieldValidator>&nbsp;
                                                         </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:83px;" align="right">
                    Email<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="*" 
                        Font-Bold="True" SetFocusOnError="True">*</asp:RequiredFieldValidator>
&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtEmailAddress" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmailAddress" Display="Dynamic" 
                        ErrorMessage="* Invalid e-mail address" Font-Size="Small" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">* 
                    Invalid e-mail address</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:83px;" align="right">
                    Mobile<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="*" 
                        Font-Bold="True" SetFocusOnError="True">*</asp:RequiredFieldValidator>
&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="* Invalid number" 
                        ValidationExpression="\d{10}">* Invalid number</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:83px;" valign="top" align="right">
                    Message<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtMessage" Display="Dynamic" ErrorMessage="*" 
                        Font-Bold="True" SetFocusOnError="True">*</asp:RequiredFieldValidator>
&nbsp;</td>
                <td style="vertical-align:top;">
                <div style="width:378px;height:106px;">
                     <asp:TextBox ID="txtMessage" runat="server" Height="106px" TextMode="MultiLine" 
                        Width="378px" Rows="10" Columns="50" Wrap="True" CssClass="TextArea" 
                         MaxLength="1000" ></asp:TextBox>
                </div>
               
               
                </td>
            </tr>
            
            <tr>
            
            
                <td style="width:83px;">
                    &nbsp;</td>
                <td> <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" />
                </td>
            </tr>
            
            <tr>
            
                <td style="width:83px;" align="right">
                    &nbsp;</td>
                <td> 
                    <asp:Label ID="lblResult" runat="server" EnableViewState="False" 
                        Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            
            <tr>
            
                <td style="width:83px;" align="right">
                    Note:</td>
                <td> * Mandatory fields</td> 
            </tr>
        </table>
                 </div>                    
               </td>
                <td valign="top" width="30">
                    &nbsp;</td>
            </tr>
            </table>
        
    </div>

    
</asp:Content>
