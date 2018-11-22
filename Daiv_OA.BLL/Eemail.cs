using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
namespace Daiv_OA.BLL
{
  public static  class Eemail
    {

     public  static string GetFormatPop3(string email)
        {
            string aa = "";
            if(email!="")
            {
                string [] str=email.ToString().Split("@".ToCharArray());
                switch (str[1].ToString())
            {
                case "jumbotcms.net":
                    aa = "mail.jumbotcms.net";
                    break;
                case "sina.com":
                    aa = "pop.sina.com";
                    break;
                case "sina.cn":
                    aa = "pop.sina.cn";
                    break;
                case "163.com":
                    aa = "pop.163.com";
                    break;
                case "yeah.net":
                    aa = "pop.yeah.net";
                    break;
                case "qq.com":
                    aa = "pop.qq.com";
                    break;
                case "126.com":
                    aa = "pop.126.com";
                    break;
            }}
            return aa;

        }
   
    }
}
