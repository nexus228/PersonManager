using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PersonManager_WPF_CLIENT.Command
{
    internal class BaseCommand : ICommand
    {
        private readonly Action? _execute;
        public event EventHandler? CanExecuteChanged;

        public BaseCommand(Action execute)
        {
            _execute = execute;   
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke();
        }
    }
}
