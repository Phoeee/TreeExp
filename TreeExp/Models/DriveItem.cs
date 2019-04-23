using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TreeExp
{
    public class DriveItem : DirectoryItem
    {
        private static readonly string WindowsDrive = Path.GetPathRoot(Environment.SystemDirectory);
        private ObservableCollection<DirectoryItem> subDirectory;

        public ImageSource ImageSource
        {
            get;
            private set;
        }

        public DriveItem(FileInfo fileInfo) : base(fileInfo)
        {
            string driveLetter = fileInfo.FullName.Substring(0, 1);

            if (fileInfo.FullName == WindowsDrive)
            {
                string path = @"Assets\Drives\WindowsDrive.ico";
                ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
            }
            else
            {
                string path = $"Assets\\Drives\\{driveLetter}.ico";
                ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
            }
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
