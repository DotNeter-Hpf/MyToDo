using MaterialDesignThemes.Wpf;
using MyToDo.Common;
using MyToDo.Services.IServices;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using MyToDo.Extensions;
using MyToDo.Shared.Models;

namespace MyToDo.ViewModels
{
    public class ToDoViewModel : NavigationViewModel
    {
        private readonly IDialogHostService dialogHost;

        public ToDoViewModel(IToDoService _service, IContainerProvider provider) : base(provider)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<ToDoDto>(Selected);
            DeleteCommand = new DelegateCommand<ToDoDto>(Delete);
            dialogHost = provider.Resolve<IDialogHostService>();
            this.service = _service;
        }


        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public DelegateCommand<ToDoDto> SelectedCommand { get; private set; }

        public DelegateCommand<ToDoDto> DeleteCommand { get; private set; }

        private readonly IToDoService service;


        private ObservableCollection<ToDoDto> toDoDtos;
        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }


        private bool isRightDrawerOpen;
        /// <summary>
        /// 右侧编辑窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }


        private ToDoDto currentDto;
        /// <summary>
        /// 编辑或新增时的对象
        /// </summary>
        public ToDoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }


        private string search;
        /// <summary>
        /// 搜索的条件
        /// </summary>
        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }


        private int selectedIndex;
        /// <summary>
        /// 状态下拉菜单的条件
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }


        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增": Add(); break;
                case "查询": GetDataListAsync(); break;
                case "保存": Save(); break;
            }
        }


        /// <summary>
        /// 添加待办
        /// </summary>
        private void Add()
        {
            //这里不new一下，新增的时候 CurrentDto是 null
            CurrentDto = new ToDoDto();
            IsRightDrawerOpen = true;
        }


        private async void Selected(ToDoDto obj)
        {
            try
            {
                //打开等待窗口
                UpdateLoading(true);
                var todoResult = await service.GetSinglesync(obj.Id);
                if (todoResult.status == ResultStatus.Success)
                    CurrentDto = todoResult.response;
                IsRightDrawerOpen = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //关闭等待窗口
                UpdateLoading(false);
            }
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        async void GetDataListAsync()
        {
            //打开等待窗口
            UpdateLoading(true);

            int? status = SelectedIndex == 0 ? null : SelectedIndex == 2 ? 1 : 0;

            var todoResult = await service.QueryPageAsync(new ToDoParameter()
            {
                PageIndex = 1,
                PageSize = 1000,
                Search = Search,
                Status = status
            });

            if (todoResult.status == ResultStatus.Success)
            {
                ToDoDtos.Clear();
                foreach (var item in todoResult.response.data)
                {
                    ToDoDtos.Add(item);
                }
            }
            //关闭等待窗口
            UpdateLoading(false);
        }

        /// <summary>
        /// 保存
        /// </summary>
        private async void Save()
        {
            if (string.IsNullOrEmpty(CurrentDto.Title) || string.IsNullOrEmpty(CurrentDto.Content))
                return;
            //打开等待窗口
            UpdateLoading(true);
            try
            {
                if (CurrentDto.Id > 0)//编辑
                {
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if (updateResult.status == ResultStatus.Success)
                    {
                        var todoModel = ToDoDtos.FirstOrDefault(x => x.Id == CurrentDto.Id);
                        if (todoModel != null)
                        {
                            todoModel.Title = CurrentDto.Title;
                            todoModel.Content = CurrentDto.Content;
                            todoModel.Status = CurrentDto.Status;
                        }
                    }
                    IsRightDrawerOpen = false;
                }
                else//新增
                {
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.status == ResultStatus.Success)
                    {
                        ToDoDtos.Add(addResult.response);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                //关闭等待窗口
                UpdateLoading(false);
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void Delete(ToDoDto obj)
        {
            try
            {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除待办事项:{obj.Title} ?");
                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;

                //打开等待窗口
                UpdateLoading(true);
                var deleteResult = await service.DeleteAsync(obj.Id);
                if (deleteResult.status == ResultStatus.Success)
                {
                    var model = ToDoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (model != null)
                        ToDoDtos.Remove(model);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //关闭等待窗口
                UpdateLoading(false);
            }
        }


        /// <summary>
        /// 导航完成前触发
        /// </summary>
        /// <param name="navigationContext">接收用户传递的参数</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            //点击首页已完成统计，传递参数 2 为已完成，这里接收一下并赋值
            if (navigationContext.Parameters.ContainsKey("Value"))
                SelectedIndex = navigationContext.Parameters.GetValue<int>("Value");
            else
                SelectedIndex = 0;

            GetDataListAsync();
        }
    }
}
