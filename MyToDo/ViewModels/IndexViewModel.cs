using MyToDo.Common;
using MyToDo.Common.Models;
using MyToDo.Extensions;
using MyToDo.Services.IServices;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyToDo.ViewModels
{
    public class IndexViewModel : NavigationViewModel
    {
        private readonly IToDoService toDoService;
        private readonly IMemoService memoService;
        private readonly IDialogHostService dialog;
        private readonly IRegionManager regionManager;

        public IndexViewModel(IDialogHostService _dialog, IContainerProvider provider) : base(provider)
        {
            Title = $"你好，{AppSession.UserName} {DateTime.Now.GetDateTimeFormats('D')[1]}";

            CreateTaskBars();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            toDoService = provider.Resolve<IToDoService>();
            memoService = provider.Resolve<IMemoService>();
            regionManager = provider.Resolve<IRegionManager>();
            dialog = _dialog;
            EditToDoCommand = new DelegateCommand<ToDoDto>(AddToDo);
            EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            TodoStatusSuccess = new DelegateCommand<ToDoDto>(Complted);
            NavigateCommand = new DelegateCommand<TaskBar>(Navigate);
        }



        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<ToDoDto> EditToDoCommand { get; private set; }
        public DelegateCommand<MemoDto> EditMemoCommand { get; private set; }
        public DelegateCommand<ToDoDto> TodoStatusSuccess { get; private set; }
        public DelegateCommand<TaskBar> NavigateCommand { get; private set; }

        #region 属性

        private ObservableCollection<TaskBar> taskBars;
        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }


        private SummaryDto summary;
        /// <summary>
        /// 首页统计
        /// </summary>
        public SummaryDto Summary
        {
            get { return summary; }
            set { summary = value; RaisePropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        #endregion

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增待办": AddToDo(null); break;
                case "新增备忘录": AddMemo(null); break;
            }
        }

        /// <summary>
        /// 添加或编辑待办事项
        /// </summary>
        async void AddToDo(ToDoDto model)
        {
            DialogParameters param = new();
            if (model != null)
                param.Add("Value", model);

            var dialogResult = await dialog.ShowDialog("AddToDoView", param);
            if (dialogResult.Result == ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);

                    var todo = dialogResult.Parameters.GetValue<ToDoDto>("Value");
                    if (todo.Id > 0)
                    {
                        var updateResult = await toDoService.UpdateAsync(todo);
                        if (updateResult.status == ResultStatus.Success)
                        {
                            var todoModel = Summary.TodoList.FirstOrDefault(t => t.Id.Equals(todo.Id));

                            if (todoModel != null)
                            {
                                todoModel.Title = todo.Title;
                                todoModel.Content = todo.Content;
                            }

                            //如果编辑改变了状态，统计也需要变更；并且只保留一个Snackbar的消息提示
                            if (todo.Status == 1)
                                Complted(todo);
                            else
                                aggregator.SendMessage("编辑成功!");
                        }
                    }
                    else
                    {
                        var addResult = await toDoService.AddAsync(todo);
                        if (addResult.status == ResultStatus.Success)
                        {
                            Summary.TodoList.Add(addResult.response);

                            //如果新增已完成数据，则完成数量+=1
                            if (addResult.response.Status == 1)
                                Summary.CompletedCount += 1;
                            Summary.Sum += 1;
                            Summary.CompletedRadio = (Summary.CompletedCount / (double)Summary.Sum).ToString("0%");
                            Refresh();
                            aggregator.SendMessage("添加成功!");
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    UpdateLoading(false);
                }

            }
        }


        /// <summary>
        /// 添加或编辑备忘录
        /// </summary>
        async void AddMemo(MemoDto model)
        {
            DialogParameters param = new();
            if (model != null)
                param.Add("Value", model);

            var dialogResult = await dialog.ShowDialog("AddMemoView", param);
            if (dialogResult.Result == ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);

                    var memo = dialogResult.Parameters.GetValue<MemoDto>("Value");
                    if (memo.Id > 0)
                    {
                        var updateResult = await memoService.UpdateAsync(memo);
                        if (updateResult.status == ResultStatus.Success)
                        {
                            var memoModel = Summary.MemoList.FirstOrDefault(t => t.Id.Equals(memo.Id));
                            if (memoModel != null)
                            {
                                memoModel.Title = memo.Title;
                                memoModel.Content = memo.Content;
                            }
                            aggregator.SendMessage("编辑成功!");
                        }
                    }
                    else
                    {
                        var addResult = await memoService.AddAsync(memo);
                        if (addResult.status == ResultStatus.Success)
                        {

                            Summary.MemoList.Add(addResult.response);
                            Summary.MemoCount += 1;
                            Summary.CompletedRadio = (Summary.CompletedCount / (double)Summary.Sum).ToString("0%");
                            Refresh();
                            aggregator.SendMessage("添加成功!");
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    UpdateLoading(false);
                }
            }
        }


        /// <summary>
        /// 完成待办事项
        /// </summary>
        /// <param name="obj"></param>
        private async void Complted(ToDoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var updateResult = await toDoService.UpdateAsync(obj);
                if (updateResult.status == ResultStatus.Success)
                {
                    var todoModel = Summary.TodoList.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (todoModel != null)
                    {
                        Summary.TodoList.Remove(todoModel);
                        Summary.CompletedCount += 1;
                        Summary.CompletedRadio = (Summary.CompletedCount / (double)Summary.Sum).ToString("0%");
                        Refresh();
                    }
                    aggregator.SendMessage("编辑成功!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        void CreateTaskBars()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            TaskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "汇总", Color = "#0097FF", Target = "ToDoView" });
            TaskBars.Add(new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Color = "#12B33A", Target = "ToDoView" });
            TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成率", Color = "#00B4DF", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Color = "#FFA000", Target = "MemoView" });
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var summaryResult = await toDoService.SummaryAsync();
            if (summaryResult.status == ResultStatus.Success)
            {
                Summary = summaryResult.response;
                Refresh();
            }
        }

        /// <summary>
        /// 刷新四个统计项的数据
        /// </summary>
        void Refresh()
        {
            TaskBars[0].Content = Summary.Sum.ToString();
            TaskBars[1].Content = Summary.CompletedCount.ToString();
            TaskBars[2].Content = Summary.CompletedRadio;
            TaskBars[3].Content = Summary.MemoCount.ToString();
        }


        private void Navigate(TaskBar obj)
        {
            if (string.IsNullOrEmpty(obj.Target)) return;

            NavigationParameters param = new();
            if (obj.Title == "已完成")
                param.Add("Value", 2);

            //跳转到对应页面
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Target, param);
        }
    }
}
