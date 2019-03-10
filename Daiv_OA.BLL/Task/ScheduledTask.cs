using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace Daiv_OA.BLL.Task
{
    public class ScheduledTask
    {
        private static readonly ScheduledTask _ScheduledTask = null;
        private System.Threading.Timer UpdateTimer = null;
        private int Interval = 5 * 60000;//间隔时间，这里设置为15分钟
        private int _IsRunning;//上一个时间间隔触发的任务是否运行完成
        private string appPath = "";

        static ScheduledTask()
        {
            _ScheduledTask = new ScheduledTask();
        }

        public static ScheduledTask Instance()
        {
            return _ScheduledTask;
        }

        /// <summary>
        /// timer启动
        /// </summary>
        public void Start()
        {
            if (UpdateTimer == null)
            {
                UpdateTimer = new System.Threading.Timer(new TimerCallback(UpdateTimerCallback), null, Interval, Interval);
            }
            this.appPath = HttpRuntime.AppDomainAppPath;
        }

        /// <summary>
        /// 时钟callback事件
        /// </summary>
        /// <param name="sender"></param>
        private void UpdateTimerCallback(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    //要处理后台任务
                    //1.任务一：更新学生年级
                    new StudentBLL().UpdateStudentGrade(appPath);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }

        /// <summary>
        ///timer停止
        /// </summary>
        public void Stop()
        {
            if (UpdateTimer != null)
            {
                UpdateTimer.Dispose();
                UpdateTimer = null;
            }
        }
    }
}
