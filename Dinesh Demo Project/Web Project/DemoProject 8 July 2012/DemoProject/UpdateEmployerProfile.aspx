<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateEmployerProfile.aspx.cs" Inherits="DemoProject.UpdateEmployerProfile" Title="Update Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style7
        {
            width: 186px;
        }
        .style8
        {
            width: 179px;
        }
    </style>
</asp:Content>
  
  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="Outer" style="height: auto; width:1000px">
    <table style="width: 790px;">
            <tr>
                <td valign="top" class="style8">
                  <div style="height:auto; width:190px;">
                   <asp:LinkButton ID="linkBtMyDesboard" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkBtMyDesboard_Click">My Dashboard</asp:LinkButton>
                        <br />
                        <br />
                          <asp:LinkButton ID="linkViewProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                           Font-Underline="False" onclick="linkViewProfile_Click"  >View Profile</asp:LinkButton>
                        <br />
                        <br />
                  <asp:LinkButton ID="linkBtUpdateProfile" runat="server" 
                            CausesValidation="False" ForeColor="Red" 
                          Font-Underline="False" >Update Profile</asp:LinkButton>
                       
                        <br />
                        <br />
                        <asp:LinkButton ID="linkBtChangePassword" runat="server" ForeColor="Red" 
                            Font-Underline="False" CausesValidation="False" 
                          onclick="linkBtChangePassword_Click">Change password</asp:LinkButton>
                             <br />
                        <br />
                  
                  
                  </div>
                </td>
                <td valign="top">
                   <div id="inner" style="height:auto; width:800px;">
                   
    <table style="border: medium solid #808080; width:100%; height:auto; text-align:center" 
                           align="left">
            <tr>
                <td  align="left" colspan="3" valign="top"  >
                    <asp:Label ID="lblEmployerName" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <h4>Details</h4></td>

            </tr>
            <tr>
                <td align="right" class="style7"  >
                    Person-in-Charge *</td>
                <td  >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox>
                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtFirstName" 

ErrorMessage="* Please Specify Your Name" Font-Size="X-Small" ForeColor="#FF3300" SetFocusOnError="True" Display="Dynamic">* Please Specify Your Name</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style7" >
                    Last Name</td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtLastName" runat="server"  Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style7" >
                    Email ID</td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    
                    <asp:Label ID="lblEmailID" runat="server" Font-Size="11pt" ForeColor="Black"></asp:Label>
                                                         </td>
            </tr>
            <tr>
                <td align="right" class="style7" >Company Name*</td>
                <td >&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtCompanyName" runat="server"  Width="200px"></asp:TextBox>
                    

                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server"  ControlToValidate="txtCompanyName" 

ErrorMessage="* Specify Company name" Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  Display="Dynamic">* Specify Company 

name</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style7" >Staff Strength</td>
                <td >&nbsp;</td>
                <td align="left">
                    <asp:DropDownList  ID="ddlStaff" runat="server"  Width="200px">
                        

<asp:ListItem>---Select---</asp:ListItem>
                        

<asp:ListItem>0-10</asp:ListItem>
                        

<asp:ListItem>10-50</asp:ListItem>
                        

<asp:ListItem>50-100</asp:ListItem>
                        

<asp:ListItem>100-500</asp:ListItem>
                        

<asp:ListItem>Above 500</asp:ListItem>
                    

</asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  valign="top" align="right" class="style7" >
                 Address *</td>
                <td  valign="top" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtAddress" runat="server"  Height="61px" TextMode="MultiLine"  Width="300px"></asp:TextBox>
                    
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="txtAddress" 

ErrorMessage="* Enter company address" ForeColor="#FF3300" SetFocusOnError="True" Display="Dynamic">* Enter company address</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td align="right" class="style7" >State*</td>
                <td >&nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtState" runat="server" Width="200px"></asp:TextBox>
                    

            <asp:RequiredFieldValidator ID="txtStateRequiredFieldValidator"  runat="server"  ControlToValidate="txtState" 

ErrorMessage="* Specify State"  Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True" Display="Dynamic">* Specify State name</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style7" >Country</td>
                <td >&nbsp;</td>
                <td align="left">
                    <asp:DropDownList  ID="ddlistCountry" runat="server" Width="200px">
                        

