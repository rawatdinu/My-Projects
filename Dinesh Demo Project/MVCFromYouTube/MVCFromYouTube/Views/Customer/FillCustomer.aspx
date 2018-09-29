<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>FillCustomer</title>
</head>
<body>
    <form action="DisplayCustomer" method="post" >
    Customer Id :- <input type="text" name="CustomerId"/><br />
    Customer code :- <input type="text" name="CustomerCode"/><br />
    Amount :- <input type="text" name="Amount"/><br />
    <input type=submit value="Submit"/><br />
    </form>
    <%using (Html.BeginForm("DisplayCustomer", "Customer", FormMethod.Post))
      { %>



   <%-- <%--Enter custome id : <% = Html.TextBox("CustomerId") %><br />    
    Enter Customer Code:<% =Html.TextBox("CustomerCode") %><br />
    Enter Amout: <% =Html.TextBox("Amount") %><br />
    <input type="submit" value="Submit Custoer Data" />--%>



    <fieldset>
    <legend>Customer INfo</legend>
    <div>
    <%=Html.Label("Customer ID") %>
    </div>
    <div>
    <% = Html.TextBox("CustomerId") %>
    </div>

    <div>
     <%=Html.Label("Code") %>
    </div>
    <div>
    <% =Html.TextBox("CustomerCode") %>
    </div>

    <div>
    <%=Html.Label("Amount") %>
    </div>
    <div>
    <% =Html.TextBox("Amount") %>
    </div>
    <input type="submit" value="Submit Custoer Data" />
    </fieldset>
    
    <%} %>


</body>
</html>

