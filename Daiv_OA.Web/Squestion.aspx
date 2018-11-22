<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Squestion.aspx.cs" Inherits="Daiv_OA.Web.Squestion" %>

<%@ Register Assembly="Sisans.AspNetPager" Namespace="Sisans.AspNetPager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>测试问题列表</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .anpager .cpb
        {
            background: #1F3A87 none repeat scroll 0 0;
            border: 1px solid #CCCCCC;
            color: #FFFFFF;
            font-weight: bold;
            margin: 5px 4px 0 0;
            padding: 4px 5px 0;
        }
        .anpager a
        {
            background: #FFFFFF none repeat scroll 0 0;
            border: 1px solid #CCCCCC;
            color: #1F3A87;
            margin: 5px 4px 0 0;
            padding: 4px 5px 0;
            text-decoration: none;
        }
        .anpager a:hover
        {
            background: #1F3A87 none repeat scroll 0 0;
            border: 1px solid #1F3A87;
            color: #FFFFFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="padding-left: 10px;">
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;">
                &nbsp;项目名称:
                <asp:DropDownList ID="dropitem" runat="server" Width="220px">
                </asp:DropDownList>
                &nbsp; 问题处理等级:&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="0">==不限==</asp:ListItem>
                    <asp:ListItem Value="1">一般</asp:ListItem>
                    <asp:ListItem Value="2">紧急</asp:ListItem>
                    <asp:ListItem Value="3">十分紧急</asp:ListItem>
                </asp:DropDownList>
                &nbsp;问题状态：&nbsp;<asp:DropDownList ID="rescuedp" runat="server">
                    <asp:ListItem Value="0">===不限===</asp:ListItem>
                    <asp:ListItem>复测中</asp:ListItem>
                    <asp:ListItem>问题已处理</asp:ListItem>
                    <asp:ListItem>还存在问题</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;<asp:Button ID="btnSelect" runat="server" CssClass="btnsubmit1" Text="快速查询" 
                    OnClick="btnSelect_Click" />
            &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btnsubmit1" 
                    onclick="Button1_Click" Text="发布问题" />
            </td>
        </tr>
    </table>
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
                            <td valign="top">
                                <div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="24" align="center" valign="top" style="padding-top: 2px; padding-left: 6px;
                                                padding-right: 6px; padding- tom: 2px;">
                                                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" CssClass="dataTable"
                                                    Width="100%" DataKeyNames="Id" onrowdatabound="gvlist_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="问题序号" />
                                                        <asp:TemplateField HeaderText="测试项目名称">
                                                           
                                                            <ItemTemplate>
                                                               <%# getstrobj(Eval("Itemid"),1) %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="220px" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="问题主题名称">
                                                           
                                                            <ItemTemplate>
                                                              <a href="Squestiondetail.aspx?sques=<%# Eval("Id") %>" title="查看问题详细信息"><%# Eval("titels")%></a>  
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="220px" />
                                                            <ItemStyle Width="220px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="quuser" HeaderText="发布者" />
                                                        <asp:TemplateField HeaderText="处理等级">
                                                            <ItemTemplate>
                                                         <%# getstrobj(Eval("class"), 0)%>    
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="touser" HeaderText="问题处理者" >
                                                            <HeaderStyle Width="70px" />
                                                            <ItemStyle Width="70px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="已解决日期">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("uptime") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="110px" />
                                                            <ItemStyle Width="110px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="问题状态">
                                                            <ItemTemplate>
                                                              <%#getstr(Eval("rescue").ToString())%>
                                                            </ItemTemplate>
                                                           
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="处理问题">
                                                            <ItemTemplate>
                                                               <%#gets(Eval("rescue").ToString(), Eval("Id").ToString())%>
                                                      </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <cc1:AspNetPager currentpagebuttonclass="cpb" ID="AspNetPager1" runat="server" AlwaysShow="True"
                                                    FirstPageText="首页" Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="30"
                                                    PrevPageText="上一页" ShowBoxThreshold="11" TextAfterInputBox="" TextBeforeInputBox=""
                                                    UrlPaging="False" ShowInputBox="Always" SubmitButtonText="转到此页" OnPageChanged="AspNetPager1_PageChanged1"
                                                    Visible="True" CssClass="anpager" Width="99%" Height="17px">
                                                </cc1:AspNetPager>
                                            </td>
                                        </tr>
                                    </table>
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
</body>
</html>
