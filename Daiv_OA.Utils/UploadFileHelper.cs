
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Daiv_OA.Utils
{
    /// <summary>
    /// 文件上传帮助类
    /// </summary>
    /// <author>范永坚 2017-08-09</author>
    public class UploadFileHelper
    {
        private List<string> _fileExtAllowed = new List<string>(); // 允许文件类型
        private int _maxFileSize = 0; // 文件最大尺寸,单位:K
        private HttpPostedFileBase _file;
        public int MaxFileSize { get { return _maxFileSize; } set { _maxFileSize = value; } }


        public UploadFileHelper(HttpPostedFileBase postFile)
        {
            _file = postFile;
        }

        public void AddFileExt(string fileExt)
        {
            if ('.' != fileExt[0]) fileExt = "." + fileExt;
            _fileExtAllowed.Add(fileExt.ToLower());
        }


        /// <summary>
        /// 上传
        /// <param name="fileName">文件名</param>
        /// <param name="userName">用户名</param>
        /// </summary>
        /// <returns>返回保存文件后的文件名</returns>
        public string Upload(string fileName,string absFilePath )
        {
            if (_file != null)
            {
                string oldFileName = _file.FileName;//原文件名
                string extenstion = oldFileName.Substring(oldFileName.LastIndexOf(".") + 1);//后缀名 
                string newFileName = GetNewFileName(oldFileName);//生成新文件名
                //获取当前路径
                //string fileName = _file.FileName;
                //获取保存文件夹路径
                string nowDay = DateTime.Now.ToString("yyyy/MM").Replace("/", "").Substring(0, 6);
                string uploadPath = Path.Combine(HttpContext.Current.Server.MapPath("/"), absFilePath);
                if (!Directory.Exists(uploadPath + "/" + nowDay))
                {
                    Directory.CreateDirectory(uploadPath + "/" + nowDay);
                }
                string newFilePath = Path.Combine(uploadPath + "/" + nowDay, newFileName);
                _file.SaveAs(newFilePath);
                return newFileName;
            }

            return fileName;
        }

        /// <summary>
        /// 获取新的名称 比如:aa.jpg转化为aa(20090504).jpg
        /// </summary>
        /// <param name="fileName">文件名称[aa.jpg]</param>
        /// <returns>新的文件名称</returns>
        public static string GetNewFileName(string fileName,string userName = "")
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;

            //文件后缀名
            string extenstion = fileName.Substring(fileName.LastIndexOf(".") + 1);
            //string name = fileName.Substring(0, fileName.LastIndexOf(".")) + "(" + DateTime.Now.ToFileTime() + ")";
            //string newFileName = name + "." + extenstion;
            return userName + "_" + DateTime.Now.ToString("yyyy/MM/dd/HH/mm/ss").Replace("/", "") + "." + extenstion;
        }

    }
}