<asp:ListItem>---Select---</asp:ListItem>
                        

<asp:ListItem>India</asp:ListItem>
                        

<asp:ListItem>China</asp:ListItem>
                        

<asp:ListItem>Singapore</asp:ListItem>
                  

</asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="style7" >Phone*</td>
                <td >&nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtPhone" runat="server"  Width="200px"></asp:TextBox>

<asp:RequiredFieldValidator ID="txtStateRequiredFieldValidator0"  runat="server"  ControlToValidate="txtPhone" 

ErrorMessage="* Enter comapny phone no."  Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  Display="Dynamic">* Enter comapny phone no.</asp:RequiredFieldValidator>
                  
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" 
                        runat="server" ControlToValidate="txtPhone" Display="Dynamic" 
                        ErrorMessage="* Invalid no." SetFocusOnError="True" 
                        ValidationExpression="\d{10}">* Invalid no.</asp:RegularExpressionValidator>
                  
                </td>
                    </tr>
            
                        
           
             
            <tr>
                <td class="style7" align="right" >
                    Alternate Contact No&nbsp; </td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtContactList" runat="server" Width="200px"></asp:TextBox>
                    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorAlternateNo" 
                        runat="server" ControlToValidate="txtContactList" Display="Dynamic" 
                        ErrorMessage="* Invalid contact no." SetFocusOnError="True" 
                        ValidationExpression="\d{10}">* Invalid contact no.</asp:RegularExpressionValidator>
                                                         </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style7" align="right" >
                    &nbsp;Alternate Email </td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtEmailList" runat="server" Width="200px"></asp:TextBox>
                    
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorAlternateNo0" 
                        runat="server" ControlToValidate="txtEmailList" Display="Dynamic" 
                        ErrorMessage="* Invalid email address" SetFocusOnError="True" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">* 
                    Invalid email address</asp:RegularExpressionValidator>
                                                         </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style7" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <h4>Website and Social Media</h4></td>
            </tr>
       
            
           
             
            <tr>
                <td align="right" class="style7" >
                   Website *</td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtWebSite" runat="server"  Width="200px"></asp:TextBox> 
                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorWebsite" 
                        runat="server"  ControlToValidate="txtWebSite" 

ErrorMessage="* Specify company website" Font-Size="X-Small" ForeColor="#FF3300" 
                        SetFocusOnError="True" Display="Dynamic">* Specify company website</asp:RequiredFieldValidator>
                </td>
            </tr>
       
            
           
             
            <tr>
                <td align="right" class="style7" >
                    Facebook ID</td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtFacebook" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
       
            
           
             
            <tr>
                <td align="right" class="style7">
                    Twitter ID</td>
                <td>
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox 

ID="txtTwitter" runat="server" 

Width="200px"></asp:TextBox>
                </td>
            </tr>
       
            
           
             
            <tr>
                <td align="right" class="style7">
                    Company Logo</td>
                <td>
                    &nbsp;</td>
                <td align="left">
                    <asp:FileUpload ID="FileUploadComLogo" runat="server" />
                </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style7" >
                  
                </td>
                <td >
                  
                    &nbsp;</td>
                <td align="left">
                  <asp:Button  ID="btnUpdate" runat="server" Text="UPDATE" onclick="btnUpdate_Click"/> 

&nbsp;&nbsp;
                    <asp:Button  ID="btnCancel" runat="server" Text="CANCEL"  
                        CausesValidation="False" onclick="btnCancel_Click" />
                &nbsp;&nbsp;
                </td>
            </tr>
           
             
            <tr>
                <td align="left" class="style7"  >Note: * Mandatory Field</td>
                <td align="left"  >&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
                <td align="left">
                    <asp:Label ID="lblResult" runat="server" EnableViewState="False" Font-Bold="True" Font-Size="Medium" ForeColor="#FF3300"></asp:Label>
                         </td>
            </tr>            
        </table>
    
        </div>
                  
                </td>
            </tr>
        </table>
    
    
</div>
 
</asp:Content>
