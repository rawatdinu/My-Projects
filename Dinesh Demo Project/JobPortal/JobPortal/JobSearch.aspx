<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="JobSearch.aspx.cs" Inherits="DemoProject.JobSearch" Title="Search Job" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style12
        {
            width: 200px;
        }
        .WaterMark
        {
            font-size:13px;
            font-style:italic;
            color:Gray;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <div style="border: medium solid #808080; height:auto; width:790px">
                  
                        <table style="width: 100%;">
                            <tr>
                                <td align="justify" valign="middle" > 
                                    &nbsp;
                                    <asp:TextBox ID="txtKeyWord" runat="server" Width="350px" Height="25px" 
                                        BorderColor="Black" BorderWidth="1px" BackColor="#D1DDF1" 
                                        BorderStyle="Solid" AutoPostBack="True" 
                                        ontextchanged="txtKeyWord_TextChanged"></asp:TextBox>
                     &nbsp;
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtKeyWord" WatermarkText="Jobs" WatermarkCssClass="WaterMark">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="txtKeyWord" Radius="6" Corners="All">
                                    </asp:RoundedCornersExtender>
                                </td>
                               
                                <td align="justify" valign="middle" > &nbsp; 
                                    <asp:TextBox ID="txtLocation" runat="server" Width="350px" Height="25px" 
                                        BorderColor="Black" BorderWidth="1px" BackColor="#D1DDF1" 
                                        BorderStyle="Solid" AutoPostBack="True" 
                                        ontextchanged="txtLocation_TextChanged"></asp:TextBox>
                                     <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtLocation" WatermarkText="Location" WatermarkCssClass="WaterMark">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="txtLocation" Radius="6" Corners="All">
                                    </asp:RoundedCornersExtender>
                                    &nbsp;
                        <asp:Button ID="Button1" runat="server" Text="....." onclick="Button1_Click" />
                        
                                </td>
                            </tr>
                            
                        </table> 
                       
                       <hr />
                       
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                            Width="790px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            onrowcommand="GridView1_RowCommand" 
                            onpageindexchanging="GridView1_PageIndexChanging">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                <table style="height:auto; width:auto;">
                <tr>
                    <td style="width:100px; ">
                    <asp:Label ID="lblJobID" runat="server" Text= <%# Eval("JobID")%> Visible="false"> </asp:Label>
                        <asp:Label ID="lblJobType" runat="server" Text= <%# Eval("JobType")%>> </asp:Label>
                       
                    </td>
                     <td  style="width:300px;">
                         <asp:Label ID="Label3" runat="server" Text= <%# Eval("JobTitle")%> Font-Size="11" Font-Bold="True"></asp:Label> &nbsp;(<%# Eval("ExpMin")%>-<%# Eval("ExpMax")%>)Years
                    </td>
                    <td style="width:150px;">
                       <%# Eval("Location")%> 
                    </td>
                    
                    <td style="width:100px; ">
                        <%# Eval("PostDate")%>
                       
                    </td>
                   
                   
                </tr>
                 <tr>
                    <td >
                       
                    </td>
                     <td  >
                       <%# Eval("CompanyName")%> <br />  <%# Eval("Website")%>
                    </td>
                    <td >
                      
                    </td>
                    
                    <td >
                       Applicants (<%# Eval("Num") %>)
                    </td>
                   
                </tr>
                
            </table>
                                
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Apply" CommandName="Apply" />
                                <asp:ButtonField Text="Details" CommandName="Details" />
                            </Columns>
                        
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        
                        </asp:GridView>       
                             
                  
                       
                    
                                 
                        
                    
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                
                    
                   
                </td>
            </tr>
        </table>
    
        
    </div>

</asp:Content>
