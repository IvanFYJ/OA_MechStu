<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addresslist.aspx.cs" Inherits="Daiv_OA.Web.addresslist" %>

<%@ Register src="webcontrol/address.ascx" tagname="address" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>公司通讯录</title><script type="text/javascript" language="javascript">window.onerror = function () { return true; };</script>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
    <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td  width="*">
                    
                    <uc1:address ID="address1" runat="server" />
                    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
