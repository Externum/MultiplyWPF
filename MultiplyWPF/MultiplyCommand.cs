using System;
using System.Windows.Input;

namespace MultiplyWPF
{
    class MultiplyCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public MultiplyCommand(Action _execute, Func<bool> _canExecute)
        {
            execute = _execute;
            canExecute = _canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
