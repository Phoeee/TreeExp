using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TreeExp
{
    public class FileItem : DirectoryItem
    {        
        public FileItem(FileInfo fileInfo) : base(fileInfo)
        {
        }
    }
}
