<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perdetail.aspx.cs" Inherits="Daiv_OA.Web.Perdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人便签</title>
    <script > window.onerror = function () { return true; };</script>
    <script type="text/javascript" language="javascript">
    function close()
    {
     parent.pw.close();
     }
    </script>

    <link href="../css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td >
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="便签内容：" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="titlename" runat="server" MaxLength="100" Width="250px" Rows="3"
                    TextMode="MultiLine" CssClass="bntj" Height="46px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Req" runat="server" ControlToValidate="titlename"
                    ErrorMessage="不为空"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
         &nbsp; <asp:Label ID="Label2" runat="server" Text="请选择日期：" Font-Bold="True"></asp:Label>
           <asp:DropDownList ID="DropY" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropY_SelectedIndexChanged" >
                                                    </asp:DropDownList>
                                                    年&nbsp;<asp:DropDownList ID="DropM" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropM_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    月&nbsp;<asp:DropDownList ID="DropD" runat="server">
                                                    </asp:DropDownList>
                                                    日&nbsp;
        </td>
         </tr>
        <tr>
            <td align="center">
                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="btnsubmit1" OnClick="Button1_Click" />
                &nbsp;<asp:Button ID="Button2" runat="server" Text="关闭" CausesValidation="False"
                    CssClass="btnsubmit1" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
