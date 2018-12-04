using System;
using System.Data;
using System.Collections.Generic;
using Daiv_OA.Entity;
namespace Daiv_OA.BLL
{
    /// <summary>
    /// ҵ���߼���User ��ժҪ˵����
    /// </summary>
    public class UserBLL
    {
        private readonly DAL.UserDAL dal = new DAL.UserDAL();
        public UserBLL()
        { }
        #region  ��Ա����

        /// <summary>
        /// ����Cookies
        /// </summary>
        /// <param name="user">�û�����</param>
        /// <param name="userhAddress">�û���¼��ַ</param>
        /// <param name="iExpires">�������־û�ʱ��</param>
        public void SetUserCookies(UserEntity user,string userhAddress,int iExpires)
        {

            //����Cookies
            System.Collections.Specialized.NameValueCollection myCol = new System.Collections.Specialized.NameValueCollection();
            myCol.Add("id", user.Uid.ToString());
            myCol.Add("name", user.Uname);
            myCol.Add("ip", userhAddress);
            new BLL.UserBLL().UpdateTime(user.Uid);
            int pid = user.Pid;
            myCol.Add("Powerid", pid.ToString());
            Daiv_OA.Utils.Cookie.SetObj("oa_user", 60 * 60 * 15 * iExpires, myCol, "", "/");
        }

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Uid)
        {
            return dal.Exists(Uid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Entity.UserEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Entity.UserEntity model)
        {
            dal.Update(model);
        }

        public bool UpdateTime(int Uid)
        {
            return dal.UpdateTime(Uid);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int Uid)
        {

            dal.Delete(Uid);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Entity.UserEntity GetEntity(int Uid)
        {

            return dal.GetEntity(Uid);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Daiv_OA.Entity.UserEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Daiv_OA.Entity.UserEntity> modelList = new List<Daiv_OA.Entity.UserEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Daiv_OA.Entity.UserEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    //model = new Daiv_OA.Entity.UserEntity();
                    //if (ds.Tables[0].Rows[n]["Uid"].ToString() != "")
                    //{
                    //    model.Uid = int.Parse(ds.Tables[0].Rows[n]["Uid"].ToString());
                    //}
                    //if (ds.Tables[0].Rows[n]["Pid"].ToString() != "")
                    //{
                    //    model.Pid = int.Parse(ds.Tables[0].Rows[n]["Pid"].ToString());
                    //}
                    //model.Uname = ds.Tables[0].Rows[n]["Uname"].ToString();
                    //model.Upwd = ds.Tables[0].Rows[n]["Upwd"].ToString();
                    //model.Uipaddress = ds.Tables[0].Rows[n]["Uipaddress"].ToString();
                    //model.Setting = ds.Tables[0].Rows[n]["Setting"].ToString();
                    //modelList.Add(model);

                    modelList.Add(dal.ConvertModel(ds.Tables[0], n));
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public string Existslongin(string uname, string upwd)
        {
            return dal.Existslongin(uname, upwd);
        }

        /// <summary>
        /// ��ȡ��ɫ
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public Entity.PowerEntity Getpomodel(string sql)
        {
            return dal.Getpomodel(sql);
        }

        /// <summary>
        /// ��ȡUID
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public Entity.UserEntity Getuname(string sql)
        {
            return dal.Getuname(sql);
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getall(string sql)
        {
            return dal.Getall(sql);
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        /// <param name="kls_uid"></param>
        /// <param name="kls_pwd"></param>
        /// <param name="kls_num"></param>
        /// <returns></returns>
        public DataSet Getsta(string sql)
        {
            return dal.Getsta(sql);
        }
        #endregion  ��Ա����
    }
}

