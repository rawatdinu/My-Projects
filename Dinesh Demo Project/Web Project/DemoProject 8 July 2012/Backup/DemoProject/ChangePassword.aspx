<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="DemoProject.ChangePassword" Title="Change Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style12
        {
            width: 202px;
        }
        .style13
        {
            width: 149px;
        }
        .style14
        {
            width: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:auto; width: 1000px">
    
   
    
        
        <table style="width:100%;">
            <tr  >
                <td class="style12" valign="top">
                    <div style="height:auto; width:200px;">
                   <asp:LinkButton ID="linkBtMyDesboard" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkBtMyDesboard_Click" >My Dashboard</asp:LinkButton>
                        <br />
                        <br />
                         <asp:LinkButton ID="linkViewProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkViewProfile_Click"  >View Profile</asp:LinkButton>
                        <br />
                        <br />
                  <asp:LinkButton ID="linkBtUpdateProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                          Font-Underline="False" onclick="linkBtUpdateProfile_Click">Update Profile</asp:LinkButton>
                       
                        <br />
                        <br />
                        <asp:LinkButton ID="linkBtChangePassword" runat="server" ForeColor="Red" 
                             Font-Underline="False" CausesValidation="False" >Change password</asp:LinkButton>
                             <br />
                        <br />
                  
                  
                  </div>
                </td>
                <td valign="top">
                    <div style="height:auto; width:790px">
                  
                        <table style="border: medium solid #808080; width:100%;">
                            <tr>
                                <td class="style13" align="right">
                                    Old Password</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtOldPwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldpwd" runat="server" 
                                        ControlToValidate="txtOldPwd" Display="Dynamic" 
                                        ErrorMessage="* Enter old password" SetFocusOnError="True">* Enter old 
                                    password</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    New Password</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtNewPwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldpwdNewPwd" 
                                        runat="server" ControlToValidate="txtNewPwd" Display="Dynamic" 
                                        ErrorMessage="* Enter new password" SetFocusOnError="True">* Enter new 
password</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNewpwd" 
                                        runat="server" ControlToValidate="txtNewPwd" Display="Dynamic" 
                                        ErrorMessage="* Password minimum 6 character" SetFocusOnError="True" 
                                        ValidationExpression="[\S\s]{6,}">* Password minimum 6 character</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Confirm Password</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtConPwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldpwdConPwd" 
                                        runat="server" ControlToValidate="txtConPwd" Display="Dynamic" 
                                        ErrorMessage="* Confirm new password">* Confirm new password</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="txtNewPwd" ControlToValidate="txtConPwd" Display="Dynamic" 
                                        ErrorMessage="* Password not match" SetFocusOnError="True">* Password not 
                                    match</asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnChangePwd" runat="server" Font-Size="9pt" 
                                        Text="Change Password" Width="110px" onclick="btnChangePwd_Click" />
&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                        Font-Size="9pt" Text="Cancel" Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblResult" runat="server" EnableViewState="False" 
                                        ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    
                    </div>
                </td>
            </tr>
        </table>
    
   
    
        
    </div>

</asp:Content>
