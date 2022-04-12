using GZY.Quartz.MUI.BaseService;

namespace MyToDo.Api.QuartzJob
{
    public class TestJob_OneMinute : IJobService
    {
        public string ExecuteService(string parameter)
        {
            return "定时任务1已执行成功!";
        }
    }
}
