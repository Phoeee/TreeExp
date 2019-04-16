using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TreeExp
{
    public class DirectoryItemTemplateSelector: DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate dt = null;

            if (item is FileItem)
                dt = App.Current.MainWindow.FindResource("FileItemTemplate") as DataTemplate;
            else if (item is FolderItem)
                dt = App.Current.MainWindow.FindResource("FolderItemTemplate") as DataTemplate;
            else if (item is DriveItem)
                dt = App.Current.MainWindow.FindResource("DriveItemTemplate") as DataTemplate;

            return dt;
        }
    }
}
