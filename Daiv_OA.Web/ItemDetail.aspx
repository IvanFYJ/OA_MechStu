<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemDetail.aspx.cs" Inherits="Daiv_OA.Web.ItemDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加子栏目</title>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">        window.onerror = function () { return true; };</script>
    <script type="text/javascript" language="javascript">
    function close()
    {
     parent.pw.close();
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                   &nbsp; <asp:Label ID="Label1" runat="server" Text="子栏目名称：" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="titlename" runat="server" MaxLength="150" Width="222px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Req" runat="server" 
                        ControlToValidate="titlename" ErrorMessage="不为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
            <td style="height:20px;"></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="提交" CssClass="btnsubmit1" 
                        onclick="Button1_Click" />
                    &nbsp;<asp:Button ID="Button2" runat="server" Text="返回" 
                        CausesValidation="False" CssClass="btnsubmit1" onclick="Button2_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
