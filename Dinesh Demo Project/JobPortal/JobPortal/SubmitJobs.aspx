<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="SubmitJobs.aspx.cs" Inherits="DemoProject.SubmitJobs" Title="Job Post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style12
        {
            width: 200px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <div style="height:auto; width:790px">
                  
                        <table style="border: medium solid #808080; width:100%;">
                            <tr>
                                <td class="style13" align="right">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                   <h3>Job Description</h3></td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">Job Code</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobCode" runat="server" Width="217px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Job Title</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobTitle" runat="server" Width="217px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorComName1" runat="server" 
                                        ControlToValidate="txtJobTitle" Display="Dynamic" 
                                        ErrorMessage="* Enter job title" SetFocusOnError="True">* Enter job title</asp:RequiredFieldValidator>
                                                         </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Job Type</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlJobType" runat="server" Width="217px">
                                        <asp:ListItem>---Select Job Type---</asp:ListItem>
                                        <asp:ListItem>Freelance</asp:ListItem>
                                        <asp:ListItem>Full Time</asp:ListItem>
                                        <asp:ListItem>Internship</asp:ListItem>
                                        <asp:ListItem>Part Time</asp:ListItem>
                                        <asp:ListItem>Temporary</asp:ListItem>
                                    </asp:DropDownList>
                                                         </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">Job Category</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlJobCategory" runat="server" Width="217px">
                                    <asp:ListItem>---Select Job Category---</asp:ListItem>
                                        <asp:ListItem>IT Services</asp:ListItem>
                                        <asp:ListItem>Aviation</asp:ListItem>
                                        <asp:ListItem>Accountant/Tax</asp:ListItem>
                                        <asp:ListItem>HR</asp:ListItem>
                                        <asp:ListItem>BPO</asp:ListItem>
                                           <asp:ListItem>Automobiles Jobs</asp:ListItem>
                                        <asp:ListItem>City</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Job Salary</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlJobSalary" runat="server" Width="217px">
                                     <asp:ListItem>---Select Salary---</asp:ListItem>
                                        <asp:ListItem>Less than 20,000</asp:ListItem>
                                        <asp:ListItem>20,000-40,000</asp:ListItem>
                                        <asp:ListItem>40,000-60,000</asp:ListItem>
                                        <asp:ListItem>60,000-80,000</asp:ListItem>
                                        <asp:ListItem>80,000-1,00,000</asp:ListItem>
                                           <asp:ListItem>Above than 1,00,000</asp:ListItem>
                                        <asp:ListItem>City</asp:ListItem>
                                    
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Job
                                    Location</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobLocation" runat="server" Width="217px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorComName2" runat="server" 
                                        ControlToValidate="txtJobLocation" Display="Dynamic" 
                                        ErrorMessage="* Location of Job" SetFocusOnError="True">* Location of Job</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Experience(years)</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="DropDownExpMin" runat="server" Width="70px" 
                                        AutoPostBack="True" ontextchanged="DropDownExpMin_TextChanged" 
                                      >
                                    </asp:DropDownList>
                                    &nbsp;(Min)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    <asp:DropDownList ID="DropDownExpMax" runat="server" Width="70px" 
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    (Max)</td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Skills Required</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtSkills" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    Job Description</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobDesc1" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobDesc2" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobDesc3" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobDesc4" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13" align="right">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtJobDesc5" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    &nbsp;</td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnPostJob" runat="server" Font-Size="9pt" 
                                        Text="Post Job" Width="110px" onclick="btnPostJob_Click"  />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                                    <asp:LinkButton runat="server" Font-Bold="True" Font-Size="11pt" Font-Underline="False" ForeColor="Red" ID="linkSubmitJobs" OnClick="linkSubmitJobs_Click">Submit New Job</asp:LinkButton>
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
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    
                </td>
            </tr>
        </table>
    
   
    
        
    </div>
</asp:Content>
