﻿using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        public SettingsViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            CreateMenuBar();
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        //动态集合
        private ObservableCollection<MenuBar> menuBars;

        private readonly IRegionManager regionManager;


        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set
            {
                menuBars = value;
                RaisePropertyChanged();//实现动态通知
            }
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;
            regionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(obj.NameSpace);
        }


        void CreateMenuBar()
        {
            menuBars.Add(new MenuBar() { Icon = "Palette", Title = "个性化", NameSpace = "SkinView" });
            menuBars.Add(new MenuBar() { Icon = "Cog", Title = "系统设置", NameSpace = "" });
            menuBars.Add(new MenuBar() { Icon = "Information", Title = "关于更多", NameSpace = "AboutView" });
        }
    }
}
