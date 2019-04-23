using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TreeExp
{
    class NavigationItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dt = null;

            if (item is FileItem)
            {
                dt = App.Current.MainWindow.FindResource("NavFileItemTemplate") as DataTemplate;
            }
            else if (item is FolderItem)
            {
                dt = App.Current.MainWindow.FindResource("NavFolderItemTemplate") as HierarchicalDataTemplate;
            }
            else if (item is DriveItem)
            {
                dt = App.Current.MainWindow.FindResource("NavDriveItemTemplate") as HierarchicalDataTemplate;
            }
            return dt;
        }
    }
}
