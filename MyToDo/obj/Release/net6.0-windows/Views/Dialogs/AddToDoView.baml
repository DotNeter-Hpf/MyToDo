   M S B A M L   `   `   `  ���� 
  MyToDo&     MyToDo.Views.Dialogs.AddToDoView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  $	��280��$	��450��.���   � RowDefinitions  �� $
��auto ��� �� $
��auto �.+��� $��添加待办��$
��Bold"�$��20(� �� Padding$ 20,10q�]� $��1��$��False��.+��� $��20,10q�$	��Top=� �� Orientation$ 
Horizontal=�.+��� $��状态��$��Center=��� $��10,0,0,0q� �� SelectedIndex �� *Model.Status+.@��� .��待办�� .��	已完成�� $
��20,0q�$	��Top=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入待办概要������ *Model.Title+�� $��20,10q�$	��Top=�$	��100�� �� TextWrapping$
 Wrap=� �� AcceptsReturn$
 True��$ 请输入待办内容������ *Model.Content+�� $��10q�$��2��$ 
Horizontal=�$��Right=�.+��� $��取消��$��0,0,10,0q�    MaterialDesignOutlinedButton#��[  ���� *CancelCommand+�� $��保存�� � Cursor$
 Hand������ *SaveCommand+