   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  C&clr-namespace:MyToDo.Common.ConvertersMyToDo.Common.Converters      MyToDo.Views.MemoView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MyToDo.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  /cv&clr-namespace:MyToDo.Common.Converters    � 	Resources  5   /MyToDo.Common.Converters.IntToVisibilityConvert   IntToVisibility��%   &	          .��)  #MaterialDesignThemes.Wpf.DialogHost  .��)  #MaterialDesignThemes.Wpf.DrawerHost     IsRightDrawerOpen �� *IsRightDrawerOpen+   RightDrawerContent ]� $	��300��$��False��.+���  �� Padding$ 20,10q�$��添加备忘录��$��20(�$
��Bold"�$	��Top=��� $
��20,0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入备忘录概要��$	��Top=� � Cursor$ IBeam������ *CurrentDto.Title+�� $��20,20q�$ 请输入备忘录内容��$	��100��$	��Top=�$ IBeam������ *CurrentDto.Content+�� $��保存��$
��20,0q�$��添加到备忘录��$	��Top=����� *ExecuteCommand+.���  � RowDefinitions �� $
��auto ��� .+��� $��15,0,0,0q� �� Orientation$ 
Horizontal=�.+��� $	��250��$��Center=�$ 查找备忘录...��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True������ *Search+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�.�� J� InputBindings �� 
 �� Key$ Enter�� �� CommandParameter$ 查询�� �� Command �� *ExecuteCommand+.���� $��新增��$��Right=�$
��10,5q�$��+ 添加备忘录������ *ExecuteCommand+�� $��1��$��Center=�y��� *MemoDtos.Count+ �� 	Converter# [  .+��� $��/Images/backwind.png��$	��120��$	��120���� $
��0,10q�$��18(�$��Center=�$?��9尝试添加一些备忘录，以便在此处查看它们���� $��1��.���� $��Center=����� *
MemoDtos+���� .R�� ���� .R�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ ExpandIn=�.��� $��8q�$	��220��$	��180��$	��250��*	  $Microsoft.Xaml.Behaviors.Interaction 	  Triggers +
  %Microsoft.Xaml.Behaviors.EventTrigger
   
  	EventName$ MouseLeftButtonUp��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter ��    Command �� *DataContext.SelectedCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType ItemsControl �� $
��auto ��� .+�'  !MaterialDesignThemes.Wpf.PopupBox  $��Right=� K� ZIndex$ 1��   PopupContent. �� $��删除������ ���� *DataContext.DeleteCommand+ �� $ FindAncestor=� ItemsControl��  �� CornerRadius$ 3��$��2��
��������� $
 10,5q�$
��Bold"����� *Title+�� $
 10,5q�$��1������ *	Content+�� $��2��$
}�True��.+��� 
 �� Top$ 10��$	 100�� �� Right$	 -50��$	��120��$	��120�����#FFFFFF J� Opacity$	 0.1Q��� $ 80��$	 100��$	 -30��$	��120��$	��120�����#FFFFFF$	 0.1Q