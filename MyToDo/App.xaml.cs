using DryIoc;
using MyToDo.Common;
using MyToDo.Services;
using MyToDo.Services.IServices;
using MyToDo.ViewModels;
using MyToDo.ViewModels.Dialogs;
using MyToDo.Views;
using MyToDo.Views.Dialogs;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace MyToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    //都是退出的意思
                    //Application.Current.Shutdown(); 
                    Environment.Exit(0);
                    return;
                }
            });

            var service = App.Current.MainWindow.DataContext as IConfigureService;
            if (service != null)
                service.Configure();
            base.OnInitialized();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //依赖容器中注册,用来做主菜单导航的
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();

            //设置中的菜单导航
            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();

            //关闭弹窗
            containerRegistry.RegisterForNavigation<MsgView, MsgViewModel>();

            //注册弹窗 
            containerRegistry.RegisterForNavigation<AddToDoView, AddToDoViewModel>();
            containerRegistry.RegisterForNavigation<AddMemoView, AddMemoViewModel>();


            //给构造函数的参数设置一个默认名称
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            //给webUrl注册一个默认的服务地址
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:3002/", serviceKey: "webUrl");


            //依赖注入服务  这里注入完之后，在对应的ViewModel中的构造函数中使用
            containerRegistry.Register<IToDoService, ToDoService>();
            containerRegistry.Register<IMemoService, MemoService>();
            containerRegistry.Register<IDialogHostService, DialogHostService>();
            containerRegistry.Register<ILoginService, LoginService>();

            //注册登录页面的弹窗
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
        }


        /// <summary>
        /// 整个首页隐藏，重新回到登录页面，登录成功后刷新数据
        /// </summary>
        public static void LoginOut(IContainerProvider provider)
        {
            App.Current.MainWindow.Hide();

            var dialog = provider.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    //都是退出的意思
                    //Application.Current.Shutdown(); 
                    Environment.Exit(0);
                    return;
                }
            });

           Current.MainWindow.Show();
        }
    }
}
