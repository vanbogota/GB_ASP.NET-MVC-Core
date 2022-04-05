using System;
using System.Windows;
using System.Windows.Input;

namespace Creational_pattern
{
    public class CommandFactoryMethod : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute; 
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandFactoryMethod(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }

    internal sealed class CommandFactory 
    {
        private CommandFactoryMethod addCommand;
        public CommandFactoryMethod AddCommand
        {
            get 
            {
                return addCommand = new CommandFactoryMethod(obj =>
                {
                    MessageBox.Show("New comand added");
                }); 
            }
        }
        private CommandFactoryMethod removeCommand;
        public CommandFactoryMethod RemoveCommand
        {
            get
            {
                return removeCommand = new CommandFactoryMethod(obj =>
                {
                    MessageBox.Show("Command removed");
                });
            }
        }
    }
}
