<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scorelist.aspx.cs" Inherits="Daiv_OA.Web.Scorelist" %>

<%@ Register Assembly="Sisans.AspNetPager" Namespace="Sisans.AspNetPager" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线评分</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr runat="server" id="dafen" visible="true">
                <td style="padding-left: 10px;">
                    &nbsp;<asp:CheckBox ID="Isdelete" runat="server" Text="是否启用打分" Font-Bold="True" />
                    &nbsp;
                    <asp:Label ID="Label5" runat="server" ForeColor="#0066FF" Text="用户最终分公式=="></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="#0066FF" Text="用户自评分"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Width="34px" TabIndex="6">0</asp:TextBox>
                    %
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" ForeColor="#0066FF" Text="＋部门主管"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Width="34px" TabIndex="1">0</asp:TextBox>
                    %
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" ForeColor="#0066FF" Text="＋总主管"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" Width="34px" TabIndex="4">0</asp:TextBox>
                    %
                    <asp:Label ID="Label4" runat="server" Font-Bold="False" ForeColor="#0066FF" Text="＋最高管理者"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" Width="34px" TabIndex="5">0</asp:TextBox>
                    %&nbsp;
                    <asp:Button ID="Button1" CssClass="btnsubmit1" runat="server" Text="保存设置" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px;">
                    &nbsp;人员:
                    <asp:DropDownList ID="ddlUname" runat="server" Width="100px">
                    </asp:DropDownList>
                    &nbsp;<asp:DropDownList ID="DropDyeah" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;<asp:DropDownList ID="DropDmouth" runat="server">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="btnSelect" runat="server" CssClass="btnsubmit1" Text="查询" OnClick="btnSelect_Click"
                        TabIndex="7" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td width="99%" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" align="center">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:GridView ID="gvlist0" runat="server" CssClass="dataTable" Width="100%" AutoGenerateColumns="False"
                                                    OnRowDataBound="gvlist0_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="得分序号">
                                                            <HeaderStyle Width="60px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="姓名">
                                                            <ItemTemplate>
                                                                <a title="查看详细" href="Scorlist2.aspx?uid=<%#Eval("uid").ToString()%>&&kq=<%#Eval("statstime").ToString() %>">
                                                                    <%#getstrobj(Eval("uid").ToString(),1) %></a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="岗位">
                                                            <ItemTemplate>
                                                                <%# Eval("Position")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="部门">
                                                            <ItemTemplate>
                                                                <%#getstrobj(Eval("Did").ToString(),2)%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Scustom" HeaderText="自评总分" />
                                                        <asp:BoundField DataField="Sendscore" HeaderText="得分">
                                                            <ItemStyle Font-Bold="True" ForeColor="#0099FF" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Isdelete" HeaderText="得分排名" Visible="false" />
                                                        <asp:BoundField DataField="Sonescore" HeaderText="部门主管打分" />
                                                        <asp:BoundField DataField="Stwoscore" HeaderText="主管打分" />
                                                        <asp:BoundField DataField="Sthreescore" HeaderText="管理员打分" />
                                                        <asp:BoundField DataField="statstime" HeaderText="统计周期">
                                                            <HeaderStyle Width="60px" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                                <cc1:AspNetPager currentpagebuttonclass="cpb" ID="AspNetPager1" runat="server" AlwaysShow="True"
                                                    FirstPageText="首页" Font-Size="12px" LastPageText="尾页" NextPageText="下一页" PageSize="12"
                                                    PrevPageText="上一页" ShowBoxThreshold="11" TextAfterInputBox="" TextBeforeInputBox=""
                                                    UrlPaging="False" ShowInputBox="Always" SubmitButtonText="转到此页" OnPageChanged="AspNetPager1_PageChanged1"
                                                    Visible="True" CssClass="anpager" Width="99%" Height="19px">
                                                </cc1:AspNetPager>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td align="center">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr style="width: 100%" align="center">
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:GridView ID="gvlist" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    DataKeyNames="Id" OnRowDataBound="gvlist_RowDataBound" BackColor="White" BorderColor="White"
                                                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="Horizontal">
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <RowStyle Height="20px" BackColor="White" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="编号">
                                                            <HeaderStyle BackColor="#ECECEC" Font-Bold="True" ForeColor="Black" />
                                                            <ItemStyle Width="55px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="titlename" HeaderText="考核模块">
                                                            <HeaderStyle BackColor="#ECECEC" Font-Bold="True" ForeColor="#333333" />
                                                            <ItemStyle Width="200px" HorizontalAlign="Center" ForeColor="Blue" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText=" 考核具体指标(模块名称)    选择得分参考参数(好=20 较好=15 中=10 较差=5 差=0) 自我备注(选择“好”或“差”须填写备注) ">
                                                            <ItemTemplate>
                                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                                    BorderWidth="1px" CellPadding="3" DataKeyNames="Id" OnRowDataBound="GridView2_RowDataBound"
                                                                    Width="670px" ShowHeader="False" BackColor="White" BorderColor="#CCCCCC">
                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                    <RowStyle ForeColor="#000066" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="id" HeaderText="编号" Visible="false">
                                                                            <HeaderStyle BackColor="White" ForeColor="#666666" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="60px" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="考核具体指标">
                                                                            <ItemTemplate>
                                                                                &nbsp;
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("titlename") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("titlename") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle Width="220px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="得分标准|好=20 较好=15 中=10 较差=5 差=0|">
                                                                            <ItemTemplate>
                                                                                <asp:RadioButtonList ID="Radio" runat="server" RepeatDirection="Horizontal" ValidationGroup="cc"
                                                                                    Font-Bold="False" Font-Size="Small">
                                                                                    <asp:ListItem Value="20">好</asp:ListItem>
                                                                                    <asp:ListItem Value="15">较好</asp:ListItem>
                                                                                    <asp:ListItem Value="10">中</asp:ListItem>
                                                                                    <asp:ListItem Value="5">较差</asp:ListItem>
                                                                                    <asp:ListItem Value="0">差</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle Width="220px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="自评分">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="自我备注(选择较好或较差须文字说明)">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtremark" runat="server" MaxLength="20" Rows="2" Text='' TextMode="MultiLine"
                                                                                    Width="190px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                                </asp:GridView>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" BackColor="#ECECEC" Font-Bold="True" ForeColor="#333333" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                                                    <SelectedRowStyle Font-Bold="True" ForeColor="#CCCCCC" />
                                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Height="25px" ForeColor="#E7E7FF" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td align="center">
                                                <asp:Button ID="Button3" runat="server" Text="提交打分" CssClass="btnsubmit1" OnClick="Button3_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
