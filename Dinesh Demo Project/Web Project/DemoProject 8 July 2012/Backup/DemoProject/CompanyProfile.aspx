<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="CompanyProfile.aspx.cs" Inherits="DemoProject.CompanyProfile" Title="Apply for Job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style12
        {
            width: 200px;
        }
        .style13
     {
         width: 163px;
     }
        .style14
     {
        }
        .style15
     {
         width: 88px;
         height: 20px;
     }
     .style16
     {
         height: 20px;
     }
        .style17
        {
            width: 93px;
        }
        .style18
        {
            width: 93px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="height: auto; width: 1000px">
        
        <table style="width:100%;">
            <tr  >
                <td class="style12" valign="top">
                    <asp:Panel ID="Panel2" runat="server">
                    <asp:LinkButton ID="linkBtMyDesboard" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False"  >My Dashboard</asp:LinkButton>
                        <br />
                        <br />
                         <asp:LinkButton ID="linkViewProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False"  >View Profile</asp:LinkButton>
                        <br />
                        <br />
                  <asp:LinkButton ID="linkBtUpdateProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                          Font-Underline="False" >Update Profile</asp:LinkButton>
                       
                        <br />
                        <br />
                        <asp:LinkButton ID="linkBtChangePassword" runat="server" ForeColor="Red" 
                             Font-Underline="False" CausesValidation="False" 
                           >Change password</asp:LinkButton>
                             <br />
                        <br />
                    
                    </asp:Panel>
                
                   
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
                                <td class="style13" valign="top">
                                    <div>
                                        <asp:Image ID="Image1" runat="server" Height="151px" Width="170px" />
                                    </div>
                                </td>
                                <td valign="top">
                                    <div>
                                        <table style="width:100%;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblTitle" runat="server" Font-Size="11pt" ForeColor="Black" 
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" valign="top">
                                                   
                                                    <asp:BulletedList ID="BulletedList1" runat="server">
                                                    </asp:BulletedList>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    <asp:Label ID="Label4" runat="server" Font-Size="10pt" ForeColor="Black" 
                                                        Text="Experience"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblExp" runat="server" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    <asp:Label ID="Label5" runat="server" Font-Size="10pt" ForeColor="Black" 
                                                        Text="Salary"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSalary" runat="server" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    <asp:Label ID="Label6" runat="server" Font-Size="10pt" ForeColor="Black" 
                                                        Text="e-mail"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEmail" runat="server" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style15">
                                                    <asp:Label ID="Label7" runat="server" Font-Size="10pt" ForeColor="Black" 
                                                        Text="Phone"></asp:Label>
                                                </td>
                                                <td class="style16">
                                                    <asp:Label ID="lblPhone" runat="server" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    <asp:Label ID="Label9" runat="server" Font-Size="10pt" ForeColor="Black" 
                                                        Text="Skill"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSkills" runat="server" Font-Size="10pt" ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    <asp:Label ID="Label8" runat="server" Font-Size="10pt" ForeColor="Black" 
                                                        Text="Website"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:HyperLink ID="HyperLinkweb" runat="server" Font-Size="10pt" 
                                                        ForeColor="Blue" Target="_blank" Font-Underline="False">[HyperLinkweb]</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style14" colspan="2">
                                                    <asp:Panel ID="Panel3" runat="server">
                                                        <table style="width:100%;">
                                                            <tr>
                                                                <td class="style17">
                                                                    Select Resume</td>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownListResume" runat="server" Width="400px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    &nbsp;</td>
                                                <td>
                                                   
                                                    <asp:LinkButton ID="linkLoginToApply" runat="server" Font-Underline="False" 
                                                        Font-Bold="True" Font-Size="11pt" BackColor="#5C87B2" BorderStyle="None" 
                                                        onclick="linkLoginToApply_Click">Login 
                                                    to Apply</asp:LinkButton>
                                                &nbsp;
                                                    <asp:LinkButton ID="linkApply" runat="server" Font-Underline="False" 
                                                        Font-Bold="True" Font-Size="11pt" BackColor="#5C87B2" 
                                                        onclick="linkApply_Click">Apply</asp:LinkButton>
&nbsp;
                                                    <asp:LinkButton ID="LinkApplyWithoutRegistration" runat="server" 
                                                        Font-Underline="False" Font-Bold="False" Font-Size="11pt" 
                                                        BackColor="#99CCFF" onclick="LinkApplyWithoutRegistration_Click">Apply 
                                                    without Registration</asp:LinkButton>
&nbsp;
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    &nbsp;</td>
                                                <td>
                                                   
                                                    <asp:LinkButton ID="LinkNewUser" runat="server" Font-Underline="false" 
                                                        ForeColor="Red" onclick="LinkNewUser_Click">new user? Register now</asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
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
                   
                </td>
            </tr>
        </table>
    
        
    </div>
</asp:Content>
