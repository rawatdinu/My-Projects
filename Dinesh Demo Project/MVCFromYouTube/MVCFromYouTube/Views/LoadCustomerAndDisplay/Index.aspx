<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVCFromYouTube.Models.Customer>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
   MVC Data from Modal to Control to View<br />
    Customer Id is: <%=Model.Id %><br />
    Customer Code is : <%=Model.CustomerCode %><br />
    Customer Amount is: <%=Model.Amount %><br />
    
    </div>
</body>
</html>
