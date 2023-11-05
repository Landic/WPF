using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Volkov_HW_11_1
{
    public class DelegateCommand : ICommand
    {
        Action<object> execute;
        Predicate<object> canExecute;

        public DelegateCommand(Action<object>execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object? parameter)
        {
            if (canExecute != null)
            {
                return canExecute(parameter);
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
