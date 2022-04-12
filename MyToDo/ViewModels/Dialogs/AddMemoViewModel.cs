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
    public class AddMemoViewModel : BindableBase, IDialogHostAware
    {
        public AddMemoViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }


        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }


        private MemoDto model;
        /// <summary>
        /// 新增或编辑的实体
        /// </summary>
        public MemoDto Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }


        public void OnDialogOpend(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Value"))
            {
                Model = parameters.GetValue<MemoDto>("Value");
            }
            else
            {
                Model = new MemoDto();
            }
        }


        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
        }

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
