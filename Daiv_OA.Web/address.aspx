<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="Daiv_OA.Web.address" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加通讯录</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript">window.onerror = function () { return true; };</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="cntre">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div class="TabTitle">
                                <ul id="myTab1">
                                    <li>通讯录信息</li>
                                </ul>
                            </div>
                            <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">真实姓名：</span>
                                            <asp:TextBox ID="truename" runat="server" Width="220px" Height="24px" 
                                                CssClass="ipt" MaxLength="50"></asp:TextBox>
                                            &nbsp;<asp:Label ID="Label1" runat="server" Text="*"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="truename"
                                                ErrorMessage="必填选项"></asp:RequiredFieldValidator>
                                            （采用实名制，汉字）
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">办公电话：</span>
                                            <asp:TextBox ID="phones" runat="server" Width="220px" Height="24px" 
                                                CssClass="ipt" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">手机号码：</span><span id="sp1"></span>
                                            <asp:TextBox ID="telephone" runat="server" Width="220px" Height="24px" 
                                                CssClass="ipt" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">对外邮件：</span>
                                            <asp:TextBox ID="email" runat="server" CssClass="ipt" Height="24px" 
                                                MaxLength="50" Width="220px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">QQ号码：</span>
                                            <asp:TextBox ID="qq" runat="server" Width="220px" Height="24px" CssClass="ipt" 
                                                MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">所属职务：</span><span id="Span1"></span>
                                            <asp:DropDownList ID="DropDid" runat="server" Width="120px">
                                            </asp:DropDownList>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul><li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif" OnClick="ImageButton1_Click" /></li>
                            <li>
                                        <img alt="取消返回" src="images/btn_cancel.gif" style="cursor:pointer;" onclick="location.href='addresslist.aspx'" /></li>
                                        </ul>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
<script type="text/javascript"> 
	 
</script>

</body>
</html>
