using MaterialDesignThemes.Wpf;
using MyToDo.Common;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels.Dialogs
{
    public class AddToDoViewModel : BindableBase, IDialogHostAware
    {
        public AddToDoViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }


        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }


        private ToDoDto model;
        /// <summary>
        /// 新增或编辑的实体
        /// </summary>
        public ToDoDto Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }



        public void OnDialogOpend(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Value"))
            {
                Model = parameters.GetValue<ToDoDto>("Value");
            }
            else
            {
                Model = new ToDoDto();
            }
        }


        /// <summary>
        /// 取消
        /// </summary>
        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));//取消返回No，告诉操作结束
        }


        /// <summary>
        /// 确定
        /// </summary>
        private void Save()
        {
            if (string.IsNullOrEmpty(Model.Title) || string.IsNullOrEmpty(Model.Content)) return;

            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                //确定时，返回Ok,并将实体返回
                DialogParameters param = new();
                param.Add("Value", Model);
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }
        }
    }
}
