﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MyHomePage</title>
</head>
<body>
    <div>
    Welcome to my first mvc view<br />
    Current Time is <%=ViewData["CurrentTime"] %>
    </div>
</body>
</html>