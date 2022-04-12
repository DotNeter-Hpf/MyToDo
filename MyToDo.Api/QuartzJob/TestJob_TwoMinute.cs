using GZY.Quartz.MUI.BaseService;
using System.Threading;

namespace MyToDo.Api.QuartzJob
{
    public class TestJob_TwoMinute : IJobService
    {
        public string ExecuteService(string parameter)
        {
            var cs = "";
            for (int i = 0; i < 100000; i++)
            {
                if (i == 99999)
                {
                    cs = "定时任务2已执行成功99999!";
                    break;
                }
            }
            Thread.Sleep(3000);
            return cs;
        }
    }
}
