using MyToDo.Common;
using MyToDo.Extensions;
using MyToDo.Services.IServices;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyToDo.ViewModels
{
    public class MemoViewModel : NavigationViewModel
    {
        private readonly IDialogHostService dialogHost;

        public MemoViewModel(IMemoService _service, IContainerProvider provider) : base(provider)
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<MemoDto>(Selected);
            DeleteCommand = new DelegateCommand<MemoDto>(Delete);
            service = _service;
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public DelegateCommand<MemoDto> SelectedCommand { get; private set; }

        public DelegateCommand<MemoDto> DeleteCommand { get; private set; }

        private readonly IMemoService service;


        private ObservableCollection<MemoDto> memoDtos;
        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
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


        private MemoDto currentDto;
        /// <summary>
        /// 编辑或新增时的对象
        /// </summary>
        public MemoDto CurrentDto
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
        /// 添加备忘录
        /// </summary>
        private void Add()
        {
            //这里不new一下，新增的时候 CurrentDto是 null
            CurrentDto = new MemoDto();
            IsRightDrawerOpen = true;
        }


        private async void Selected(MemoDto obj)
        {
            try
            {
                //打开等待窗口
                UpdateLoading(true);
                var todoResult = await service.GetSinglesync(obj.Id);
                if (todoResult.status == 200)
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

            int? status = selectedIndex == 0 ? null : selectedIndex == 2 ? 1 : 0;

            var todoResult = await service.QueryPage(new QueryParameter()
            {
                PageIndex = 1,
                PageSize = 1000,
                Search = Search
            });

            if (todoResult.status == 200)
            {
                MemoDtos.Clear();
                foreach (var item in todoResult.response.data)
                {
                    MemoDtos.Add(item);
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
                    if (updateResult.status == 200)
                    {
                        var todoModel = MemoDtos.FirstOrDefault(x => x.Id == CurrentDto.Id);
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
                    if (addResult.status == 200)
                    {
                        MemoDtos.Add(addResult.response);
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

        private async void Delete(MemoDto obj)
        {
            try
            {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除备忘录:{obj.Title} ?");
                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;

                //打开等待窗口
                UpdateLoading(true);

                var deleteResult = await service.DeleteAsync(obj.Id);
                if (deleteResult.status == 200)
                {
                    var model = MemoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (model != null)
                        MemoDtos.Remove(model);
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



        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetDataListAsync();
        }
    }
}
