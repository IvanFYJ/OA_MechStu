using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiv_OA.Web
{
    public partial class GradeUpdateConfig_List : Daiv_OA.UI.BasicPage
    {
        protected int schId;
        protected void Page_Load(object sender, EventArgs e)
        {
            User_Load("gradeconfig-add");
            //学校ID
            string shid = Request["shid"];
            if (!string.IsNullOrEmpty(shid))
            {
                try
                {
                    schId = Convert.ToInt32(shid);
                }
                catch (Exception)
                {
                }
            }
            if (!this.IsPostBack)
            {
            }
        }



        /// <summary>
        /// 获取已经配置的所有数据
        /// </summary>
        /// <returns></returns>
        public string GetAllConfigStr()
        {
            List<object> data = new List<object>();
            List<Entity.GradeUpdateConfigEntity> list = new BLL.GradeUpdateConfigBLL().GetModelList(" IsDeleted = 0");
            if(list != null)
            {
                var d = list.Select(s => new { ID=s.ID,CurrGradeID=s.CurrGradeID,UpGradeID= s.UpGradeID }).ToList();
                return Newtonsoft.Json.JsonConvert.SerializeObject(d);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        //添加
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) {
            string cfidStr = Request["configId"];
            string cfcurrCStr = Request["currClassGid"];
            string cffurCStr = Request["furClassGid"];
           BLL.GradeUpdateConfigBLL gucBll =  new BLL.GradeUpdateConfigBLL();
            if (string.IsNullOrEmpty(cfidStr) || string.IsNullOrEmpty(cfcurrCStr) || string.IsNullOrEmpty(cffurCStr))
            {

                FinalMessage("班级无效!", "GradeUpdateConfig_List.aspx" , 0);
                return;
            }
            string[] idArr = cfidStr.Split(',');
            string[] currCArr = cfcurrCStr.Split(',');
            string[] furCArr = cffurCStr.Split(',');
            if(idArr.Length != currCArr.Length || currCArr.Length != furCArr.Length)
            {
                FinalMessage("班级选择数量不一致!", "GradeUpdateConfig_List.aspx", 0);
                return;
            }
            //验证数据
            for (int i = 0; i < currCArr.Length; i++)
            {
                if(currCArr[i] == furCArr[i])
                {
                    FinalMessage("选择了相同的班级!", "GradeUpdateConfig_List.aspx", 0);
                    return;
                }
            }
            //保存数据
            List<Entity.GradeUpdateConfigEntity> list = gucBll.GetModelList(" IsDeleted = 0");
            List<int> exsistIdList = new List<int>();
            Entity.GradeUpdateConfigEntity entity = null;
            for (int i = 0; i < idArr.Length; i++)
            {
                int id =Convert.ToInt32( idArr[i]);
                entity = list.Where(s => s.ID == id).FirstOrDefault();
                if(id != 0 && entity != null)
                {
                    entity.ModifyDate = DateTime.Now;
                    entity.ModifyUserID = UserId;
                    entity.CurrGradeID =Convert.ToInt32( currCArr[i]);
                    entity.UpGradeID = Convert.ToInt32(furCArr[i]);
                    gucBll.Update(entity);
                    exsistIdList.Add(entity.ID);
                }
                if(0 == id)
                {
                    entity = new Entity.GradeUpdateConfigEntity();
                    entity.CreateDate = DateTime.Now;
                    entity.CreateUserID = UserId;
                    entity.ModifyDate = DateTime.Now;
                    entity.ModifyUserID = 0;
                    entity.CurrGradeID = Convert.ToInt32(currCArr[i]);
                    entity.UpGradeID = Convert.ToInt32(furCArr[i]);
                    entity.IsDeleted = 0;
                    gucBll.Add(entity);
                }
            }
            //更新用户删除的数据
            for (int i = 0; i < list.Count; i++)
            {
                int id = list[i].ID;
                if (!exsistIdList.Contains(id))
                {
                    list[i].IsDeleted = 1;
                    list[i].DeleteDate = DateTime.Now;
                    list[i].DeleteUserID = UserId;
                    gucBll.Update(list[i]);
                }
            }

        }


    }
}