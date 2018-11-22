using System;
using System.Data;
using System.Web;
using Daiv_OA.Utils;
namespace Daiv_OA.Web.AutoTask
{
    public partial class _index : Daiv_OA.UI.BasicPage
    {
        private string _operType = string.Empty;
        private string _response = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._operType = q("oper");
            switch (this._operType)
            {
                case "LockSummarize":
                    LockSummarize();
                    break;
                default:
                    DefaultResponse();
                    break;
            }
            Response.Write(this._response);
        }
        private void DefaultResponse()
        {
            this._response = "未知操作";
        }
        /// <summary>
        /// 锁定非本周的工作总结
        /// </summary>
        private void LockSummarize()
        {
            string _password = q("password");
            if (_password != System.Configuration.ConfigurationManager.AppSettings["AutoTask:Password"])
            {
                this._response = "密码错误";
                return;
            }
            int _doCount = new Daiv_OA.BLL.SummarizeBLL().LockSummarize();
            if (_doCount > 0)
                this._response = "有" + _doCount + "个工作总结被锁定";
            else
                this._response = "没有工作总结被锁定";
        }
    }
}