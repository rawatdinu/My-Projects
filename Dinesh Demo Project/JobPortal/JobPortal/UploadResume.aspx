<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="UploadResume.aspx.cs" Inherits="DemoProject.UploadResume" Title="Upload Resume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="height: auto; width: 1000px">
    
   
    
        
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
                             Font-Underline="False" CausesValidation="False" 
                            onclick="linkBtChangePassword_Click" >Change password</asp:LinkButton>
                             <br />
                        <br />
                  
                  
                  </div>
                </td>
                <td valign="top">
                    <div style="height:auto; width:790px">
                  
                        <table style="border: medium solid #808080; width:100%;">
                            <tr>
                                <td class="style13" align="right">
                                    Resume Title</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Select Resume</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:FileUpload ID="FileUploadResume" runat="server" />&nbsp;(.txt,.doc,.docx,.pdf)
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="FileUploadResume" Display="Dynamic" 
                                        ErrorMessage="* Select Resume"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnChangePwd" runat="server" Font-Size="9pt" 
                                        Text="Upload Resume" Width="110px" onclick="btnChangePwd_Click" />
&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                        Font-Size="9pt" Text="Cancel" Width="80px" onclick="btnCancel_Click" />
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
