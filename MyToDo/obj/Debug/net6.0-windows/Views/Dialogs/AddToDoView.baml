   M S B A M L   `   `   `  ����
  MyToDo&     MyToDo.Views.Dialogs.AddToDoView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��280��5      $	��450��5	      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   �� $��添加待办��6   $
��Bold"�5      $��20(�5       �� Padding$ 20,10q�5      ]� 5   
   $��1��6   $��False��5      .+�5      �� $��20,10q�6   $	��Top=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� $��状态��6   $��Center=�6&   �� 5      $��10,0,0,0q�6B    �� SelectedIndex 6   �� *Model.Status+.@�5      �� .��6#   待办6'   �� 5      .��6#   	已完成6(   5       5!      �� 5#      $
��20,0q�6   $	��Top=�5$      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入待办概要��5%      ��63   �� *Model.Title+�� 5'      $��20,10q�6   $	��Top=�5(      $	��100��5)       �� TextWrapping$
 Wrap=�5*       �� AcceptsReturn$
 True��5+      $ 请输入待办内容��5,      ��64   �� *Model.Content+5-      �� 5/   
   $��10q�6   $��2��50      $ 
Horizontal=�51      $��Right=�52      .+�54      �� $��取消��6   $��0,0,10,0q�56          MaterialDesignOutlinedButton#��[  6(   ��55      �� *CancelCommand+56   (   �� 58      $��保存��6    � Cursor$
 Hand��5:      ��59      �� *SaveCommand+5:      5;      5<      5=      