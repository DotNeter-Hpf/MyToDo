   M S B A M L   `   `   `  ����A  =MyToDo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MyToDo.ExtensionsMyToDo.Extensions  5      clr-namespace:MyToDoMyToDo  5          MyToDo.Views.MainView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /extclr-namespace:MyToDo.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5       localclr-namespace:MyToDo  5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5        � Title$  
MainWindow��5      $
��1280��5      $	��768��5      ! 	 Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5       � AllowsTransparency$
 True��5         MaterialDesignPaper#���   5      $��微软雅黑)�5      $��13(�5      $��Regular"�5        MaterialDesignBody#���  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5$      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 
DialogHost��5%   	      DialogTheme$ Inherit=�5&   	   	   
Identifier$
	 Root��5'   	   .��5)   
   )  #MaterialDesignThemes.Wpf.DrawerHost  -   5        
  Name$
 
drawerHost��5)   $      IsLeftDrawerOpen 68   ��  �� ElementName$ MenuToggleButton�� �� Path$ 	IsChecked�   LeftDrawerContent 5,      ]� 5-      $	��220��6   .+�5/      �� $
��0,20q�6!   $	��Top=�6/   .+�50      �� $��50��51      $��50��52      $
��10,5q�53      $��/Images/user.png��54       J� Clip 55      @� 56   "    @� Center$ 25,25&�57   %    @� RadiusX$ 25Q�58   %    @� RadiusY$ 25Q�59   %   5;      �� 5<      $
��0,10q�5=      $��Center=�5>      ��5?      �� *
UserName+5@      �� 5C      -   5         ��Name$ menuBar��5D        MyListBoxItemStyle#��[ 5E      ��5F      �� *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5G      +  %Microsoft.Xaml.Behaviors.EventTrigger  5H         	EventName$ SelectionChanged��6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5I   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   �� *NavigateCommand+   CommandParameter 6\   �� *SelectedItem+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType ListBox5J      ��5L      �� 5M      .R�5O   "   �� 
������  �� Orientation$ 
Horizontal=�6F   .+�5P   &   '	  !MaterialDesignThemes.Wpf.PackIcon	  $
��15,0q�6>    	  Kind 6L   �� *Icon+�� 5Q   &   $
��10,0q�60   ��6>   �� *Title+5R   #   5S      5U      5V      .��5Y      �  � RowDefinitions 5Z      �� 5[      $
��auto �6$   �� 5\      .+�5_      '
  !MaterialDesignThemes.Wpf.Snackbar
  -   5         
 Name$ Snackbar��5`        K� ZIndex$  1��5a      ! 
  MessageQueue! 5b      4  .MaterialDesignThemes.Wpf.MessageQueueExtension  (  "MaterialDesignThemes.Wpf.ColorZone  5c      -   5        "  Name$" 	ColorZone��5d      $��16q�5e      +  %MaterialDesignThemes.Wpf.ShadowAssist#   ShadowDepth$# Depth2=�5f      $	��Top=�5g      $   Mode$$ 
PrimaryMid=�5h      .��5i      ]� .+�5k      �� $��Right=�6%   $ 
Horizontal=�6<   .+�5l      �� -   5        % ��Name$% btnMin��5m   !   $	��—��5n   !   & � Cursor$
& Hand��5o   !    ! MaterialDesignFlatMidBgButton#��[ 5p   !   �� 5q      -   5        $% btnMax��5r   !   $	��☐��5s   !   #��[ 5t   !   �� 5u      -   5        $% btnClose��5v   !   $	��✕��5w   !   #��[ 5x   !   5y      '  !MaterialDesignThemes.Wpf.PopupBox  5{      $��Right=�62   '   ToggleContent' 5|      �� 5}   "   $��30��5~   %   $��30��5   %   $
��30,5q�5�   %   $��/Images/user.png��5�   %    5�   &   @� 5�   *   $ 15,15&�5�   -   $ 15Q�5�   -   $ 15Q�5�   -   5�   #   (   PopupContent.( 5�      �� .+�5�   "   �� $��注销当前账户��6M   ��6)   �� *LoginOutCommand+6M   �� 5�   "   $��个人中心��6N   ��6)   �� *AppCenterCommand+6N   5�      5�      �� 5�      $ 
Horizontal=�6%   .+�5�      d� -	   5        ) d�Name$) MenuToggleButton��5�   !   4  .System.Windows.Automation.AutomationProperties*   Name$* HamburgerToggleButton��5�   !   + d� 	IsChecked$+ FalseY�5�   !    ' #MaterialDesignHamburgerToggleButton#��[ 5�   !   �� 5�      $��24,0,0,0q�5�   !   $
& Hand��5�   !     MaterialDesignToolButton#��[ 5�   !   , � ToolTip$, Previous Item��5�   !   +  %MaterialDesignThemes.Wpf.RippleAssist-   Feedback- 5�   !   ��  �� *Self+$ 
Foreground�  BrushRoundConverter. �� 	Converter#. [ ��5�   !   �� *GoBackCommand+��5�   !   0  *MaterialDesignThemes.Wpf.PackIconExtension  /   Kind$/ 	ArrowLeft=�0   Size0 24��5�   !   ��  �� " �$ (TextElement.Foreground)�5�   !   �� 5�      $��16,0,0,0q�5�   !   #��[ 5�   !   $, 	Next Item��5�   !   - 5�   !   ��  �� *Self+$ 
Foreground�#. [ ��5�   !   �� *GoForwardCommand+��5�   !     $/ 
ArrowRight=�0 24��5�   !   ��  �� " �$ (TextElement.Foreground)�5�   !   �� 5�      $
��16,0q�5�   !   $��Center=�5�   !   $��Center=�5�   !   $%* Material Design In XAML Toolkit��5�   !   $��22(�5�   !   $��MyToDo笔记本��5�   !   5�      5�      5�      �� 5�      $��1��6!   $   MyToDo.Extensions.PrismManager1   MainViewRegionName! 	 Prism.Regions.RegionManager2   
RegionName#2 Z1 6.   5�      5�      5�      5�      