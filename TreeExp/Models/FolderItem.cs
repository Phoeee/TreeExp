using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExp
{
    class FolderItem : DirectoryItem
    {
        private ObservableCollection<DirectoryItem> subDirectory;

        public FolderItem(FileInfo fileInfo) : base(fileInfo)
        {
        }

        public ObservableCollection<DirectoryItem> SubDirectory
        {
            get
            {
                if (subDirectory == null)
                {
                    subDirectory = GetSubDirectory(FullName, false);
                }
                return subDirectory;
            }
        }
    }
}
