<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HideRoute.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="/about">About Us</a> | <a href="/contact">Contact Us</a> | <a href="/login">
            Login</a>
    </div>
    <div>
        <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
    </div>
    </form>

    <script src="https://code.jquery.com/jquery-2.2.0.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $("a").click(function (e) {
                e.preventDefault();
                var attrHref = $(this).attr("href");
                $.getJSON("/service.asmx/SetRouteCookie", { href: attrHref }, function (e) {
                    window.location.reload();
                });
            });
        });
    </script>
</body>
</html>
