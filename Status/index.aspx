<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Status.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    getStatus.ashx?IsComplete=true&IsAndroidComplete=true&IsiOSComplete=true&IsWP8Complete=true<br />
        <img src="getStatus.ashx?IsComplete=true&IsAndroidComplete=true&IsiOSComplete=true&IsWP8Complete=true" /><br />
    getStatus.ashx?IsComplete=false&IsAndroidComplete=false&IsiOSComplete=true&IsWP8Complete=true<br />
        <img src="getStatus.ashx?IsComplete=false&IsAndroidComplete=false&IsiOSComplete=true&IsWP8Complete=true" /><br />
    getStatus.ashx?IsComplete=false&IsAndroidComplete=true&IsiOSComplete=false&IsWP8Complete=true<br />
        <img src="getStatus.ashx?IsComplete=false&IsAndroidComplete=true&IsiOSComplete=false&IsWP8Complete=true" /><br />
    getStatus.ashx?IsComplete=false&IsAndroidComplete=true&IsiOSComplete=true&IsWP8Complete=false<br />
        <img src="getStatus.ashx?IsComplete=false&IsAndroidComplete=true&IsiOSComplete=true&IsWP8Complete=false" /><br />
    </div>
    </form>
</body>
</html>
