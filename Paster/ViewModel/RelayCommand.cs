using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Paster.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action executableFunction;

        public RelayCommand(Action? executableFunction)
        {
            this.executableFunction = executableFunction!;
        } 

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            executableFunction.Invoke();
        }
    }

    public class RelayCommand<T> : ICommand 
    {
        private readonly Action<T?> executableFunction;
        public RelayCommand(Action<T?> executableFunction)
        {
            this.executableFunction = executableFunction;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            executableFunction.Invoke((T?)parameter);
        }
    }

}
