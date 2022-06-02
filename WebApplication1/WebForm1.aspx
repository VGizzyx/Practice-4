<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Показать Заказчиков" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Скрыть Заказчиков" />
            <br />
            <br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" Visible="False">
            </asp:GridView>
            <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
