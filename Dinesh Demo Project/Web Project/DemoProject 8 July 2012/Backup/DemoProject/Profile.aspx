<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DemoProject.Profile" Title="JobSeeker Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
<style type="text/css">


</style>

   
    </asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">  
</asp:ToolkitScriptManager>  
<div style="height: auto; width: 1000px;">
        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="height: auto; width: 1000px;">
        <table style="width: 100%;">
            <tr >
                <td  valign="top">
                  <div style="height:auto; width:200px;">
                   <asp:LinkButton ID="linkBtMyDesboard" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkBtMyDesboard_Click">My Dashboard</asp:LinkButton>
                        <br />
                        <br />
                         <asp:LinkButton ID="linkViewProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkViewProfile_Click" >View Profile</asp:LinkButton>
                     
                        <br />
                        <br />
                  <asp:LinkButton ID="linkBtUpdateProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                          OnClick="linkBtUpdateProfile_Click" Font-Underline="False">Update 
                        Profile</asp:LinkButton>
                       
                        <br />
                        <br />
                        <asp:LinkButton ID="linkBtChangePassword" runat="server" ForeColor="Red" 
                             Font-Underline="False" onclick="linkBtChangePassword_Click">Change password</asp:LinkButton>
                             <br />
                        <br />
                  
                  
                  </div>
                </td>
                <td valign="top">
                   <div style="border: medium solid #808080; height:auto; width:790px;">
                   <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Width="790px">
            <asp:TabPanel   ID="TabPanel1" runat="server" HeaderText="Desboard"><HeaderTemplate>Desboard</HeaderTemplate><ContentTemplate><div><table style="height:auto; width:800px"><tr><td valign="top" id="tdImage" ><div style="height: auto; width: auto;"><asp:Image ID="Image1" runat="server" Height="151px" Width="170px" /></div><br /><br /><asp:Label ID="Label5" runat="server" Text="Last Updated"></asp:Label><br /><asp:Label ID="lblLastUpdated" runat="server" Font-Bold="True" 
                            Font-Size="10pt" ForeColor="Black"></asp:Label><br /><br /></td><td id="tdDetail" valign="top"><div style="height:auto; width:600px;"><asp:Label ID="Label3" runat="server" Text="My Information" Font-Bold="True" 
                           Font-Size="Large" ForeColor="Black"></asp:Label><asp:Table ID="Table1" runat="server" BackColor="#CCCCCC" Font-Names="Verdana" 
                           Font-Size="11pt" Height="100px" Width="600px"><asp:TableRow ID="row1" runat="server"><asp:TableCell ID="TableCell1" runat="server" Width="200px">First Name</asp:TableCell><asp:TableCell ID="cellFirstName" runat="server" Width="400px"></asp:TableCell></asp:TableRow><asp:TableRow ID="row2" runat="server"><asp:TableCell ID="TableCell2" runat="server">Last Name</asp:TableCell><asp:TableCell ID="cellLastName" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row3" runat="server"><asp:TableCell ID="TableCell3" runat="server">D.O.B</asp:TableCell><asp:TableCell ID="cellDOB" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row4" runat="server"><asp:TableCell ID="TableCell4" runat="server">Gender</asp:TableCell><asp:TableCell ID="cellGender" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row5" runat="server"><asp:TableCell ID="TableCell5" runat="server">Address</asp:TableCell><asp:TableCell ID="cellAddress" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row6" runat="server"><asp:TableCell ID="TableCell6" runat="server">State</asp:TableCell><asp:TableCell ID="cellState" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow runat="server"><asp:TableCell runat="server">Country</asp:TableCell><asp:TableCell ID="cellCountry" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow runat="server"><asp:TableCell runat="server">Phone</asp:TableCell><asp:TableCell ID="cellPhone" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow runat="server"><asp:TableCell runat="server">Mobile</asp:TableCell><asp:TableCell ID="cellMobile" runat="server"></asp:TableCell></asp:TableRow></asp:Table>&#160;&#160;&#160; <br /><asp:Label ID="Label1" runat="server" Text="Qualification" Font-Bold="True" 
                           Font-Size="Large" ForeColor="Black"></asp:Label><asp:Table ID="TableQualification" runat="server" BackColor="#CCCCCC" Font-Names="Verdana" 
                           Font-Size="11pt" Height="87px" Width="600px"><asp:TableRow ID="row7" runat="server"><asp:TableCell ID="TableCell7" runat="server" Width="200px">Degree/Certificate</asp:TableCell><asp:TableCell ID="cellDegree" runat="server" Width="400px"></asp:TableCell></asp:TableRow><asp:TableRow ID="row8" runat="server"><asp:TableCell ID="TableCell8" runat="server">Passing Year</asp:TableCell><asp:TableCell ID="cellPassingYear" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow ID="row9" runat="server"><asp:TableCell ID="TableCell9" runat="server">Marks</asp:TableCell><asp:TableCell ID="cellMarks" runat="server"></asp:TableCell></asp:TableRow></asp:Table><br /><asp:Label ID="Label2" runat="server" Text="Experience" Font-Bold="True" 
                           Font-Size="Large" ForeColor="Black"></asp:Label><asp:Table ID="TableExperience" runat="server" BackColor="#CCCCCC" Font-Names="Verdana" 
                           Font-Size="11pt" Height="87px" Width="600px"><asp:TableRow ID="row13" runat="server"><asp:TableCell ID="TableCell13" runat="server" Width="200px">Experience Field</asp:TableCell><asp:TableCell ID="cellExpField" runat="server" Width="400px"></asp:TableCell></asp:TableRow><asp:TableRow ID="row14" runat="server"><asp:TableCell ID="TableCell14" runat="server">No. of Years</asp:TableCell><asp:TableCell ID="cellExpYear" runat="server"></asp:TableCell></asp:TableRow><asp:TableRow runat="server"><asp:TableCell runat="server">Experience Description</asp:TableCell><asp:TableCell ID="cellExpDesc" runat="server"></asp:TableCell></asp:TableRow></asp:Table><br /><asp:Label ID="Label4" runat="server" Text="Skills" Font-Bold="True" 
                           Font-Size="Large" ForeColor="Black"></asp:Label><asp:Table ID="TableSkills" runat="server" BackColor="#CCCCCC" Font-Names="Verdana" 
                           Font-Size="11pt" Height="60px" Width="600px"><asp:TableRow ID="TableRow1" runat="server"><asp:TableCell ID="TableCell19" runat="server" Width="200px">Skills</asp:TableCell><asp:TableCell ID="cellSkills" runat="server" Width="400px"></asp:TableCell></asp:TableRow><asp:TableRow ID="TableRow2" runat="server"><asp:TableCell ID="TableCell21" runat="server">Description</asp:TableCell><asp:TableCell ID="cellSkillsDesc" runat="server"></asp:TableCell></asp:TableRow></asp:Table><br /><asp:Label ID="lblStatus" runat="server" EnableViewState="False" 
                           ForeColor="Red"></asp:Label></div></td></tr></table></div></ContentTemplate></asp:TabPanel>
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Resume"><ContentTemplate><div style="height:auto; width:auto;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                 <table style="width: 770px;">
                    <tr>
                        <td align="right">
                        <asp:LinkButton  ID="linkUploadResume" runat="server" Font-Bold="True" Font-Underline="False" ForeColor="Red" onclick="linkUploadResume_Click">Upload New Resume</asp:LinkButton>
                        </td>
                    </tr>
                    
                </table>
                
                <asp:Label ID="lblMsgResume" runat="server" Font-Bold="True" Font-Size="10pt"  ForeColor="Red"></asp:Label>
                
                
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False"  Width="770px" onrowcommand="GridView1_RowCommand" 
                    GridLines="None" CellPadding="4" ForeColor="#333333" AllowPaging="True" 
                    onpageindexchanging="GridView1_PageIndexChanging" >
                                   <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField  HeaderText="Uploaded Resume" >
             
                  
                      <ItemTemplate>
                      <table style="width:100%;">
            <tr>
                <td style="width:12px;">
                    <asp:Label ID="LabelFileName" runat="server" Visible="false" Text=<%# Eval("FileName") %>></asp:Label>
                </td>
                <td  style="width:330px; font-size:medium;">
                
                  <b><%# Eval("ResumeTitle") %></b> 
                </td>
                <td>
                   
                </td>
                
            </tr>
            <tr>
                <td >
                   
                 </td>
                <td>
                    <asp:Label ID="lblUploadDate" runat="server" Text=<%# Eval("UP") %>></asp:Label>
                </td>
                <td>
                   
                  </td>
            </tr>
         
        </table>
                      
                    </ItemTemplate>
                
                   
                </asp:TemplateField>
              
                <asp:ButtonField Text="View Resume" CommandName="ViewResume" />
                <asp:ButtonField Text="Delete" CommandName="DeleteResume" />
                
               
              
              
            </Columns>
                                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle Font-Bold="True" BackColor="#507CD1" ForeColor="White" />
                                   <EditRowStyle BackColor="#2461BF" />
                                   <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
                
                </ContentTemplate>
                </asp:UpdatePanel>
              
                               
                               </div></ContentTemplate></asp:TabPanel>
                               
                               
             <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Employer Review">
             <ContentTemplate>
                 <asp:Label ID="lblResultEmployer" runat="server" EnableViewState="False" 
                     Font-Bold="True" ForeColor="Red"></asp:Label>
             
            <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False"  Width="770px" onrowcommand="GridView2_RowCommand" 
                    GridLines="None" CellPadding="4" ForeColor="#333333" AllowPaging="True" 
                    onpageindexchanging="GridView2_PageIndexChanging" >
                                   <RowStyle BackColor="#EFF3FB" />
            <Columns>
              <asp:TemplateField  HeaderText="Employer List" >
             
                  
                      <ItemTemplate>
                      <table style="width:100%;">
            <tr>
                <td style="width:12px;">
                    <asp:Label ID="lblEmployerCode" runat="server" Text='<%# Eval("EmployerCode") %>' 
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblJobID" runat="server" Text='<%# Eval("JobID") %>' 
                        Visible="false"></asp:Label>
                </td>
                <td style="font-size:medium; width:300px; ">
                
                 <b><%# Eval("JobTitle")%> </b> (<%# Eval("ExpMin") %>-<%# Eval("ExpMax") %>)Years 
                </td>
                <td style="width:50px;">
                   <b> <%# Eval("ViewDate") %></b>
                </td>
            </tr>
            <tr>
                <td >
                   
                   
                </td>
                <td  >
                    
                    <b><%# Eval("CompanyName") %></b> &nbsp;(<%# Eval("Location")%>)<br />
                     <asp:HyperLink ID="HyperLinkweb" runat="server" Font-Size="Small" 
                                                        ForeColor="Blue" Target="_blank" Font-Underline="False"  NavigateUrl= <%# Eval("FullWebsite")%> Text=<%# Eval("Website")%>></asp:HyperLink>
                    
                </td>
                <td>
                   </td>
            </tr>
         
        </table>
                      
                    </ItemTemplate>
                    
                   
                </asp:TemplateField>
              
                <asp:ButtonField Text="Details" CommandName="Details" />
                <asp:ButtonField Text="Remove" CommandName="Remove" />
              
            </Columns>
                                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle Font-Bold="True" BackColor="#507CD1" ForeColor="White" />
                                   <EditRowStyle BackColor="#2461BF" />
                                   <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
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


</asp:Content>
