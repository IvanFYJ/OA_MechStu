<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scorlist2.aspx.cs" Inherits="Daiv_OA.Web.Scorlist2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打分详细信息</title><script type="text/javascript" language="javascript">                             window.onerror = function () { return true; };</script>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="99%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width:85%">
                <asp:GridView ID="gvlist" runat="server" Width="100%" AutoGenerateColumns="False"
                    DataKeyNames="Id" OnRowDataBound="gvlist_RowDataBound" BackColor="White" BorderColor="White"
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="0" GridLines="Horizontal"
                    ShowFooter="True">
                    <FooterStyle BackColor="#ECECEC" ForeColor="#0066FF" Height="25" Font-Bold="True"
                        HorizontalAlign="Left" />
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
                        <asp:TemplateField HeaderText=" 考核具体指标(模块名称)    (好=20 较好=15 中=10 较差=5 差=0)  备注信息">
                            <ItemTemplate>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                    BorderWidth="1px" CellPadding="3" DataKeyNames="Id" Width="500px" ShowHeader="False"
                                    BackColor="White" BorderColor="#CCCCCC">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <RowStyle ForeColor="#000066" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="编号" Visible="false">
                                            <HeaderStyle BackColor="White" ForeColor="#666666" HorizontalAlign="Left" />
                                            <ItemStyle Width="10px" />
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
                                        <asp:TemplateField HeaderText="打分">
                                            <ItemTemplate>
                                                &nbsp; &nbsp;
                                                <asp:Label ID="lbtxt" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="自我备注">
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
                            <HeaderStyle HorizontalAlign="Left" BackColor="#ECECEC" Font-Bold="True" ForeColor="#333333"
                                Width="501px" />
                            <ItemStyle HorizontalAlign="Left" Width="501px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="合计数据">
                            <ItemTemplate>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="labnum" runat="server" Font-Bold="True"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="60px" BackColor="#ECECEC" ForeColor="#333333" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle Font-Bold="True" ForeColor="#CCCCCC" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Height="25px" ForeColor="#E7E7FF" />
                </asp:GridView>
            </td>
            <td style="width:15%">
                <img alt="取消返回" src="images/btn_cancel.gif" style="cursor: pointer;" onclick="location.href='Scorelist.aspx'" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
