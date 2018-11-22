<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebDate.ascx.cs" Inherits="Daiv_OA.Web.webcontrol.WebDate" %>
    <script >        window.onerror = function () { return true; };</script>
<script src="../js/syspub.js" type="text/javascript"></script>
<script src="../js/popup.js" type="text/javascript"></script>
<link href="../css/style1.css" rel="stylesheet" type="text/css" />

<%--<script language="javascript" type="text/javascript">
    var pw=new PopWindow();
    setIntTop=300;
 setIntLeft=150;
    //传值
     var Additme=function(id)
      {
          var  strUrl="webcontrol/Perdetail.aspx?Ponid="+id;
          pw.iframe("个人便签",strUrl,false,380,110)
      };
    
    </script>--%>
    <div style="font-size: 12px">
 
     <div  style="background:url(../images/pic/main0hdbg.gif);text-align:right">
     <img alt="新建个人便签" src="../images/pic/004.gif" /> <a href="javascript:Additme('')">新建个人便签</a>&nbsp;&nbsp;
  </div >
   
    <div id="main1hd">
        <asp:Label ID="lblUserTitle" runat="server"></asp:Label>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td align="center" valign="top" colspan="2">
                    <asp:Label ID="lblCalendar" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" style="width: 200px;">
                </td>
                <td valign="top" align="center">
                    <asp:Label ID="lblList" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    <asp:HiddenField runat="server" ID="hidUserCode">
    </asp:HiddenField><asp:HiddenField runat="server" ID="hidUserName"></asp:HiddenField>
    <asp:HiddenField runat="server" ID="hidCurrDate">
    </asp:HiddenField>
   </div>
   
</div>

