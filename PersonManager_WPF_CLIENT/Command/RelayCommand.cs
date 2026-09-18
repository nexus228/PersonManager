using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PersonManager_WPF_CLIENT.Command
{
    internal class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute)
        {
            _execute = execute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is T value)
            {
                _execute(value);
            }
        }
    }
}
