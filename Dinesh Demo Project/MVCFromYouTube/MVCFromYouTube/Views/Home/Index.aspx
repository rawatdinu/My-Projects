﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
    <% foreach (string count in ViewData["Countries"])
       { %>
    Thies is new set of view
    <ul>
    <li> <%=count%></li>
    </ul>
    <%} %>
    </div>
</body>
</html>