   M S B A M L   `   `   `  ����J  FGameMaintenance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GameMaintenanceGameMaintenance  5   	        GameMaintenance.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:GameMaintenance     5   	     � Title$  Játék karbantartó��5       � WindowState$ 	Maximized=�6   .��5      � -   5        $��JatekokGrid��5      ���	#FF3E3E59.+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��JatekokAdatai��5         AutoGenerateColumns$ False��6R      CanUserAddRows$ False��6n      CanUserDeleteRows$ False��6�      
IsReadOnly$
 True��6�   $��Stretch=�6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��500��6�   $
��Bold"�6  
�������   RowBackground
 �����   AlternatingRowBackground
 �����   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 30 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+  5      $
	 Név��6%   $	
 220 62    6>   �� *Nev+  5      $	 
Kategória��6%   $	
 150 68    6D   �� *	Kategoria+  5      $		 Ár��6%   $
 90 61    6<   �� *Ar+  5      $	 Leírás��6%   $	
 634 65    6A   �� *Leiras+  5      $
	 Kép��6%   $	
 150 62    6>   �� *Kep+  5      $	 Megjelenés��6%   $	
 227 69    6E   �� *
Megjelenes+4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 SizeToCells 6)      
IsReadOnly$
 True��6=      CellTemplate 5      �� 5      .R�5      �� $
��None=�6W   ��6$   �� *!ByteArrayToImageSourceConverter+6W   5      5      5       �� 5#   
   $
��Left=�65   $	��100��6P   $��256,683,0,0q�6]   $	��Top=�6r   $	��100��6�   ��6   �� *MyImageByteArray+6�   �� 5&   
   -   5        $��txb_Nev��5&      $
��Left=�6!   $��
55,619,0,0q�6<    �� TextWrapping$
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��175��6�   $��26��6�   $
��Bold"�6�   �� 5'   
   $
��Név��6   $
��Left=�6   $��
10,613,0,0q�69   $	��Top=�6M   $��26��6e   $��40��6q   ���	#FFF6F6F6$
��Bold"�6�   $��14(�6�   �� 5)   
   -   5        $��txb_Kategoria��5)      $
��Left=�6'   $��334,619,0,0q�6B   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��174��6�   $��26��6�   $
��Bold"�6�   �� 5*   
   $��
Kategória��6   $
��Left=�6$   $��256,613,0,0q�6?   $	��Top=�6T   $
��Bold"�6l   $��14(�6~   ���	#FFF4F1F16�   �� 5,   
   -   5        $��txb_Ar��5,      $
��Left=�6    $��584,619,0,0q�6;   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��140��6�   $��26��6�   $
��Bold"�6�   �� 5-   
   $	��Ár��6   $
��Left=�6   $��543,613,0,0q�68   $	��Top=�6M   
�������$
��Bold"�6x   $��14(�6�   �� 5/   
   -   5        $��
txb_Leiras��5/      $
��Left=�6$   $��824,619,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��234��6�   $��64��6�   $
��Bold"�6�   �� 50   
   $��Leírás��6   $
��Left=�6!   $��756,612,0,0q�6<   $	��Top=�6Q   ���	#FFFAFAFA$
��Bold"�6�   $��14(�6�   �� 52   
   -   5        $��txb_Megjelenes��52      $
��Left=�6(   $��1324,619,0,0q�6C   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��196��6�   $��26��6�   $
��Bold"�6�   �� 53   
   $��Megjelenés��6   $
��Left=�6%   $��1234,613,0,0q�6@   $	��Top=�6V   
�������$
��Bold"�6�   $��14(�6�   �� 58   
   -   5        $��btn_Modositas��58      $��Módosítás��6&   $
��Left=�6:   $��451,706,0,0q�6U   $	��Top=�6j   $	��117��6�   $��43��6�   $
��Bold"�6�   $��14(�6�   ���	#FF0B5CDF
������� � 	Resources 59       �� 
TargetType �� Property �� Value��%^   '��       �� 5:      " ��6   .�5;      ��  �@��CornerRadius$ 5��65   5<      5=      5>      �� 5H   
   -	   5        $��
btn_Torles��5H      $��Törlés��6#   $
��Left=�64   $��918,706,0,0q�6O   $	��Top=�6d   $	��117��6|   $��43��6�   $��14(�6�   $
��Bold"�6�   
����������	#FFD92416 5I      ��%^   '��       �� 5J      " ��6   .�5K      ��  �@��CornerRadius$ 5��65   5L      5M      5N      �� 5T   
   -
   5        $��
imgPreview��5T      $��Uniform=�6"   $	��117��65   $��43��6A   $��1218,706,405,161q�6M   �� 5`   
   -   5        $��btnSave��5`      $��Hozzáadás��6    $
��Left=�6J   $��688,706,0,0q�6e   $	��Top=�6z   $	��117��6�   $��43��6�   $��14(�6�   $
��Bold"�6�   
����������	#FF0B5CDF 5a      ��%^   '��       �� 5b      " ��6   .�5c      ��  �@��CornerRadius$ 5��65   5d      5e      5f      �� 5h   
   -   5        $��btnUploadImage��5h      $��Kép feltöltés��6'   $	��116��6]   $
��Left=�6i   $��1090,615,0,0q�6�   $	��Top=�6�   $��42��6�   $��14(�6�   $
��Bold"�6�    5i      ��%^   '��       �� 5j      " ��6   .�5k      ��  �@��CornerRadius$ 5��65   5l      5m      5n      5q      5r      