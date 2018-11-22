<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TastCheck.aspx.cs" Inherits="Daiv_OA.Web.TastCheck" %>

<%@ Register Assembly="Sisans.AspNetPager" Namespace="Sisans.AspNetPager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>任务处理中心</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

    <link href="style/global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        任务处理中心</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td>
                                <a href="TastCheck.aspx?tast=3">任务档案</a>
                            </td>
                            <td>
                                <a href="Task_Add.aspx">分配新任务</a>
                            </td>
                            <td>
                                <a href="TastCheck.aspx?tast=45678">验收任务</a>
                            </td>
                            <td>
                                <a href="TastCheck.aspx?tast=9">拒收任务</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="padding-left: 10px;">
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;">
                &nbsp;
                <asp:Label ID="Label5" runat="server" Text="主题名称"></asp:Label>
                &nbsp;<asp:TextBox ID="Tasktitle" runat="server" Width="220px"></asp:TextBox>
                &nbsp;<asp:DropDownList ID="classse" runat="server">
                    <asp:ListItem Value="普通任务">普通任务</asp:ListItem>
                    <asp:ListItem Value="重要任务">重要任务</asp:ListItem>
                    <asp:ListItem Value="紧急任务">紧急任务</asp:ListItem>
                    <asp:ListItem Selected="True" Value="0">==不限定==</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnSelect" runat="server" CssClass="btnsubmit1" Text="快速查找"
                    OnClick="btnSelect_Click" />
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
                            <td height="154" valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr runat="server" id="qs" visible="false">
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                   <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                             &nbsp;&nbsp; <span class="bvjtostyp">任务主题：</span>
                                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="20" Width="220px" 
                                                Height="24px" CssClass="ipt" Enabled="False"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp; 执行任务者：<asp:Label ID="Uidtxt" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                                    <tr>
                                                    <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                            &nbsp;
                                                            <span class="bvjto styp">&nbsp;工作任务状态：</span>
                                                            <asp:DropDownList ID="Workprogress" runat="server" Width="130px">
                                                                <asp:ListItem Value="3">验收已完成</asp:ListItem>
                                                                <asp:ListItem Value="4">验收未完成</asp:ListItem>
                                                                <asp:ListItem Value="8">重新分配时间</asp:ListItem>
                                                            </asp:DropDownList>
                                                    
                                                            <asp:Label ID="txtid" runat="server" Visible="False"></asp:Label>
                                                    
                                                    </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                            &nbsp;
                                                            <span class="bvjto styp">&nbsp;工作开始时间：</span>
                                                            <asp:TextBox ID="txtBegintime" runat="server" Width="150px" Height="24px" CssClass="ipt"
                                                                onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,maxDate:'#F{$dp.$D(\'txtEndtime\')}'})"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                            <span class="bvjto styp">&nbsp;&nbsp; 预计完成时间：</span>
                                                            <asp:TextBox ID="txtEndtime" runat="server" Width="150px" Height="24px" CssClass="ipt"
                                                                onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,minDate:'#F{$dp.$D(\'txtBegintime\')}'})"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                                           <asp:Label ID="ts" runat="server" 
                                                                Width="200px"></asp:Label>
&nbsp;<asp:Button ID="Button1" runat="server" Text="保存并执行" CssClass="btnsubmit1" onclick="Button1_Click" />
                                                        &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" CssClass="dataTable"
                                                    Width="100%" DataKeyNames="Tlid" OnRowDataBound="gvlsit_RowDataBound" OnRowEditing="gvlist_RowEditing">
                                                    <Columns>
                                                        <asp:BoundField DataField="Tlid" HeaderText="编号">
                                                            <HeaderStyle Width="50px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="接收者">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Uname") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="60px" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="任务主题">
                                                            <ItemTemplate>
                                                             <a href="javascript:void(0);" onclick="OA.Popup.show('Task_Show.aspx?id=<%#Eval("Tlid") %>',-1,-1,true)">
                                                                    <%# Eval("Tasktitle") %></a>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="200px" />
                                                            <ItemStyle Width="240px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="计划完成时间">
                                                            <ItemTemplate>
                                                                <%#Eval("Plantime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="120px" />
                                                            <ItemStyle Width="120px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="任务状态">
                                                            <ItemTemplate>
                                                                <%#str(Eval("Workprogress").ToString()) %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="80px" />
                                                            <ItemStyle Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="提交时间">
                                                            <ItemTemplate>
                                                                <%#Eval("Worktime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="120px" />
                                                            <ItemStyle Width="120px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="classse" HeaderText="任务类型">
                                                            <HeaderStyle Width="60px" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="提交说明">
                                                            <ItemTemplate>
                                                                <%# Daiv_OA.Utils.Strings.Left(Eval("remark").ToString(), 20)%>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="200px" />
                                                            <ItemStyle Width="200px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Manager" HeaderText="发布者">
                                                            <HeaderStyle Width="60px" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:BoundField>
                                                        <asp:CommandField HeaderText="操作维护" ShowEditButton="True" EditText="执行验收">
                                                            <HeaderStyle Width="80px" />
                                                            <ItemStyle Width="80px" />
                                                        </asp:CommandField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td align="center">
                                                <cc1:AspNetPager currentpagebuttonclass="cpb" ID="AspNetPager1" runat="server" AlwaysShow="True"
                                                    FirstPageText="首页" Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="22"
                                                    PrevPageText="上一页" ShowBoxThreshold="11" TextAfterInputBox="" TextBeforeInputBox=""
                                                    UrlPaging="False" ShowInputBox="Always" SubmitButtonText="转到此页" OnPageChanged="AspNetPager1_PageChanged1"
                                                    Visible="True" CssClass="anpager" Width="99%" Height="19px">
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

    <script type="text/javascript"> 
	 
    </script>

</body>
</html>
