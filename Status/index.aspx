<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Status.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Usage</h1>
            http://projectstatus.apphb.com/getStatus.ashx?complete=true&android=true&ios=true&wp=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=true&android=true&ios=true&wp=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=false&ios=true&wp=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=true&wp=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=true&ios=false&wp=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=false&wp=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=true&ios=true&wp=false<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=true&wp=false" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=false&ios=false&wp=false<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=false&wp=false" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=true&android=true&ios=true&wp=true&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=true&android=true&ios=true&wp=true&text=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=false&ios=true&wp=true&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=true&wp=true&text=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=true&ios=false&wp=true&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=false&wp=true&text=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=true&ios=true&wp=false&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=true&ios=true&wp=false&text=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=false&android=false&ios=false&wp=false&text=true<br />
            <img height="200" width="200" src="getStatus.ashx?complete=false&android=false&ios=false&wp=false&text=true" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=60x60<br />
            <img src="getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=60x60" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=s<br />
            <img src="getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=s" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=m<br />
            <img src="getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=m" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=l<br />
            <img src="getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=l" /><br />
            http://projectstatus.apphb.com/getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=60x60<br />
            <img src="getStatus.ashx?complete=true&android=true&ios=true&wp=true&size=60x60" /><br />
        </div>
    </form>
</body>
</html>
