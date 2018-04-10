using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeTask_C_sharp_55_ADO_Net
{
    public class CommandClass : ICommand
    {
        Action<object> execute;
        Func<object, bool> canexecute;

        public CommandClass(Func<object, bool> canexecute):this(null,canexecute)
        {
            this.canexecute = canexecute;
        }

        public CommandClass(Action<object> execute)
        {
            this.execute = execute;
            this.canexecute = null;
        }

        public CommandClass(Action<object> execute, Func<object, bool> canexecute)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if(canexecute!=null)
            return canexecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            if(execute!=null)
            execute(parameter);
        }
    }
}
