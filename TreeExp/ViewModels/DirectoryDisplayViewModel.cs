using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TreeExp
{

    public class DirectoryDisplayViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// Drive view directory name.
        /// </summary>
        public const string MyComputer = "My Computer";

        /// <summary>
        /// Use the Property. - The full path of the active directory.
        /// </summary>
        private string activeDirectoryName;

        /// <summary>
        /// Invoked when the Active Directory is changed.
        /// </summary>
        public event EventHandler<string> ActiveDirectoryChanged;

        /// <summary>
        /// Executes SetDirectory().
        /// </summary>
        public ICommand OpenDirectoryItemCommand { get; private set; }

        /// <summary>
        /// Executes UpDirectory().
        /// </summary>
        public ICommand UpDirectoryCommand { get; private set; }

        /// <summary>
        /// The full path of the active directory. Updates the address bar text when changed.
        /// </summary>
        public string ActiveDirectoryName
        {
            get
            {
                return activeDirectoryName;
            }
            set
            {
                if (activeDirectoryName != value)
                {
                    activeDirectoryName = value;
                    RaisePropertyChanged("ActiveDirectoryName");
                    ActiveDirectoryChanged?.Invoke(this, value);
                }
            }
        }

        /// <summary>
        /// Contains all the items (files/folders/drives) within the Active Directory
        /// </summary>
        public ObservableCollection<DirectoryItem> ActiveDirectoryCollection { get; private set; }

        /// <summary>
        /// Directory Display Constructor.
        /// </summary>
        public DirectoryDisplayViewModel()
        {
            ActiveDirectoryCollection = new ObservableCollection<DirectoryItem>();
            SetDirectory(@"C:\");
            OpenDirectoryItemCommand = new OpenDirectoryItemCommand(SetDirectory);
            UpDirectoryCommand = new UpCommand(UpDirectory);
        }

        /// <summary>
        /// Sets the active directory to the directory provided.
        /// </summary>
        /// <param name="directoryPath">The address of the directory.</param>
        public void SetDirectory(string directoryPath)
        {
            try
            {
                ActiveDirectoryCollection = DirectoryItem.GetSubDirectory(directoryPath);
                ActiveDirectoryName = directoryPath;
                RaisePropertyChanged("ActiveDirectoryCollection");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBoxResult result = MessageBox.Show("Error: Unauthorised Access.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Sets the active directory to the DriveView
        /// </summary>
        public void SetDriveView()
        {
            ActiveDirectoryName = MyComputer;

            var drives = Directory.GetLogicalDrives();

            ActiveDirectoryCollection.Clear();
            foreach (string drivePath in drives)
                ActiveDirectoryCollection.Add(new DriveItem(new FileInfo(drivePath)));
            ActiveDirectoryCollection = new ObservableCollection<DirectoryItem>(
                    ActiveDirectoryCollection.OrderBy((x) => { return x.Name; }).ToList());
            RaisePropertyChanged("ActiveDirectoryCollection");
        }

        /// <summary>
        /// Opens the parent directory. If there is no parent then it opens the "DriveView"
        /// </summary>
        public void UpDirectory()
        {
            if (ActiveDirectoryName == MyComputer)
                return;

            var parentDir = Directory.GetParent(ActiveDirectoryName);
            if (parentDir != null)
                SetDirectory(parentDir.FullName);
            else SetDriveView();
        }

    }
}
