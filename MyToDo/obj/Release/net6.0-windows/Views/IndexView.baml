   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyToDo.ViewsMyToDo.Views  C&clr-namespace:MyToDo.Common.ConvertersMyToDo.Common.Converters      MyToDo.Views.IndexView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:MyToDo.Views     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  /cv&clr-namespace:MyToDo.Common.Converters    � 	Resources  /   )MyToDo.Common.Converters.IntToBoolConvert   	intToBool��%   &	          .���  � RowDefinitions �� $
��auto ��� $
��auto ��� .+��� $��15,10q�$��22(����� *Title+�� $��1������ *
TaskBars+���� .R�A�  A� Columns$ 4������ .R��� $��10q� �� CornerRadius$ 5������ *Color+ J� InputBindings d�  d� MouseAction$ 	LeftClicke� �� Command �� *DataContext.NavigateCommand+ �� RelativeSource ��  �� Mode$ FindAncestor=�	 �� AncestorType	 ItemsControl
 �� CommandParameter
 �� ����  �� 
TargetType" �� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� Property �@J�Effect �� Value 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ #DDDDDD��   ShadowDepth$ 1Q�   
BlurRadius$ 10Q�._�� .+��� $��20,10q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $	��5,0q�$��30��$��30��   Kind �� *Icon+�� $
��0,15q�$��15(����� *Title+�� $
��Bold"�$��40(����� *	Content+�� $
}�True��.+��� 
 �� Top$ 10��$	 100�� �� Right$	 -50��$	��120��$	��120�����#FFFFFF J� Opacity$	 0.1Q��� $ 80��$	 100��$	 -30��$	��120��$	��120�����#FFFFFF$	 0.1Q�� $��2��$
��0,10q� � ColumnDefinitions �� �� .+��� ���#BEBEBE$
��10,0q�$ 5��$	 0.1Q�]� $
��10,0q�.+�]� $
��10,5q�$	��Top=�$��False��.+��� $��待办事项��$��20(�$
��Bold"���  , (MaterialDesignFloatingActionAccentButton#��[ $��30��$��30��$��Right=�$	��Top=�$��新增待办������ *ExecuteCommand+.��  $	 Add=��� -    ��Name$ todoList��$��Hidden=�$��Stretch=����� *Summary.TodoList+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ MouseDoubleClick��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *EditToDoCommand+   CommandParameter ��  �� ElementName$ todoList��  �� Path$  SelectedItem����� .R�]� $��80��$��False��.+�d� $��Right=�! d� 	IsChecked! �� *Status+" �� 	Converter#" [  ���� *DataContext.TodoStatusSuccess+ �� $ FindAncestor=�	 ItemsControl���� �� .+��� $��16(�$
��Bold"����� *Title+�� $	 0.5Q�$	��0,5q����� *	Content+�� $��1�����#BEBEBE$
��10,0q�$ 5��$	 0.1Q�]� $��1��$
��10,0q�.+�]� $
��10,5q�$	��Top=�$��False��.+��� $��	备忘录��$��20(�$
��Bold"��� #��[ $��30��$��30��$��Right=�$	��Top=�$��新增备忘录������ *ExecuteCommand+.��  $	 Add=��� -   $ memoList��$��Hidden=�$��Stretch=����� *Summary.MemoList+   $ MouseDoubleClick��.    �� *EditMemoCommand+ �� $ memoList��$  SelectedItem����� .R�]� $��80��$��False��.+��� .+��� $��16(�$
��Bold"����� *Title+�� $	 0.5Q�$	��0,5q����� *	Content+