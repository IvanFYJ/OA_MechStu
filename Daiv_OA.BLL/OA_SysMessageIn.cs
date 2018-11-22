using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading;
namespace Daiv_OA.BLL
{
    public static class OA_SysMessageIn
    {

        /// <summary>
        /// 添加系统消息数据
        /// </summary>
        /// <param name="typeId">0 短信，1=通知公告，2=学习资料，3=邮件，4=未读任务，5=请求验收任务，6=任务验收结果通知，7=任务快到期限提醒，8=申请协调新时间提醒</param>
        /// <param name="recives">接收者</param>
        /// <param name="titles">内容主题</param>
        /// <param name="remark">详细内容</param>
        /// <param name="pages">链接到那个页面</param>
        public static void ADDsysMessage(int typeId, string recives, string titles, string remark, string pages)
        {

            COMDLL com = new COMDLL();
            DataTable dt = com.COM_Select("OA_SysMessage", "", "", "", "", 3);
            dt.Rows.Clear();
            DataRow dr = dt.NewRow();
            dr["typeId"] = typeId;
            dr["recives"] = recives;
            dr["titles"] = titles;
            dr["remark"] = remark;
            dr["pages"] = pages;
            dt.Rows.Add(dr);
            com.COM_Add(dt, "OA_SysMessage", "@typeId,@recives,@titles,@remark,@pages");
        }
        /// <summary>
        /// 得到消息框信息
        ///  0 短信，1=通知公告，2=学习资料，3=邮件，4=未读任务，5=请求验收任务，6=任务验收结果通知，7=任务快到期限提醒，8=申请协调新时间提醒
        /// </summary>
        /// <param name="uid">当前登录编号</param>
        /// <returns></returns>
        public static DataTable getsysMessage(string uid)
        {
            //0 短信，1=通知公告，2=学习资料，3=邮件，4=未读任务，5=请求验收任务，6=任务验收结果通知，7=任务快到期限提醒，8=申请协调新时间提醒
            COMDLL com = new COMDLL();
            DataTable table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "4", uid);
            if (table.Rows.Count != 0)
                return table;
            else
                table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "7", uid);
                if (table.Rows.Count != 0)
                    return table;
                else
                    table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "1", uid);
                    if (table.Rows.Count != 0)
                        return table;
                    else
                        table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "8", uid);
                        if (table.Rows.Count != 0)
                            return table;
                        else
                            table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "5", uid);
                            if (table.Rows.Count != 0)
                                return table;
                            else
                                table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "0", uid);
                                if (table.Rows.Count != 0)
                                    return table;
                                else
                                    table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "6", uid);
                                    if (table.Rows.Count != 0)
                                        return table;
                                    else
                                    table = com.COM_Proc_Sel2("Pc_SeltopSysMessage", "2", uid);
                        return table;
        
        }
        /// <summary>
        /// 更新消息框状态
        ///  
        /// </summary>
        ///
        /// <param name="recives">更新接收者</param>
        /// <param name="i">条件 0表示更新接收者，其他表示关闭此消息</param>
        /// 
        public static void UPsysMessage(string Id, string recives, int i)
        {
            COMDLL com = new COMDLL();
            com.COM_Proc_DelorUp_3("Pc_UPSysMessage", Id, recives, Convert.ToString(i));
        }

     
        /// <summary>
        /// 得到登陆用户编号
        /// </summary>
        /// <returns></returns>
        public static string userid()
       {
           string uid="-1";
           if (Daiv_OA.Utils.Cookie.GetValue("oa_user") != null)
               uid=Daiv_OA.Utils.Cookie.GetValue("oa_user", "id").ToString();
           return uid;
       
       }
        
           
    }
}
