   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  5clr-namespace:MyToDo.ExtensionsMyToDo.Extensions      MyToDo.Views.LoginView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MyToDo.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   ,passclr-namespace:MyToDo.Extensions   _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 $	��600��$	��350��#  Prism.Services.Dialogs.Dialog    WindowStyle  ��  �� 
TargetType" �.���  �� Property � �� �� Value$	 600����  � ��$	 350����  �@�SizeToContent$ WidthAndHeight=���  �@�
ResizeMode$ NoResize=���  �@ WindowStartupLocation$ CenterScreen=�.��� 
������� � ColumnDefinitions �� $
��1.4* ��� .+��� $��/Images/Login.png��$	�� 50q�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ LoginSnackbar�� K� ZIndex$ 1��$��2��   MessageQueue 4  .MaterialDesignThemes.Wpf.MessageQueueExtension  7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  $��1�� �� SelectedIndex �� *SelectedIndex+.@�<  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  .��]� $��Center=�$��15q�.+��� $��欢迎使用��$��22(�$
��Bold"�$
��0,10q�$	��Top=��� $
��0,10q�$	��Top=�)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 请输入账号������ *	Account+G� $
��0,10q�$	��Top=�$	 请输入密码��*   $MyToDo.Extensions.PassWordExtensions
   PassWord
 �� *
PassWord+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�* 	 $Microsoft.Xaml.Behaviors.Interaction   	Behaviors (	   "MyToDo.Extensions.PassWordBehavior	  �� $��登录系统��$	��Top=�$��Login������ *ExecuteCommand+]� $��False��$
��0,10q�.+��� $��注册账号��   Triggers +
 	 %Microsoft.Xaml.Behaviors.EventTrigger
   
  	EventName$ MouseLeftButtonDown��* 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ Go��   Command �� *ExecuteCommand+�� $��忘记密码��$��Right=�  .��]� $��Center=�$��15q�.+��� $��注册账号��$��22(�$
��Bold"�$	��Top=��� $
��0,10q�$	 请输入账号��$	��Top=����� *RUserDto.Account+�� $
��0,10q�$	 请输入用户名��$	��Top=� � Cursor$ IBeam������ *RUserDto.UserName+G� $
��0,10q�$	��Top=�$	 请输入密码��
 �� *RUserDto.PassWord+$ PropertyChanged=�$ TwoWay=� 	  G� $
��0,10q�$	��Top=�$	 请再次输入密码��
 �� *RUserDto.NewPassWord+$ PropertyChanged=�$ TwoWay=� 	  �� $��注册账号��$
��0,10q�$	��Top=�$��Register������ *ExecuteCommand+�� $��返回登录��$
��0,10q�$	��Top=�    MaterialDesignOutlinedButton#��[  $��Return������ *ExecuteCommand+