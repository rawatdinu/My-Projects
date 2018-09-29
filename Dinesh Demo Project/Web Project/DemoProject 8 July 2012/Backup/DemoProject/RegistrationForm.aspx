<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="DemoProject.RegistrationForm" Title="Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style7
        {
            width: 229px;
        }
        .style8
        {
            width: 6px;
        }
        .style11
        {
            width: 197px;
            height: 27px;
        }
        .style12
        {
            width: 197px;
        }
        .style14
        {
            width: 7px;
        }
        .style15
        {
            width: 7px;
            height: 27px;
        }
    </style>
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div style="width:1000px; height:330px; margin:auto; border-style:solid; border-color:Maroon; border-width:1px; background-color:White" >
   
               <table style="width:100%; height:auto; text-align:center" align="left" 
                   width="1000">
            <tr>
                <td class="style11"   >
               
                                          
                </td>
                <td class="style15"   >
               
                                          
                    &nbsp;</td>
                 <td  align="left" valign="middle" >
               
               <h2>Register Here </h2>                            
                </td>
            </tr>
            <tr>
                <td valign="middle" class="style11" align="right" >
                                        You Are ?</td>
                <td valign="middle" align="right" class="style14" >
                                        &nbsp;</td>
                <td align="left" valign="middle">
                    <asp:RadioButtonList ID="rdoUserType" runat="server" 
                        Width="250px" RepeatDirection="Horizontal">
                        <asp:ListItem>JobSeeker</asp:ListItem>
                        <asp:ListItem>Employer</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                        ControlToValidate="rdoUserType" Display="Dynamic" ErrorMessage="* Select user type" 
                        Font-Size="X-Small">* Select user type</asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="style11" >
                    &nbsp;</td>
                <td class="style15" >
                    &nbsp;</td>
                <td align="left">
                    <h3>Logon Information</h3></td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    Email ID</td>
                <td class="style15" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtEmailID" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="txtEmailID" ErrorMessage="Please Specify Your Email ID" 
                        Font-Size="X-Small" ForeColor="#FF3300" Display="Dynamic" 
                        SetFocusOnError="True">Please Specify Your Email ID</asp:RequiredFieldValidator>
                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                        runat="server" ControlToValidate="txtEmailID" 
                        ErrorMessage="RegularExpressionValidator" Font-Size="X-Small" 
                        ForeColor="#FF3300" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        Display="Dynamic">* Invalid e-mail id</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr><td class="style11" align="right" >Password:</td>
                <td class="style15" 
                    align="right" >&nbsp;</td><td align="left">
                <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" Width="200px" 
                        MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                    ControlToValidate="txtpwd" Display="Dynamic" ErrorMessage="* Password required" 
                    Font-Size="X-Small" SetFocusOnError="True">* Password required</asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="txtPwdRegularExpressionValidator" 
                                                 runat="server" ControlToValidate="txtpwd" Display="Dynamic" 
                                                 ErrorMessage="* Password must be Min 6 character " Font-Size="XX-Small" 
                                                 SetFocusOnError="True" ValidationExpression="[\S\s]{6,}">* 
                Password must be Min 6 character
                                             </asp:RegularExpressionValidator>
                </td></tr>
            <tr><td class="style11" align="right" >Confirm Password:</td>
                <td class="style15" 
                    align="right" >&nbsp;</td><td align="left">
                <asp:TextBox ID="txtconpwd" runat="server" TextMode="Password" Width="200px" 
                        MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                    ControlToValidate="txtconpwd" Display="Dynamic" 
                    ErrorMessage="* Re-enter password" Font-Size="X-Small" SetFocusOnError="True">* 
                Re-enter password</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtpwd" ControlToValidate="txtconpwd" Display="Dynamic" 
                    ErrorMessage="* Password not matched" Font-Size="X-Small" 
                    SetFocusOnError="True">* Password not matched</asp:CompareValidator>
                </td></tr>            
            <tr>
                <td class="style12"  >
                  
                </td>
                <td class="style15"  >
                  
                    &nbsp;</td>
                <td align="left">
                  <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" 
                        onclick="btnSubmit_Click"    /> &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" 
                        CausesValidation="False" />
                &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style11" >
                    &nbsp;</td>
                <td class="style15" >
                    &nbsp;</td>
                <td align="left">
                    <asp:Label ID="lblResult" runat="server" EnableViewState="False" 
                        Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                         </td>
            </tr>            
        </table>
              
      
      
        
         
             
           
    </div>

</asp:Content>
