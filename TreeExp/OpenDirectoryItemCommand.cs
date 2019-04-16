using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TreeExp
{
    public class OpenDirectoryItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<string> executeAction;

        public OpenDirectoryItemCommand(Action<string> executeAction)
        {
            this.executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public void Execute(object parameter)
        {
            var fileItem = parameter as FileItem;
            var folderItem = parameter as FolderItem;
            var driveItem = parameter as DriveItem;

            if (fileItem != null)
                Process.Start((parameter as FileItem).FullName);
            else if (folderItem != null)
                executeAction.Invoke(folderItem.FullName);
            else if (driveItem != null)
                executeAction.Invoke(driveItem.FullName);
        }
    }
}
