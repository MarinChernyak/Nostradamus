using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nostradamus.ViewModels.Commands
{
    public class CommandBase : ICommand
    {
        protected BaseViewModel _parentVM;
        public event EventHandler CanExecuteChanged;

        public bool IsParentNull() { return _parentVM == null; }

        protected CommandBase(BaseViewModel parent)
        {
            _parentVM = parent;
        }
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
        public virtual void Execute(object parameter)
        {

        }

    }
}
