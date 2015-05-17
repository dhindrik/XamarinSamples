using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drivis.Core.Mvvm
{
    public class Command : ICommand
    {
        private Action _action;
        private Action<object> _actionWithParameter;

        public Command(Action action)
        {
            _action = action;
        }
        public Command(Action<object> action)
        {
            _actionWithParameter = action;
        }

        public bool CanExecute(object parameter)
        {
            if(_action != null || _actionWithParameter != null)
            {
                return true;
            }

            return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if(_action != null)
            {
                _action();
            }
            else if(_actionWithParameter != null)
            {
                _actionWithParameter(parameter);
            }
        }
    }
}
