<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WOC.Book.Registration.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>German Store</title>
</head>
<body>
    <input type="text" id="datepick" value="" />

</body>

    <script src="../Jquery/js/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../Jquery/js/jquery.glob.js" type="text/javascript"></script>
    <script src="../Jquery/globinfo/jQuery.glob.ar-AE.min.js" type="text/javascript"></script>
    <script src="../Jquery/ui/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../Jquery/ui/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">

        $.preferCulture("ar-AE");
        $("#datepick").datepicker();
    </script>
    
</html>