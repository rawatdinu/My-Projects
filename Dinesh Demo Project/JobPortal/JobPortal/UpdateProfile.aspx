<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="DemoProject.UpdateProfile" Title="Update Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


   
    <style type="text/css">
        .style9
        {
            width: 158px;
        }
        .style10
        {
            width: 7px;
        }
        .style11
        {
            height: 18px;
            width: 158px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
    <div id="Outer" style="height: auto; width:1000px">
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
                          Font-Underline="False">Update Profile</asp:LinkButton>
                       
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
                   <div id="inner" style="height:auto; width:790px;">
                   <table style="border: medium solid #808080; width:100%; height:auto; text-align:center" 
                           align="left" >
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
                    <h4>Your Details</h4></td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    First Name *</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtFirstName" runat="server"  Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtFirstName"  ErrorMessage="Please Specify Your 
 Name"  Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  Display="Dynamic">Please Specify Your Name</asp:RequiredFieldValidator>
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
                <td class="style11" align="right" >
                    D.O.B(dd/mm/yyyy) 

*</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                                    
                    <asp:TextBox ID="txtDOB"  runat="server"></asp:TextBox>&nbsp; 
<asp:RequiredFieldValidator  ID="txtDOBRequiredFieldValidator"  runat="server" ControlToValidate="txtDOB" ErrorMessage="* Enter D O.B" 
 Font-Size="X-Small" ForeColor="#FF3300"  Display="Dynamic"  SetFocusOnError="True">* Enter D.O.B</asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="txtDateRegularExpressionValidator" 
                        runat="server" ControlToValidate="txtDOB" Display="Dynamic" 
                        ErrorMessage="* Invalid Date" 
                        
                        ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">* 
                    Invalid Date</asp:RegularExpressionValidator>
                        

                   
                    
                    </td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    Email ID </td>
                <td 

align="right" class="style10" >
                    &nbsp;</td>
                <td align="left">
                    
                    <asp:Label ID="lblEamilId" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    Gender *</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:DropDownList ID="ddlistGender" runat="server" Height="17px" Width="128px">
                        

<asp:ListItem>---Select---</asp:ListItem>
<asp:ListItem>Male</asp:ListItem>

                        <asp:ListItem>Female</asp:ListItem>

</asp:DropDownList>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator10" runat="server"  
                        ControlToValidate="ddlistGender"  ErrorMessage="* Select Gender"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">* Select Gender</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11" align="right" >
                    Profile Photo</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:FileUpload ID="FileUploadPhoto" runat="server" />
                    (.gif, .jpeg, .jpg)</td>
            </tr>
            <tr>
                <td class="style11" valign="top" align="right" >
                    Address *</td>
                <td class="style10" valign="top" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtAddress" runat="server" Height="61px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidatorAddress" runat="server"  
                        ControlToValidate="txtAddress"  ErrorMessage="* Enter address"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">* Enter address</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11"align="right" >
                    State *</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtState" runat="server"  Width="200px"></asp:TextBox> 
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidatorState" runat="server"  
                        ControlToValidate="txtState"  ErrorMessage="* Enter state name"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">* Enter state name</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11"  align="right" >
                    Country</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:DropDownList  ID="ddlistCountry" runat="server" Width="200px">
                        

<asp:ListItem>---Select--- </asp:ListItem>
                        

<asp:ListItem>India</asp:ListItem>
                        

<asp:ListItem>China</asp:ListItem>
                        

<asp:ListItem>Singapore</asp:ListItem

>
                    

</asp:DropDownList> </td>
            </tr>
            <tr>
                <td class="style11"  align="right" >
                    Phone</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtPhone" runat="server"  Width="200px"></asp:TextBox>
                </td>
                    </tr>
            
            <tr>
                <td class="style11" align="right" >
                    Mobile Number *</td>
                <td class="style10"  align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtMobile" runat="server" Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidator9" runat="server"  ControlToValidate="txtMobile" 

ErrorMessage="RequiredFieldValidator"   Font-Size="X-Small" ForeColor="#FF3300"  Display="Dynamic">Enter Mobile 

No.</asp:RequiredFieldValidator> 
                  
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" 
                        runat="server" ControlToValidate="txtMobile" Display="Dynamic" 
                        ErrorMessage="* Invalid no." SetFocusOnError="True" 
                        ValidationExpression="\d{10}">* Invalid no.</asp:RegularExpressionValidator>
                  
                    <br />
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
       
            
           
             
            <tr>
                <td class="style11" >
                    &nbsp;</td>
                <td class="style10" >
                    &nbsp;</td>
                <td align="left"> <h4>Qualification</h4></td>
            </tr>
       
            
           
             
            <tr>
                <td class="style11"  align="right" > Certificate/Degree *</td>
                <td class="style10" align="right"> &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtDegree" runat="server" Width="200px"></asp:TextBox>
                    

<asp:RequiredFieldValidator  ID="RequiredFieldValidatorDegree" runat="server"  
                        ControlToValidate="txtDegree"  ErrorMessage="* Your certification/degree"  
                        Font-Size="X-Small" ForeColor="#FF3300"  SetFocusOnError="True"  
                        Display="Dynamic">* Your certification/degree</asp:RequiredFieldValidator>
                    

                </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style11" 

align="right" >Passing Year *</td>
                <td class="style10" 

align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:DropDownList  ID="ddlistPassingYear" runat="server"  Height="17px" Width="128px">
                        

<asp:ListItem>---Select---</asp:ListItem>
                        

<asp:ListItem>2000</asp:ListItem>
                        

<asp:ListItem>2001</asp:ListItem>
                        

<asp:ListItem>2002</asp:ListItem>
                        

<asp:ListItem>2003</asp:ListItem>
                        

<asp:ListItem>2004</asp:ListItem>
                        

<asp:ListItem>2005</asp:ListItem>
                    

</asp:DropDownList>
                </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style11"  align="right" >
                    Marks(%)</td>
                <td class="style10" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtMarks" runat="server"></asp:TextBox>
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
       
            
           
             
            <tr>
                <td class="style11" >
                    &nbsp;</td>
                <td class="style10"  >
                    &nbsp;</td>
                <td align="left">
                    

<h4>Experience</h4></td>
            </tr>
       
            
           
             
            <tr>
                <td class="style11"  align="right" >
                   Experience  Field</td>
                <td  align="right" & nbsp;</td> 
                <td align="left">
                    <asp:DropDownList ID="ddlExpField" runat="server" Width="200px">
                        <asp:ListItem>----Select----</asp:ListItem>
                        <asp:ListItem>Finance</asp:ListItem>
                        <asp:ListItem>Marketing</asp:ListItem>
                        <asp:ListItem>IT Services</asp:ListItem>
                        <asp:ListItem>BPO</asp:ListItem>
                        <asp:ListItem>HR</asp:ListItem>
                    </asp:DropDownList>
               </td>
            </tr> 
            <tr>
                <td class="style11"  align="right" >
                    No of Year  </td>
                <td  align="right" class="style10" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtExpYears"  runat="server"></asp:TextBox> 

<asp:RangeValidator ID="txtExpYearRangeValidator"  runat="server"  ControlToValidate="txtExpYears"  Display="None" ErrorMessage="*  Invalid numbers" 
 MaximumValue="60" MinimumValue="0"  SetFocusOnError="True"  Type="Integer">* Invalid numbers</asp:RangeValidator>
                </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style11" valign="top" align="right" >
                    Description</td>
                <td class="style10"  valign="top" align="right" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtExpDesc" runat="server" Height="54px" TextMode="MultiLine" 
Width="300px"></asp:TextBox>
                </td>
            </tr>
              
            <tr>
                <td class="style11" >
                    &nbsp;</td>
                <td class="style10"  >
                    &nbsp;</td>
                <td align="left">
                    

<h4>Skills</h4></td>
            </tr>
       
            
           
             
            <tr>
                <td class="style11" align="right" >
                    Skills</td>
                <td  align="right" class="style10" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox ID="txtSkills" runat="server"  Width="200px"></asp:TextBox>
                </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style11" 

valign="top" align="right" >
                    Description</td>
                <td  valign="top" align="right" class="style10" >
                    &nbsp;</td>
                <td align="left">
                    <asp:TextBox  ID="txtSkillsDesc" runat="server" 

Height="52px" TextMode="MultiLine"  Width="300px"></asp:TextBox>
                </td>
            </tr>
       
            
           
             
            <tr>
                <td class="style9"  >
                  
                </td>
                <td class="style10"  >
                  
                    &nbsp;</td>
                <td align="left">
                  <asp:Button  ID="btnUpdate" runat="server"  Text="UPDATE"  onclick="btnUpdate_Click"    /> 

&nbsp;&nbsp;
                    <asp:Button  ID="btnCancel" runat="server"  Text="CANCEL"  
                        CausesValidation="False" onclick="btnCancel_Click" />
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
