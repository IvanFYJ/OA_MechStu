<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="address.ascx.cs" Inherits="Daiv_OA.Web.webcontrol.address" %>
<link href="../css/style1.css" rel="stylesheet" type="text/css" />
    <script >        window.onerror = function () { return true; };</script>

<table style="width: 100%; text-align:center;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <div runat="server" id="cc"  class="TabTitle">
                <ul>
                    <li>公司通讯录</li>
                </ul>
            </div>
            <div runat="server" id="c" visible="false" class="TabTitle">
                <ul>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" >新增</asp:LinkButton></li>
                </ul>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                DataKeyNames="Id" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" 
                CssClass="dataTable" onrowdatabound="GridView1_RowDataBound" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" >
                <RowStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="编号" >
                        <HeaderStyle Width="60px" />
                        <ItemStyle Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="truename" HeaderText="真实姓名" />
                    <asp:BoundField DataField="phones" HeaderText="办公电话" />
                    <asp:BoundField DataField="telephone" HeaderText="手机号码" />
                    <asp:BoundField DataField="email" HeaderText="对外邮件" >
                        
                    </asp:BoundField>
                    <asp:BoundField DataField="qq" HeaderText="QQ号码" />
                    <asp:TemplateField HeaderText="所属职务">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="维护操作" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="编辑"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                OnClientClick="javascript:return confirm('确认删除吗?数据一旦删除将不可恢复！');">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
