using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Account_MVVM.Command
{
     public abstract class BaseButton : ICommand
    {
        #region CanExecute
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        #endregion
        public virtual void Execute(object parameter) { }
    }
}
