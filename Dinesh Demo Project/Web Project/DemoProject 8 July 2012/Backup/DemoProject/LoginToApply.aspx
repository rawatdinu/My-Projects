<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="LoginToApply.aspx.cs" Inherits="DemoProject.LoginToApply" Title="JobSeeker Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
 .style12
        {
            width: 200px;
        }
        .style13
        {
            width: 132px;
        }
        .style14
        {
            width: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; width: 1000px">
        
        <table style="width:100%;">
            <tr  >
                <td class="style12" valign="top">
                
                   
                  <h4>Search By</h4>
                  
                    <asp:Panel ID="Panel1" runat="server">
                     <asp:LinkButton ID="LinkButton1" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" >Job Type</asp:LinkButton>
                        <br />
                        <br />
                         <asp:LinkButton ID="LinkButton2" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False"  >Job Category</asp:LinkButton>
                        <br />
                        <br />
                  <asp:LinkButton ID="LinkButton3" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                          Font-Underline="False" >Job Salary</asp:LinkButton>
                       
                        <br />
                        <br />
                        <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="Red" 
                             Font-Underline="False" CausesValidation="False" 
                            >Post Date</asp:LinkButton>
                             <br />
                        <br />
                    </asp:Panel>
                  
                </td>
                <td valign="top">
                    <div style="border: medium solid #808080; height:auto; width:790px">
                  
                    
                                 
                        
                    
                        <table style="width:100%;">
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="style13">
                                    EmailID*</td>
                                                         <td class="style14">
                                                             &nbsp;</td>
                                                         <td>
                                                             <asp:TextBox ID="txtEmailID" runat="server" Width="200px"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                 ErrorMessage="* Enter email address" ControlToValidate="txtEmailID" 
                                                                 Display="Dynamic" SetFocusOnError="True">* Enter email address</asp:RequiredFieldValidator>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td align="right" class="style13">
                                                             Password*</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                 ErrorMessage="* Enter password" 
                                        ControlToValidate="txtPassword" Display="Dynamic" SetFocusOnError="True">* 
                                    Enter password</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" 
                                        onclick="btnLogin_Click" />
                                &nbsp;&nbsp;
                                    <asp:LinkButton ID="linkforgetPwd" runat="server" CausesValidation="False" 
                                        Font-Size="Small" Font-Underline="False" ForeColor="Red" 
                                        onclick="linkforgetPwd_Click">forget password?</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblForgetPassword" runat="server" EnableViewState="False" 
                                        Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblResult" runat="server" EnableViewState="False" 
                                        Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                  
                    
                                 
                        
                    
                    </div>
                   
                </td>
            </tr>
        </table>
    
        
    </div>
</asp:Content>
