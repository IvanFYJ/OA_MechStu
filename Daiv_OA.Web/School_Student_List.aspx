﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="School_Student_List.aspx.cs" Inherits="Daiv_OA.Web.School_Student_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>全校学生列表</title>
    <script type="text/javascript" language="javascript">window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script type="text/javascript" src="_libs/jquery-3.1.1.js"></script>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" name="cid" value="<%=classId %>" />
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="240">
                            <h1> <span id="pPageSpan" style="cursor:pointer" title="点击退回到班级管理" >班级管理</span>-学生管理</h1>
                            
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                         
                        <%--  <td><a href="role.aspx?roleid=1">部门管理</a></td>
                          <td><a href="role.aspx?roleid=0">角色管理</a></td>--%>
                            <td><a href="Student_List.aspx?cid=<%=classId%>">学生列表</a></td>
                            <td class="active">全校学生列表</td>
                            <td><a href="Student_Add.aspx?cid=<%=classId%>">添加学生</a></td>
                            <td><a href="Student_Import.aspx?cid=<%=classId%>">导入学生</a></td>
                            <td><a href="Student_FlowInfo.aspx?cid=<%=classId%>">学生费用列表</a></td>
<%--                            <td><a href="User_Add2.aspx">添加主管</a></td>
                            <td><a href="User_Add3.aspx">添加副主管</a></td>
                            <td><a href="User_Add4.aspx">添加员工</a></td>--%>
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
                                                padding- tom: 2px;">
                                                <asp:Repeater ID="user_repeater" runat="server"   OnItemDataBound="user_repeater_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table width="100%" cellpadding="2" cellspacing="0" class="dataTable" align="center">
                                                            <tr class="dataTableHead" align="center">
                                                                <td style="width: 60px">
                                                                    序号
                                                                </td>
                                                                <td width="*">
                                                                    年级名称
                                                                </td>
                                                                <td width="*">
                                                                    班级名称
                                                                </td>
                                                                <td width="width: 200px">
                                                                    学生学号
                                                                </td>
                                                                <td width="width: 200px">
                                                                    学生名称
                                                                </td>
                                                             <%--   <td style="width: 130px">
                                                                    职位名称
                                                                </td>--%>
                                                                <td style="width: 190px">
                                                                    操作
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <%#Container.ItemIndex + 1 %>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("GradeName")%>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Gname")%>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Snumber")%>
                                                            </td>
                                                            <td align="center">
                                                                <%#Eval("Sname")%>
                                                            </td>
                                                            <%--<td align="center">
                                                                <%# Eval("Position")%>
                                                            </td>--%>
                                                            <td align="center">
                                                                <a href="Student_Edit.aspx?id=<%#Eval("Sid") %>&cid=<%=classId%>">修改信息</a> | 
                                                                <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnCommand="lbDel_Click" CommandArgument='<%#Eval("Sid") %>'
                                                                    OnClientClick="javascript:return confirm('删除学生后，与其相关的任何信息都将删除，确定要删除吗？');"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <SeparatorTemplate><%--这是分隔线模板--%>
                                                    <tr>
                                                    <td colspan="8">
                                                    <hr style="border-top:1pt;"/>
                                                    </td>
                                                    </tr>
                                                    </SeparatorTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td colspan="8" style="font-size: 12pt; color: #0099ff; background-color: #e6feda;">共<asp:Label ID="lblpc" runat="server" Text="Label"></asp:Label>页 当前为第
                                                                <asp:Label ID="lblp" runat="server" Text="Label"></asp:Label>页
                                                                <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>
                                                                <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>
                                                                <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>
                                                                <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>
                                                                跳至第
                                                                <asp:DropDownList ID="ddlp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                                                                </asp:DropDownList>页
                                                            </td>
                                                        </tr>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
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
    $(function () {
        //退回显示班级
        $("#pPageSpan").on('click', function () {
            //iframe层-父子操作
            var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
            parent.layer.close(index);
            parent.classShow();
        });
    })
</script>

</body>
</html>
