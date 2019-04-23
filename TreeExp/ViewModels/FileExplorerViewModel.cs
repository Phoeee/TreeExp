using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TreeExp
{
    public class FileExplorerViewModel
    {
        public FileExplorerViewModel()
        {
            DirectoryDisplayViewModel = new DirectoryDisplayViewModel();
            NavigationDisplayViewModel = new NavigationDisplayViewModel(DirectoryDisplayViewModel);
        }

        public DirectoryDisplayViewModel DirectoryDisplayViewModel
        {
            get;
            private set;
        }
        public NavigationDisplayViewModel NavigationDisplayViewModel
        {
            get;
            private set;
        }
    }
}
