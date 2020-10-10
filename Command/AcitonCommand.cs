using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
namespace Account_MVVM.Command
{
    public class ActionCommand : ICommand
    {
        private readonly Action Action;
        public ActionCommand(Action action)
        {
            this.Action = action;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            Action();
        }
    }
}
