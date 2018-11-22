using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Daiv_OA.BLL
{ 
    /// <summary>
        /// 定义定时器
        /// </summary>
   public class CoutomTimr
    {
            //System.Threading.Timer 仍不能简写为 Timer，因为会和 System.Web.UI.Timer 混淆。
            /// <param name="i">时间间隔，微秒</param>
            public  void TimerGO(Int32 i)
            {
              //System.Threading.TimerCallback timerDelegate = new System.Threading.TimerCallback (Working);
              //System.Threading.AutoResetEvent autoEvent = new System.Threading.AutoResetEvent(true);
              //System.Threading.Timer workingTimer = new System.Threading.Timer(timerDelegate, autoEvent, 0, i);//0表示及时启动，i时间间隔
              //autoEvent.WaitOne(5000,false);//阻断下一线程
              //workingTimer.Dispose();//释放
            }
            static void Working(object stateInfo)
            {
               // AutoResetEvent autoEvent = (AutoResetEvent)stateInfo; //没有使用，这里写出来仅说明参数 stateInfo 的用途
               //定义执行的方法，因为是程序的开始线程，所以不关联cookie ,session值的操作
                
            }
       
  
    }
}
