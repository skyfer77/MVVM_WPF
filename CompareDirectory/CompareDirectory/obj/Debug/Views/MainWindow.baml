   M S B A M L   `   `   `  ����K  GCompareDirectory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CompareDirectoryCompareDirectory  5   	   I)clr-namespace:CompareDirectory.ViewModelsCompareDirectory.ViewModels  5   	   !    CompareDirectory.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CompareDirectory     5   	   8vm)clr-namespace:CompareDirectory.ViewModels     5   	     � Title$  FileCompare��5	   	   $	��450��6   $	��810��6*    � 
ResizeMode$ NoResize=�66    � DataContext 5
      0  *CompareDirectory.ViewModels.FilesViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Директория 1��6   $��5q�6,   �� 5      $	��600��64   $��20��6@   $��	5,-30,0,0q�6L   ��6   �� *SelectedPath+6L   �� 5      $��20��6   $��90��6!   $��
10,-30,0,0q�6,   $��Выбрать папку��6@   ��6X   �� *SelectDirCommand+5      �� 5   
   $��0,30,0,0q�6   $ 
Horizontal=�6(   .+�5      �� $��Директория 2��6   $��5q�6,   �� 5      $	��600��65   $��5q�6A   ��6   �� *SelectedPath2+6A   �� 5      $��20��6   $��90��6!   $��5,0,0,0q�6,   $��Выбрать папку��6=   ��6U   �� *SelectDirCommand2+5      &   System.Windows.Controls.DataGrid  5    
   $��1��6   $��5q�6       AutoGenerateColumns .  ��6+   �� *Items+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$! Название файла��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Name+  5#      $ Размер��6%    65   �� *Size+  5$      $6 0Дата последнего изменения��6%    6H   �� *
LastChange+  5%      $ Статус��6%    65   �� *Status+5'      5)      5*      