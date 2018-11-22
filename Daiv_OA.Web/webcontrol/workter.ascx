<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="workter.ascx.cs" Inherits="Daiv_OA.Web.webcontrol.workter" %>
<table style="width: 280px; height:360px; background-color:#ececec " border="0" cellpadding="0" cellspacing="1">
    <tr align="center" style="height:25px; background-color:#ffffff">
        <td style="width:120px;" align="center">
            部门
            <asp:Label ID="txtid" runat="server" Visible="False"></asp:Label>
        </td>
        <td style="width:55px;" align="center">
            <asp:Label ID="txtuid" runat="server" Visible="False" Width="5px"></asp:Label>
        </td>
        <td>
            人员列表
        </td>
    </tr>
    <tr style="background-color:#ffffff" >
        <td style="vertical-align: top; width:120px" >
            <asp:TreeView ID="TreeView1" runat="server" 
                onselectednodechanged="TreeView1_SelectedNodeChanged1">
            </asp:TreeView>
        </td>
        <td style="width:55px;" align="center">
            <asp:Button ID="Btninsert" CommandName="tianjia" oncommand="Btninsert_Command" 
                runat="server" Text="添加" Height="22px"
                Width="45px" />
            <br />
            <br />
            <asp:Button ID="Btnyichu" CommandName="yichu" oncommand="Btninsert_Command" 
                runat="server" Text="移除" Height="22px"
                Width="45px" />
        </td>
        <td style="vertical-align: top">
            <asp:ListBox ID="ListBox1" runat="server" Width="95%" Height="305px"></asp:ListBox>
        </td>
    </tr>
    <tr align="center" style="background-color:#ffffff">
        <td colspan="3">
            <asp:Button ID="Button3" runat="server" Height="22px" OnClick="Button3_Click" Text="保 存"
                Width="51px" />
        &nbsp;
            <asp:Button ID="Button4" runat="server" Height="22px" OnClick="Button4_Click" Text="清 空"
                Width="51px" />
        </td>
    </tr>
</table>
