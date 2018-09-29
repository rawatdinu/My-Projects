<%@ Page Language="C#" MasterPageFile="~/NewMasterPage.Master" AutoEventWireup="true" CodeBehind="ApplyWithoutRegistration.aspx.cs" Inherits="DemoProject.ApplyWithoutRegistration" Title="Apply without registration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type ="text/css">
    .style1
    {
        width: 170px;
    }
    .style2
    {
        width: 7px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div style="width:1000px; height:auto;">
 <h3 style="padding-left:10px;">   New User: Apply to Selected Job</h3>
 <p style="padding-left:10px">   Please fill the following details to apply selected job</p>
 <p style="padding-left:10px">   If you are registered user, then <a style="font-size:12px; color:Blue;" href="LoginToApply.aspx"><b>Login Here</b> </a></p>


    <table style="width: 100%;">
        <tr>
            <td align="right" class="style1">
                &nbsp;
                Name *</td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
               
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                    ControlToValidate="txtName" Display="Dynamic" 
                    ErrorMessage="* Name cannot be empty" SetFocusOnError="True">* Name cannot 
                be empty</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                &nbsp;
                Work Experience(Years)</td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
               
                <asp:DropDownList ID="DropDownListExp" runat="server" Width="120px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                &nbsp;
                E-mail Address *</td>
            <td class="style2">
                &nbsp;
            </td>
            <td>
               
                <asp:TextBox ID="txtEmailAddress" runat="server" Width="200px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" 
                    ControlToValidate="txtEmailAddress" Display="Dynamic" 
                    ErrorMessage="* Email address cannot be empty" SetFocusOnError="True">* 
                Email address cannot be empty</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmailAddress" runat="server" 
                    ErrorMessage="* Invalid e-mail address" 
                    ControlToValidate="txtEmailAddress" Display="Dynamic" SetFocusOnError="True" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">* 
                Invalid e-mail address</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                Mobile No. *</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtContactNo" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNameContactNo" runat="server" 
                    ControlToValidate="txtContactNo" Display="Dynamic" 
                    ErrorMessage="* Contact No cannot be empty" SetFocusOnError="True">* Contact 
                No cannot be empty</asp:RequiredFieldValidator>
                  
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobile" 
                        runat="server" ControlToValidate="txtContactNo" Display="Dynamic" 
                        ErrorMessage="* Invalid no." SetFocusOnError="True" 
                        ValidationExpression="\d{10}">* Invalid no.</asp:RegularExpressionValidator>
                  
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                City</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                State *</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtState" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNameContactNo0" runat="server" 
                    ControlToValidate="txtState" Display="Dynamic" 
                    ErrorMessage="* State name cannot be empty" SetFocusOnError="True">* State 
                name cannot be empty</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                Country *</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNameContactNo1" runat="server" 
                    ControlToValidate="txtCountry" Display="Dynamic" 
                    ErrorMessage="* Enter country name" SetFocusOnError="True">* Enter country 
                name</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                Resume *</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:FileUpload ID="FileUploadResume" runat="server" />
                (.txt,.doc,.docx,.pdf)<asp:RequiredFieldValidator 
                    ID="RequiredFieldValidatorNameContactNo2" runat="server" 
                    ControlToValidate="FileUploadResume" Display="Dynamic" 
                    ErrorMessage="* Select Resume" SetFocusOnError="True">* Select Resume</asp:RequiredFieldValidator>
                                         </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonApply" runat="server" Text="Apply Now" Font-Bold="True" 
                    onclick="ButtonApply_Click" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                Note: * Mandaroty fields</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblResult" runat="server" EnableViewState="False" 
                    Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
  


</div>

</asp:Content>
