   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  5      5clr-namespace:MyToDo.ExtensionsMyToDo.Extensions  5
          MyToDo.Views.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      &localclr-namespace:MyToDo.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5	      *passclr-namespace:MyToDo.Extensions  5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      $	��600��5      $	��350��5      # 	 Prism.Services.Dialogs.Dialog    WindowStyle  5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value$	 600��6&   �� 5       � ��$	 350��6'   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@ WindowStartupLocation$ CenterScreen=�6C   5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��1.4* �6   �� 5      .+�5    
   �� $��50q�6   $��/Images/Login.png��6   '  !MaterialDesignThemes.Wpf.Snackbar  5#   
   -   5          Name$ LoginSnackbar��5$      $��2��5%       K� ZIndex$ 1��5&         MessageQueue 5'      4  .MaterialDesignThemes.Wpf.MessageQueueExtension  7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  5)   
   $��1��6    �� SelectedIndex 6*   �� *SelectedIndex+.@�5+      <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  .��5,      ]� $��15q�6   $��Center=�6(   .+�5-      �� $
��0,10q�5.      $	��Top=�5/      $��22(�50      $
��Bold"�51      $��欢迎使用��52      �� 54      $
��0,10q�55      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 请输入账号��56      $	��Top=�57      ��58      �� *	Account+G� 59      $
��0,10q�5:      $	 请输入密码��5;      $	��Top=�5=      *   $MyToDo.Extensions.PassWordExtensions
   PassWord
 5<      �� *
PassWord+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5>      (	   "MyToDo.Extensions.PassWordBehavior	  5?      5A      �� 5C      $��Login��5E      $��登录系统��5F       � Cursor$
 Hand��5G      $	��Top=�5H      ��5D      �� *ExecuteCommand+5H      ]� 5K      $
��0,10q�6    $��False��6.   .+�5L      �� $��注册账号��6$      Triggers 5M      +
  %Microsoft.Xaml.Behaviors.EventTrigger
  5N   "    
  	EventName$ MouseLeftButtonDown��61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5O   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ Go��6_      Command 6<   �� *ExecuteCommand+6_   5P   #   5R      �� 5S      $��Right=�6$   $��忘记密码��6;   5T      5U      5V        5Y      .��5Z      ]� $��15q�6   $��Center=�6(   .+�5[      �� $	��Top=�5\      $��22(�5]      $
��Bold"�5^      $��注册账号��5_      �� 5a      $
��0,10q�5b      $	 请输入账号��5c      $	��Top=�5d      ��5e      �� *RUserDto.Account+�� 5f      $
��0,10q�5g      $	 请输入用户名��5h      $ IBeam��5i      $	��Top=�5j      ��5k      �� *RUserDto.UserName+G� 5m      $
��0,10q�5n      $	 请输入密码��5o      $	��Top=�5q      
 5p      �� *RUserDto.PassWord+$ PropertyChanged=�$ TwoWay=� 5r      	  5s      5u      G� 5w      $
��0,10q�5x      $	 请再次输入密码��5y      $	��Top=�5{      
 5z      �� *RUserDto.NewPassWord+$ PropertyChanged=�$ TwoWay=� 5|      	  5}      5      �� 5�      $
��0,10q�5�      $��Register��5�      $��注册账号��5�      $	��Top=�5�      ��5�      �� *ExecuteCommand+5�      �� 5�      $
��0,10q�5�      $��Return��5�      $��返回登录��5�      $	��Top=�5�          MaterialDesignOutlinedButton#��[  5�      ��5�      �� *ExecuteCommand+5�      5�      5�      5�      5�      5�      