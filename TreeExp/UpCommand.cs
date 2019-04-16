using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TreeExp
{
    public class UpCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action executeAction;

        public UpCommand(Action executeAction)
        {
            this.executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeAction.Invoke();
        }
    }
}