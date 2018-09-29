<%@ MasterType virtualpath="~/NewMasterPage.master" %>
<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master"AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DemoProject.Home" Title="Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <style type="text/css">
    
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:auto; width:1000px;">
<table cellpadding="0" cellspacing="0" style=" height:auto; width:100%;">
        <tr>
            <td valign="top">
               <div style="border: thin solid #808080; width:696px; height:264px; margin-top:5px;">
     <table cellpadding="0" cellspacing="0" style="height: 259px; width:100%;">
         <tr>
            <td valign="top" > 
                <div style="height:auto;">
                     <img src="images/man.jpg" alt="" height="225px" width="200px" /> </div>
             </td>
            <td >
                <div style="width:496px; height:250px;margin-top:5px;">
                     <h2>Become the premium Member of NaukariChahiye.Com</h2>
                      <p style="text-decoration:none; text-align:left;"> Source the best talent from a database of over 28 million searchable resumes.
                 Enhance your reach by publishing your jobs in leading print publications who we have partnered with.
              Organize and simplify your recruitment process using our response management tools. 
             </p>          
      
            </div>          
         </td>
         </tr>
         </table>
    </div>
            </td>
           
            <td >
              
     <div style="border: thin solid #808080; width:296px; height:145px; margin-top:5px;">  
       <div style=" width:296; background-color:#5D7B9D; text-align:center; color:White ">Login Here!!!</div>
       <table  style="width:100%;" >                    
                      <tr>
                      <br />
                      <td align="right" style="width:70px;"  >
                          Email Id </td>
                      <td align="left"  style="width:200px;">
                      <asp:TextBox ID="txtEmailId" runat="server" Width="200px"></asp:TextBox>
                        
                      </td>
                    </tr> 
                    <tr>
                         <td>
                   
                         </td>
                    <td>
                      &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                              ControlToValidate="txtEmailId" Display="Dynamic" 
                              ErrorMessage=" * invalid e-mail id" Font-Size="Small" 
                              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> * 
                          invalid e-mail id</asp:RegularExpressionValidator>
                    </td>
                    </tr>                  
                   <tr>
                                                <td align="right" >
                                                    Password  </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>                   
                   <tr>
                                                <td align="center" >
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:Button ID="btnLogin" runat="server" onclick="Button1_Click" Text="Login" 
                                                        Width="59px" />
                                                &nbsp;&nbsp;
                                                    <asp:LinkButton ID="linkforgetPwd" runat="server" CausesValidation="False" 
                                                        Font-Size="8pt" Font-Underline="False" ForeColor="Red" 
                                                        onclick="linkforgetPwd_Click">forget password?</asp:LinkButton>
                                                </td>
                                            </tr>
                   <tr>
                      <td align="left" colspan="2">
                                                    <asp:Label ID="lblStatus" runat="server" ForeColor="Red" EnableViewState="False" 
                                                       ></asp:Label>
                                                </td>
                   </tr>
                   </table>
     </div>
    
     
     <div style="border: thin solid #808080; background: url('images/ad1.jpg'); height:400px; width:296px; background-repeat:no-repeat; margin-top:15px;"></div>
    
            </td>
            
        </tr>
        </table>
</div>
    
</asp:Content>
