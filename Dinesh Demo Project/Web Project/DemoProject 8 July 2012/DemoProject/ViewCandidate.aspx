<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewCandidate.aspx.cs" Inherits="DemoProject.ViewCandidate" Title="Candidate list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style12
        {
            width: 200px;
        }
        .style13
     {
         width: 93px;
     }
     .style14
     {
         width: 17px;
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
                           Font-Underline="False" onclick="linkBtMyDesboard_Click"  >My Dashboard</asp:LinkButton>
                        <br />
                        <br />
                         <asp:LinkButton ID="linkViewProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkViewProfile_Click"  >View Profile</asp:LinkButton>
                        <br />
                        <br />
                  <asp:LinkButton ID="linkBtUpdateProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                          Font-Underline="False" onclick="linkBtUpdateProfile_Click" >Update Profile</asp:LinkButton>
                       
                        <br />
                        <br />
                        <asp:LinkButton ID="linkBtChangePassword" runat="server" ForeColor="Red" 
                             Font-Underline="False" CausesValidation="False" onclick="linkBtChangePassword_Click" 
                           >Change password</asp:LinkButton>
                             <br />
                        <br />
                    
                    </asp:Panel>
                
                   
                </td>
                <td valign="top">
                    <div style="border: medium solid #808080; height:auto; width:790px">
                  
                      
                                 
                                    <div style=" height:auto; width:790px">
                                        <table style="width: 100%;" bgcolor="#D1DDF1">
                                            <tr>
                                                <td class="style13">
                                                    &nbsp;
                                                    Title</td>
                                                <td class="style14">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Medium" 
                                                        ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style13">
                                                    &nbsp;
                                                    Experience</td>
                                                <td class="style14">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:Label ID="lblExperience" runat="server" ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style13">
                                                    &nbsp;
                                                    Salary</td>
                                                <td class="style14">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:Label ID="lblSalary" runat="server" ForeColor="Black"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                   
                                    </div>
                        <asp:Label ID="lblResult" runat="server" EnableViewState="False" Font-Bold="True" 
                                        ForeColor="Red" Visible="False"></asp:Label>
                                    
                                   
                               
                            
                       
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            Width="790px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            onrowcommand="GridView1_RowCommand" 
                            onpageindexchanging="GridView1_PageIndexChanging">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField HeaderText="Candidate List">
                                <ItemTemplate>
                                <table style="height:auto; width:auto;">
                <tr>
                    <td style="width:15px; ">
                    <asp:Label ID="lblUserCode" runat="server" Text= <%# Eval("UserCode")%> Visible="false"> </asp:Label>
                        <asp:Label ID="lblFileResume" runat="server" Visible="false" Text= <%# Eval("FileResume")%>> </asp:Label>
                       
                    </td>
                     <td  style="width:300px;">
                         <asp:Label ID="Label1" runat="server" Text=<%# Eval("FirstName")%> ForeColor="Black" Font-Size="12" Font-Bold="True"></asp:Label>&nbsp;
                           <asp:Label ID="Label2" runat="server" Text=<%# Eval("LastName")%> ForeColor="Black" Font-Size="12" Font-Bold="True"></asp:Label>
                      
                   
                    </td>
                    <td style="width:100px;">
                      <%# Eval("Degree")%> 
                    </td>
                    
                    <td style="width:70px; ">
                        <%# Eval("AppliedOn")%>
                    </td>
                   
                   
                </tr>
                 <tr>
                    <td >
                    
                       
                    </td>
                     <td  >
                     <%# Eval("ExperienceField")%> &nbsp; ( <%# Eval("NoOfYears")%>)&nbsp;Years<br />
                    Last Update: <%# Eval("UpdateDate")%><br />
                    Email:<%# Eval("Email")%> &nbsp;Phone:<%# Eval("Phone")%>
                    </td>
                    <td >
                      
                      
                    </td>
                    
                    <td >
                     
                    </td>
                   
                </tr>
                
            </table>
                                
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="View Resume" CommandName="ViewResume" />
                                <asp:ButtonField Text="View Profile" CommandName="ViewProfile" />
                            </Columns>
                        
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        
                        </asp:GridView>       
                             
                  
                       
                    
                                 
                        
                    
                    </div>
                   
                </td>
            </tr>
        </table>
    
        
    </div>
</asp:Content>
