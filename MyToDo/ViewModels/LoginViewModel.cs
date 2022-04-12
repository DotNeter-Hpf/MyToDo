using MyToDo.Services.IServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyToDo.Shared.Dtos;
using Prism.Events;
using MyToDo.Extensions;
using MyToDo.Common;
using MyToDo.Shared.Models;

namespace MyToDo.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private readonly ILoginService service;
        private readonly IEventAggregator aggregator;

        public LoginViewModel(ILoginService _loginService, IEventAggregator _aggregator)
        {
            RUserDto = new();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.service = _loginService;
            this.aggregator = _aggregator;
        }

        public DelegateCommand<string> ExecuteCommand { get; set; }


        public string Title { get; set; } = "ToDo";


        private string account;
        /// <summary>
        /// 登录名
        /// </summary>
        public string Account
        {
            get { return account; }
            set { account = value; RaisePropertyChanged(); }
        }


        private string passWord;
        /// <summary>
        /// 登录密码
        /// </summary>
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }


        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        private RegisterUserDto rUserDto;

        public RegisterUserDto RUserDto
        {
            get { return rUserDto; }
            set { rUserDto = value; RaisePropertyChanged(); }
        }




        public event Action<IDialogResult> RequestClose;


        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }


        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login": Login(); break;
                case "LoginOut": LoginOut(); break;
                case "Go": SelectedIndex = 1; break;//跳转注册界面
                case "Return": SelectedIndex = 0; break;//返回登录界面
                case "Register": Register(); break;//注册账号
            }
        }


        private async void Register()
        {
            #region 信息校验
            if (string.IsNullOrEmpty(RUserDto.Account))
            {
                aggregator.SendMessage("账号不能为空", "Login");
                return;
            }

            if (string.IsNullOrEmpty(RUserDto.UserName))
            {
                aggregator.SendMessage("用户名不能为空", "Login");
                return;
            }

            if (string.IsNullOrEmpty(RUserDto.PassWord))
            {
                aggregator.SendMessage("密码不能为空", "Login");
                return;
            }

            if (string.IsNullOrEmpty(RUserDto.NewPassWord))
            {
                aggregator.SendMessage("确认密码不能为空", "Login");
                return;
            }

            if (RUserDto.PassWord != RUserDto.NewPassWord)
            {
                //两次密码验证失败提示...
                aggregator.SendMessage("两次密码输入不一致", "Login");
                return;
            }
            #endregion

            var registerResult = await service.RegisterAsync(new UserDto()
            {
                Account = RUserDto.Account,
                UserName = RUserDto.UserName,
                PassWord = RUserDto.PassWord
            });

            if (registerResult != null && registerResult.status == ResultStatus.Success)
            {
                //注册成功
                SelectedIndex = 0;
                aggregator.SendMessage("注册成功", "Login");
                return;
            }
            //注册失败提示...
            aggregator.SendMessage($"注册失败 {registerResult.msg}", "Login");
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(PassWord))
                return;

            var loginResult = await service.LoginAsync(new UserDto()
            {
                Account = Account,
                PassWord = PassWord
            });

            if (loginResult != null && loginResult.status == ResultStatus.Success)
            {
                AppSession.UserName = loginResult.response.UserName;
                //登陆成功
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                return;
            }

            //登陆失败提示...
            aggregator.SendMessage($"登陆失败 {loginResult.msg}", "Login");
        }


        private void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }
    }
}
