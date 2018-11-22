<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="role.aspx.cs" Inherits="Daiv_OA.Web.role" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>人员列表</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        人员管理</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td class="<%=sty(1) %>">
                                <a href="role.aspx?roleid=1">部门列表</a>
                            </td>
                            <td class="<%=sty(0) %>">
                                <a href="role.aspx?roleid=0">角色列表</a>
                            </td>
                            <td><a href="User_List.aspx">人员列表</a></td>
                            <td>
                                <a href="User_Add1.aspx">添加管理员</a>
                            </td>
                            <td>
                                <a href="User_Add2.aspx">添加主管</a>
                            </td>
                            <td>
                                <a href="User_Add3.aspx">添加部门主管</a>
                            </td>
                            <td>
                                <a href="User_Add4.aspx">添加员工</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right1">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="0%" valign="top">
                    <h1>
                        <img src="images/ht16_03.gif" /></h1>
                </td>
                <td width="99%" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="154" valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;" align="center">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                    CssClass="dataTable" 
                                                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                                                    onrowdatabound="GridView1_RowDataBound" onrowdeleting="GridView1_RowDeleting" 
                                                    onrowupdating="GridView1_RowUpdating" DataKeyNames="Did" 
                                                    onrowediting="GridView1_RowEditing">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="编号">
                                                            <ItemTemplate>
                                                           
                                                               <%#names(Eval("Did")) %>
                                                            </ItemTemplate>
                                                          
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="部门名称">
                                                            <ItemTemplate>
                                                               <%#names(Eval("DName"))%> 
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Height="17px" 
                                                                    Text='<%#names(Eval("DName"))%>' Width="156px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="Requi" runat="server" 
                                                                    ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                           
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="操作维护" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                                    CommandName="Edit" Text="修改"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                    CommandName="Delete" OnClientClick="javascript:return confirm('警示：删除部门后将影响到用户！您还确认删除该记录吗?');">删除</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                                                    CommandName="Update" Text="更新"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                    CommandName="Cancel" Text="取消"></asp:LinkButton>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" 
                                                    CssClass="dataTable" 
                                                    onrowcancelingedit="gvlist_RowCancelingEdit" 
                                                    onrowdatabound="gvlist_RowDataBound" onrowdeleting="gvlist_RowDeleting" 
                                                    onrowupdating="gvlist_RowUpdating" DataKeyNames="Pid" 
                                                    onrowediting="gvlist_RowEditing">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="编号">
                                                            <ItemTemplate>
                                                           
                                                               <%#names(Eval("Pid")) %>
                                                            </ItemTemplate>
                                                          
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="角色名称">
                                                            <ItemTemplate>
                                                               <%#names(Eval("PName"))%> 
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Height="17px" 
                                                                    Text='<%#names(Eval("PName"))%>' Width="156px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="Requir" runat="server" 
                                                                    ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                           
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="操作维护" ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                                    CommandName="Edit" Text="修改"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                    CommandName="Delete" OnClientClick="javascript:return confirm('警示：删除角色后将影响到用户！您还确认删除该记录吗?');">删除</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                                                    CommandName="Update" Text="更新"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                    CommandName="Cancel" Text="取消"></asp:LinkButton>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;" align="center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="right2">
                                    <ul>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="0%" valign="top">
                    <h2>
                        <img src="images/ht28_03.gif" /></h2>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript"> 
	 
    </script>

</body>
</html>
