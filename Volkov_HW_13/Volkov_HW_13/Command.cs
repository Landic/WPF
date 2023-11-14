using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Volkov_HW_13
{
    public class Command : ICommand
    {
        Action<object> execute;
        Predicate<object> can_execute;
        public Command(Action<object> execute, Predicate<object> can_execute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            this.execute = execute;
            this.can_execute = can_execute;
        }
        public bool CanExecute(object param)
        {
            if (can_execute != null) return can_execute(param);
            return true;
        }
        public void Execute(object param) => execute(param);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
