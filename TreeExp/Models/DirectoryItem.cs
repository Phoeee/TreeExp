using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExp
{
    public abstract class DirectoryItem
    {
        public virtual string FullName
        {
            get
            {
                return fileInfo.FullName;
            }
        }
        public virtual string Name
        {
            get
            {
                return fileInfo.Name;
            }
        }
        public virtual string DirectoryPath
        {
            get
            {
                return fileInfo.DirectoryName;
            }
        }

        protected FileInfo fileInfo;

        public DirectoryItem(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }

        public static ObservableCollection<DirectoryItem> GetSubDirectory(string FullName, bool getFiles = true)
        {
            try
            {
                var directoryFolderEntries = Directory.GetDirectories(FullName);
                var directoryFileEntries = Directory.GetFiles(FullName);

                var subDirectory = new List<DirectoryItem>();
                foreach (var folderName in directoryFolderEntries)
                {
                    var fileInfo = new FileInfo(folderName);
                    FileAttributes attributes = File.GetAttributes(folderName);
                    if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden &&
                        (attributes & FileAttributes.System) == FileAttributes.System)
                        continue;

                    subDirectory.Add(new FolderItem(fileInfo));
                }
                if (getFiles)
                {
                    foreach (var fileName in directoryFileEntries)
                        subDirectory.Add(new FileItem(new FileInfo(fileName)));
                }

                return new ObservableCollection<DirectoryItem>(
                        subDirectory.OrderBy((x) => { return x.Name; }));
            }
            catch
            {
                return new ObservableCollection<DirectoryItem>();
            }
        }
    }
}
