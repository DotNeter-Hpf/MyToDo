   M S B A M L   `   `   `  ���� A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyToDoMyToDo  5clr-namespace:MyToDo.ExtensionsMyToDo.Extensions      MyToDo.Views.MainView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:MyToDo     [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   +extclr-namespace:MyToDo.Extensions   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  _	 [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True � Title$ 
MainWindow��$	��768��$
��1280��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���  $��微软雅黑)� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency$
 True��.��) 	 #MaterialDesignThemes.Wpf.DialogHost  -     Name$ 
DialogHost��   
Identifier$
 Root��	   DialogTheme$	 Inherit=�.��) 	 #MaterialDesignThemes.Wpf.DrawerHost  -   
  Name$
 
drawerHost��   IsLeftDrawerOpen ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked�   LeftDrawerContent ]� $	��220��.+��� $
��0,20q�$	��Top=�.+��� $��/Images/user.png��$��50��$��50��$
��10,5q� J� Clip @�  @� Center$ 25,25&� @� RadiusX$ 25Q� @� RadiusY$ 25Q��� $
��0,10q�$��Center=����� *
UserName+�� -    ��Name$ menuBar��  MyListBoxItemStyle#��[ ���� *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *NavigateCommand+   CommandParameter �� *SelectedItem+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType ListBox���� .R���  �� Orientation$ 
Horizontal=�
������ .+�'	 	 !MaterialDesignThemes.Wpf.PackIcon	  $
��15,0q� 	  Kind �� *Icon+�� $
��10,0q����� *Title+.���  � RowDefinitions �� $
��auto ��� .+�'
 	 !MaterialDesignThemes.Wpf.Snackbar
  -    
 Name$ Snackbar��  K� ZIndex$  1��! 
  MessageQueue! 4 	 .MaterialDesignThemes.Wpf.MessageQueueExtension  ( 	 "MaterialDesignThemes.Wpf.ColorZone  -   "  Name$" 	ColorZone��$��16q�+ 	 %MaterialDesignThemes.Wpf.ShadowAssist#   ShadowDepth$# Depth2=�$   Mode$$ 
PrimaryMid=�$	��Top=�.��]� .+��� $��Right=�$ 
Horizontal=�.+��� -   % ��Name$% btnMin��$	��—�� ! MaterialDesignFlatMidBgButton#��[ �� -   $% btnMax��$	��☐��#��[ �� -   $% btnClose��$	��✕��#��[ ' 	 !MaterialDesignThemes.Wpf.PopupBox  $��Right=�&   ToggleContent& �� $��/Images/user.png��$��30��$��30��$
��30,5q� @� $ 15,15&�$ 15Q�$ 15Q�'   PopupContent.' �� .+��� $��注销当前账户������ *LoginOutCommand+�� $��个人中心������ *AppCenterCommand+�� $ 
Horizontal=�.+�d� -	   ( d�Name$( MenuToggleButton�� ' #MaterialDesignHamburgerToggleButton#��[ ) d� 	IsChecked$) FalseY�4  .System.Windows.Automation.AutomationProperties*   Name$* HamburgerToggleButton���� $��24,0,0,0q�+ � ToolTip$+ Previous Item��  MaterialDesignToolButton#��[ ���� *GoBackCommand+��0 	 *MaterialDesignThemes.Wpf.PackIconExtension  ,   Kind$, 	ArrowLeft=�-   Size- 24����  �� " �$ (TextElement.Foreground)�+ 	 %MaterialDesignThemes.Wpf.RippleAssist.   Feedback. ��  �� *Self+$ 
Foreground�  BrushRoundConverter/ �� 	Converter#/ [ �� $��16,0,0,0q�$+ 	Next Item��#��[ ���� *GoForwardCommand+��  $, 
ArrowRight=�- 24����  �� " �$ (TextElement.Foreground)�. ��  �� *Self+$ 
Foreground�#/ [ �� $
��16,0q�$��Center=�$��Center=�$��22(�$%* Material Design In XAML Toolkit��$��MyToDo笔记本���� $��1��$   MyToDo.Extensions.PrismManager0   MainViewRegionName!  Prism.Regions.RegionManager1   
RegionName#1 Z0 