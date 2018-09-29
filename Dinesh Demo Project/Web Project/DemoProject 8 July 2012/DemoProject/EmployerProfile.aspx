<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="EmployerProfile.aspx.cs" Inherits="DemoProject.EmployerProfile" Title="Employer Profile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; width: 1000px;">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">  
</asp:ToolkitScriptManager>  
        <div style="height: auto; width: 1000px;">
        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="height: auto; width: 1000px;">
        <table style="width: 100%;">
            <tr>
                <td  valign="top">
                  <div style="height:auto; width:200px;">
                   <asp:LinkButton ID="linkBtMyDesboard" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" >My Dashboard</asp:LinkButton>
                        <br />
                        <br />
                         <asp:LinkButton ID="linkViewProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" >View Profile</asp:LinkButton>
                        <br />
                        <br />
                           
                  <asp:LinkButton ID="linkBtUpdateProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkBtUpdateProfile_Click">Update Profile</asp:LinkButton>
                       
                        <br />
                        <br />
                        <asp:LinkButton ID="linkBtChangePassword" runat="server" ForeColor="Red" 
                            Font-Underline="False" onclick="linkBtChangePassword_Click" 
                          CausesValidation="False">Change password</asp:LinkButton>
                             <br />
                        <br />
                  
                  
                  </div>
                </td>
                <td valign="top">
                   <div style="border: medium solid #808080; height:auto; width:790px;">
                   <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Width="790px">
            <asp:TabPanel   ID="TabPanel1" runat="server" HeaderText="Desboard"><ContentTemplate><div><table style="height:auto; width:100%;"><tr><td valign="top" id="tdImage" ><div style="height: auto; width: auto"><asp:Image ID="Image1" runat="server" Height="151px" Width="170px" /></div><br /><br /><br /><br /></td><td id="tdDetail" valign="top"><div style="height:auto; width:600px"><br /><asp:Label ID="lblCompanyName" runat="server" Width="600px" Font-Bold="True" 
                           Font-Size="14pt" ForeColor="Black"></asp:Label><br /><asp:Table ID="Table1" runat="server" BackColor="#CCCCCC" Font-Names="Verdana" 
                           Font-Size="11pt" Height="87px" Width="600px"><asp:TableRow ID="row1" runat="server"><asp:TableCell ID="TableCell1" runat="server" Width="200px">Person-in-Charge</asp:TableCell><asp:TableCell ID="cellPersonInCharge" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row2" runat="server"><asp:TableCell ID="TableCell2" runat="server">Staff</asp:TableCell><asp:TableCell ID="cellStaff" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row3" runat="server"><asp:TableCell ID="TableCell3" runat="server">Address</asp:TableCell><asp:TableCell ID="cellAddress" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row4" runat="server"><asp:TableCell ID="TableCell4" runat="server">State</asp:TableCell><asp:TableCell ID="cellState" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row5" runat="server"><asp:TableCell ID="TableCell5" runat="server">Country</asp:TableCell><asp:TableCell ID="cellCountry" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow runat="server"><asp:TableCell runat="server">Phone</asp:TableCell><asp:TableCell ID="cellPhone" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow runat="server"><asp:TableCell runat="server">Email</asp:TableCell><asp:TableCell ID="cellEmail" runat="server"></asp:TableCell></asp:TableRow></asp:Table>
                &nbsp;&nbsp;&nbsp; <br /><h3>Website &amp; Social Media</h3><asp:Table ID="Table2" runat="server" BackColor="#CCCCCC" Font-Names="Verdana" 
                           Font-Size="11pt" Height="87px" Width="600px"><asp:TableRow ID="row6" runat="server"><asp:TableCell ID="TableCell6" runat="server" Width="200px">Website</asp:TableCell><asp:TableCell ID="cellWebsite" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row7" runat="server"><asp:TableCell ID="TableCell7" runat="server">Facebook 
                ID</asp:TableCell><asp:TableCell ID="cellFacebook" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row8" runat="server"><asp:TableCell ID="TableCell8" runat="server">Twitter 
                    ID</asp:TableCell><asp:TableCell ID="cellTwitter" runat="server"></asp:TableCell></asp:TableRow></asp:Table><br /></div></td></tr></table></div></ContentTemplate></asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Submit JOb"><ContentTemplate><div style="height:auto; width:800px;">
                <table style="width: 770px;">
                    <tr>
                        <td align="right">
                          <asp:LinkButton ID="linkSubmitJobs" runat="server" Font-Underline="False"
                    onclick="linkSubmitJobs_Click" Font-Bold="True" ForeColor="Red" >Submit New Job</asp:LinkButton>
                        </td>
                    </tr>
                    
                   
                </table>
               
                <asp:Label ID="lblResult" runat="server" EnableViewState="False" 
                    Font-Bold="True" Font-Size="10pt" ForeColor="Red"></asp:Label>
                <asp:GridView 
                               ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            Width="780px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            onrowcommand="GridView1_RowCommand" 
                            onpageindexchanging="GridView1_PageIndexChanging"><AlternatingRowStyle BackColor="White" /><Columns>
                        <asp:TemplateField HeaderText="Job Posted"><ItemTemplate><table style="height:auto; width:auto;"><tr>
                            <td style="width:100px; "><asp:Label ID="lblJobID" runat="server" 
                                       Text='<%# Eval("JobID")%>' Visible="false"></asp:Label><asp:Label 
                                       ID="lblJobType" runat="server" Text='<%# Eval("JobType")%>'><br /> </asp:Label>
                                       <asp:Label ID="Label1" runat="server" Text='<%# Eval("CompanyJobCode")%>'> </asp:Label> </td>
                            <td style="width:170px;" valign="top">
                            <asp:Label ID="Label2" runat="server" 
                                       Text=<%# Eval("JobTitle")%> Font-Bold="True" Font-Size="11"></asp:Label><br />
                                        <%# Eval("Location")%>
                             </td>
                            <td  align="center" style="width:150px;"></td>
                            <td style="width:70px; "><%# Eval("PostDate")%> </td>
                            </tr>
                                       <tr>
                                       <td > </td>
                                       <td ></td>
                                           <td  ></td>
                                           <td >Applicant (<%# Eval("Num")%>)</td></tr>
                                           </table></ItemTemplate></asp:TemplateField>
                                           <asp:ButtonField Text="View Candidate" CommandName="ViewCandidate" />
                                           <asp:ButtonField Text="Edit" CommandName="EditJobPost" />
                                            <asp:ButtonField Text="Delete" CommandName="DeleteJobPost" />
                                           </Columns><EditRowStyle BackColor="#2461BF" /><FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#EFF3FB" /><SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                           </asp:GridView></div>
                                           </ContentTemplate>
                                           </asp:TabPanel>
             
        </asp:TabContainer>
                   </div>
                </td>
            </tr>
        </table>
    
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
        
    </div>
</asp:Content>
