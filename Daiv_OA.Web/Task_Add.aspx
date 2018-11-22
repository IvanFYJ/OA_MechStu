<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task_Add.aspx.cs" Inherits="Daiv_OA.Web.Task_Add" %>

<%@ Register Src="webcontrol/workter.ascx" TagName="workter" TagPrefix="uc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.QuickStart" Assembly="Telerik.QuickStart" %>
<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload.Net2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分配新任务</title><script type="text/javascript" language="javascript">                            window.onerror = function () { return true; };</script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link href="css/style1.css" rel="stylesheet" type="text/css" />

    <script src="_libs/My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript" src="_libs/jquery-1.2.6.js"></script>

    <script type="text/javascript" src="js/global.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 7px;">
        <table class="tabs_head" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td width="140">
                    <h1>
                        工作分配</h1>
                </td>
                <td class="actions" width="*">
                    <table cellspacing="0" cellpadding="0" border="0" align="right">
                        <tr>
                            <td>
                                <a href="Task_List.aspx">员工任务分配</a>
                            </td>
                            <td class="active">
                                分配新任务
                            </td>
                            <td>
                                <a href="TastCheck.aspx?tast=45678">验收任务</a>
                            </td>
                            <td>
                                <a href="TastCheck.aspx?tast=9">拒收任务</a>
                            </td>
                            <td>
                                <a href="TastCheck.aspx?tast=3">任务档案</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="right">
        <div class="cntre">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="width: 100%; padding: 10px;">
                        <div class="jsatp">
                            <div id="myTab1_Content0" class="cntut">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">任务主题：</span>
                                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="20" Width="220px" Height="24px"
                                                CssClass="ipt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server"
                                                    ControlToValidate="txtTitle" ErrorMessage="*不能为空！" Font-Bold="False"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">执行人员工作：</span>
                                            <asp:CheckBoxList ID="ddlWorker" runat="server" RepeatDirection="Horizontal" ValidationGroup="aa"
                                                Height="19px">
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">任务类型：</span>
                                            <asp:DropDownList ID="classse" runat="server">
                                                <asp:ListItem Value="普通任务">普通任务</asp:ListItem>
                                                <asp:ListItem Value="重要任务">重要任务</asp:ListItem>
                                                <asp:ListItem Value="紧急任务">紧急任务</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">工作开始时间：</span>
                                            <asp:TextBox ID="txtBegintime" runat="server" Width="150px" Height="24px" CssClass="ipt"
                                                onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,maxDate:'#F{$dp.$D(\'txtEndtime\')}'})"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">预计完成时间：</span>
                                            <asp:TextBox ID="txtEndtime" runat="server" Width="150px" Height="24px" CssClass="ipt"
                                                onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',readOnly:true,minDate:'#F{$dp.$D(\'txtBegintime\')}'})"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">附件：</span>
                                            <table border="0" cellpadding="0" cellspacing="0" width="700">
                                                <tr>
                                                    <td>
                                                        <asp:FileUpload ID="FileUpload1" Height="21px" runat="server" Width="236px" />
                                                        <asp:Button ID="btnSave" runat="server" Text="上传" OnClick="btnSave_Click" Height="23px" Width="42px" CausesValidation="False" /><asp:Label 
                                                            ID="message" runat="server" Text="检测完毕，抱歉，您需上传合法文件" Visible="False" Font-Bold="True"></asp:Label>只支持.doc .rar .zip格式文件
                                                            <radU:RadProgressManager ID="Radprogressmanager1" Width="350px" runat="server"
                                                                Height="05px" Font-Bold="False" ForeColor="#006666" />
                                                        <radU:RadProgressArea ID="progressArea1" Width="350px" runat="server" 
                                                            Font-Bold="False" ForeColor="#33CCFF">
                                                        </radU:RadProgressArea>
                                                        <asp:GridView ID="Repeater1" runat="server" AutoGenerateColumns="False" 
                                                            DataKeyNames="Id" Width="350px" CellPadding="4" ForeColor="#333333" 
                                                            GridLines="None" onrowdeleting="Repeater1_RowDeleting" ShowHeader="False">
                                                            <RowStyle BackColor="#EFF3FB" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Id" HeaderText="编号" Visible="False" />
                                                                <asp:TemplateField HeaderText="附件名称">
                                                                    <ItemTemplate>
                                                                    &nbsp; <font style="font-weight: 100; color: #000000;"><%# getfile(Eval("names")) %></font>
                                                                     <font style="font-weight: normal; color: #CCCCCC;"> <%#Eval("side")%></font>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="320px" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" 
                                                                    DeleteImageUrl="~/images/X.gif" ButtonType="Image">
                                                                    <ItemStyle Width="20px" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#2461BF" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    
                                                     </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">任务内容：</span>
                                            <asp:TextBox ID="txt" runat="server" Height="257px" Width="645px" Rows="10" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvTitle0" runat="server"
                                                    ControlToValidate="txt" ErrorMessage="*不能为空！" Font-Bold="False"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
                                            <span class="bvjto styp">任务要求：</span>
                                            <asp:TextBox ID="questext" runat="server" Height="80px" Width="645px" 
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cntre1">
                            <ul>
                                <li>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btn_submit.gif"
                                        OnClick="ImageButton1_Click" /></li>
                                <li>
                                    <img alt="取消返回" src="images/btn_cancel.gif" style="cursor: pointer;" onclick="location.href='Task_List.aspx'" /></li>
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
