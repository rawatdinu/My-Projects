<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ResourceDetails.aspx.cs" Inherits="NIITBilling.ResourceDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Outer" style="height: auto; width:1000px">
    <table style="width: 100%;">
          
            <tr>
                <td  align="left" colspan="3" valign="top"  >
                    <asp:Label  ID="lblUserName" runat="server"  Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11" align="left" >
                    &nbsp;</td>
                <td class="style10" >
                    &nbsp;</td>
                <td align="left">
                    <h4>Resource Details</h4></td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    Resource ID *</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtResourceID" runat="server"  Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server"  
                        ControlToValidate="txtResourceID"  ErrorMessage="Please Specify Resource ID"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">Please Specify Your Name</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="style11" align="right" >
                    First Name *</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtFirstName" runat="server"  Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server"  
                        ControlToValidate="txtFirstName"  ErrorMessage="Please Specify First 
 Name"  Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  Display="Dynamic">Please Specify First Name</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11"  align="right" >
                    Last Name</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11"  align="right" >
                    SOW</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtSOW" runat="server" Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator10" runat="server"  
                        ControlToValidate="txtSOW"  ErrorMessage="Please enter SOW"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">Please enter SOW</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11"  align="right" >
                    PONumber</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtPONumber" runat="server" Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator11" runat="server"  
                        ControlToValidate="txtPONumber"  ErrorMessage="Please Specify PO Number"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">Please Specify PO Number</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11"  align="right" >
                    SONumber</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtSONumber" runat="server" Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator12" runat="server"  
                        ControlToValidate="txtSONumber"  ErrorMessage="Please Specify SO Number"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">Please Specify SO Number</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    Start Date (mm/dd/yyyy) 

*</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                                    
                    <asp:TextBox ID="txtStartDate"  runat="server"></asp:TextBox>&nbsp; 
<asp:RequiredFieldValidator  ID="txtDOBRequiredFieldValidator"  runat="server" 
                        ControlToValidate="txtStartDate" ErrorMessage="* Enter Start Date" 
 Font-Size="X-Small" ForeColor="#FF3300"  Display="Dynamic"  SetFocusOnError="True">* Enter Start Date</asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="txtDateRegularExpressionValidator" 
                        runat="server" ControlToValidate="txtStartDate" Display="Dynamic" 
                        ErrorMessage="* Invalid Date" 
                        
                        
                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d">* 
                    Invalid Date</asp:RegularExpressionValidator>
                        

                   
                    
                    </td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    End Date (mm/dd/yyyy) 

*</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                                    
                    <asp:TextBox ID="txtEndDate"  runat="server"></asp:TextBox>&nbsp; 
<asp:RequiredFieldValidator  ID="RequiredFieldValidator3"  runat="server" 
                        ControlToValidate="txtEndDate" ErrorMessage="* Enter End Date" 
 Font-Size="X-Small" ForeColor="#FF3300"  Display="Dynamic"  SetFocusOnError="True">* Enter End Date</asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="txtEndDate" Display="Dynamic" 
                        ErrorMessage="* Invalid Date" 
                        
                        
                        ValidationExpression="(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d">* Invalid Date</asp:RegularExpressionValidator>
                        

                   
                    
                    </td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    Billing Type </td>
                <td 

align="right" class="style10" >
                    &nbsp;</td>
                <td align="left">
                    
                    <asp:DropDownList  ID="ddBillingType" runat="server" Width="200px">
                        

<asp:ListItem>---Select--- </asp:ListItem>
                        

<asp:ListItem>T&M</asp:ListItem>
                        

<asp:ListItem>Fixed</asp:ListItem>
                    

</asp:DropDownList> 
                </td>
            </tr>
           
            
            <tr>
                <td class="style11"align="right" >
                    Project Name *</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtProjectName" runat="server"  Width="200px"></asp:TextBox> 
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidatorState" runat="server"  
                        ControlToValidate="txtProjectName"  ErrorMessage="* Enter project name"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">* Enter project name</asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td class="style11"  align="right" >
                    Location</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtLocation" runat="server"  Width="200px"></asp:TextBox>
                </td>
                    </tr>
            
            <tr>
                <td class="style11" align="right" >
                    Hourly Rate *</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtHourlyRate" runat="server" Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator9" runat="server"  ControlToValidate="txtHourlyRate" 

ErrorMessage="Enter Hourly Rate"   Font-Size="X-Small" ForeColor="#FF3300"  Display="Dynamic">Enter Hourly Rate</asp:RequiredFieldValidator> 
                  
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" 
                        runat="server" ControlToValidate="txtHourlyRate" Display="Dynamic" 
                        ErrorMessage="* Invalid amount" SetFocusOnError="True" 
                        ValidationExpression="[0-9]*">* Invalid amount</asp:RegularExpressionValidator>
                  
                    <br />
                </td>
            </tr>
       
                        
           
             
            <tr>
                <td class="style11"  align="right" > Status *</td>
                <td class="style10" align="right"> &nbsp;</td>
                <td align="left">
                    <asp:RadioButton ID="rdoActive" runat="server" Text="Active" Width="100px" 
                        GroupName="rdoStatus" />
                    
                    <asp:RadioButton ID="rdoNonActive" runat="server" Text="Non-Active" 
                        Width="100px" GroupName="rdoStatus"  />
                    

                </td>
            </tr>
       
            
           
             
            
       
            
           
             
            <tr>
                <td class="style11" >
                    &nbsp;</td>
                <td class="style10" >
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
       
            
           
             
            
                <td class="style9"  >
                  
                </td>
                <td class="style10"  >
                  
                    &nbsp;</td>
                <td align="left">
                  <asp:Button  ID="cmdSave" runat="server"  Text="SAVE" 
                        Width="100px" onclick="cmdSave_Click"    /> 

&nbsp;&nbsp;
                    <asp:Button  ID="btnCancel" runat="server"  Text="CANCEL"  
                        CausesValidation="False" Width="100px" />
                &nbsp;&nbsp;
                </td>
            </tr>
        
            <tr>
                <td class="style9"  align="justify"  > Note:* Mandatory Field </td>
                <td   align="left" class="style10"  >
                 
                    </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11" >
                    &nbsp;</td>
                <td class="style10"   >
                    &nbsp;</td>
                <td align="left">
                    <asp:Label  ID="lblResult" runat="server"               
EnableViewState="False" Font-Bold="True" Font-Size="Medium"  ForeColor="#FF3300"></asp:Label>
                         </td>
            </tr>            
        </table>
        </div>
                  
                </td>
            </tr>
        </table>
    
    
</div>

</asp:Content>
