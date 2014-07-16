<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Status.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            getStatus.ashx?complete=true&android=true&ios=true&wp=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=true&android=true&ios=true&wp=true" /><br />
            getStatus.ashx?complete=false&android=false&ios=true&wp=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=true&wp=true" /><br />
            getStatus.ashx?complete=false&android=true&ios=false&wp=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=false&wp=true" /><br />
            getStatus.ashx?complete=false&android=true&ios=true&wp=false<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=true&wp=false" /><br />
            getStatus.ashx?complete=false&android=false&ios=false&wp=false<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=false&wp=false" /><br />
            getStatus.ashx?complete=true&android=true&ios=true&wp=true&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=true&android=true&ios=true&wp=true&text=true" /><br />
            getStatus.ashx?complete=false&android=false&ios=true&wp=true&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=true&wp=true&text=true" /><br />
            getStatus.ashx?complete=false&android=true&ios=false&wp=true&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=false&wp=true&text=true" /><br />
            getStatus.ashx?complete=false&android=true&ios=true&wp=false&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=true&wp=false&text=true" /><br />
            getStatus.ashx?complete=false&android=false&ios=false&wp=false&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=false&wp=false&text=true" /><br />
        </div>
    </form>
</body>
</html>
