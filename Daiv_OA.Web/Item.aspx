<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="Daiv_OA.Web.Item" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>项目类别</title><script type="text/javascript" language="javascript">                           window.onerror = function () { return true; };</script>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <script src="js/popup.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
    var pw=new PopWindow();
    setIntTop=300;
 setIntLeft=150;

    //传值
     var Additme=function(id)
      {
          var  strUrl="ItemDetail.aspx?fid="+id;
          pw.iframe("添加子栏目",strUrl,false,380,80)
      };
      var Upitem=function(id)
      {
          var  strUrl="ItemDetail.aspx?id="+id;
          pw.iframe("修改子栏目",strUrl,false,380,80)
      };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            
             <tr>
          <td height="20" bgcolor="#f6f9fe" style="border-bottom: 1px solid #f3f6fb; border-top: 1px solid #FFFFFF;">
              &nbsp;&nbsp;<font style="font-weight: bold; color: #006666; font-size: large">新建或修改</font>
              <asp:DropDownList ID="typeid" runat="server">
                  <asp:ListItem Value="0">在线打分</asp:ListItem>
                  <asp:ListItem Value="1">项目测试汇报</asp:ListItem>
              </asp:DropDownList>
               &nbsp;大类主题名称：
            <asp:TextBox ID="titlename" runat="server" MaxLength="200" Width="280px" 
                  Height="20px" ></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvTitle" runat="server" 
                  ControlToValidate="titlename" ErrorMessage="*不能为空！"></asp:RequiredFieldValidator>
              <asp:Button ID="Button1" runat="server" CssClass="btnsubmit1" 
                  onclick="Button1_Click" Text="提交" />

                  
              <asp:Label ID="ok" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
              <asp:Label ID="txtid" runat="server" Visible="False"></asp:Label>
           </td>
            </tr>
            <tr>
             <td width="99%" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <div class="envthp">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" valign="top" style="padding-top: 2px; padding-left: 6px; padding-right: 6px;
                                                padding- tom: 2px;">
                                                <asp:GridView ID="gvlist0" runat="server" CssClass="dataTable" Width="100%" 
                                                    AutoGenerateColumns="False" DataKeyNames="Id" 
                                                    onrowdatabound="gvlist0_RowDataBound" onrowdeleting="gvlist0_RowDeleting" 
                                                    onrowediting="gvlist0_RowEditing">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="编号" Visible="False" />
                                                        <asp:TemplateField HeaderText="项目类别">
                                                         
                                                            <ItemTemplate>
                                                              <%# getbookname(Eval("typeid")) %>
                                                            </ItemTemplate>
                                                            <ItemStyle Font-Bold="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="大主题名称">
                                                            <ItemTemplate>
                                                             <a href="javascript:Additme('<%# Eval("Id")%>')" title="添加子栏目" ><%# Eval("titlename")%></a>   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="子栏目列表" ShowHeader="False">
                    <ItemTemplate>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView2_RowDeleting"
                              BorderStyle="None"
                            BorderWidth="1px" CellPadding="4" GridLines="Horizontal" Width="100%" 
                            DataKeyNames="Id" OnRowDataBound="GridView2_RowDataBound" 
                            ShowHeader="False">
                           
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="编号" Visible="false">
                                    <HeaderStyle BackColor="White" ForeColor="#666666" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="子栏目名称">
                                    <ItemTemplate>
                                       <a href="javascript:Upitem('<%# Eval("Id")%>')" title="修改子栏目" ><%# Eval("titlename")%></a>
                                    </ItemTemplate>
                                   
                                    <HeaderStyle BackColor="White" ForeColor="#666666" HorizontalAlign="Left" />
                                </asp:TemplateField>
                               
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                                    <HeaderStyle BackColor="White" ForeColor="Silver" HorizontalAlign="Left" />
                                    <ItemStyle Width="52px" />
                                </asp:CommandField>
                            </Columns>
                          
                        </asp:GridView>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="center" />
                                                          
                    </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="操作维护" ShowHeader="False">
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                                                    CommandName="Update" Text="更新"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                    CommandName="Cancel" Text="取消"></asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                                    CommandName="Edit" Text="修改大主题"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                                    CommandName="Delete" OnClientClick="javascript:return confirm('注意：删除大主题时将一并删除子主题，且数据将不可恢复！您确认删除该记录吗?');">删除大主题</asp:LinkButton> 
                                                            </ItemTemplate>
                                                           
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView> 
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
    <p>
     
</body>
</html>
