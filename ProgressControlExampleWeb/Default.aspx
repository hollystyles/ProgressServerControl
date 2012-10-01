<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProgressControlExampleWeb.Default" %>

<%@ Register Assembly="Hollyathome.Web" Namespace="Hollyathome.Web.UI" TagPrefix="hah" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .progressBar {
            height: 20px;
            background-color: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <hah:ProgressControl ID="ProgressControl1" runat="server" CssClass="progressBar" />
    </div>
    </form>
</body>
</html>
