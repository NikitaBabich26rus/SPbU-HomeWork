using System;
using System.Windows.Input;

namespace HomeWork6
{
    /// <summary>
    /// Command for client 
    /// </summary>
    public class Command : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="execute">Execution action.</param>
        public Command(Action<object> execute)
            : this(execute, null)
        {
            _execute = execute;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="execute">Execution action.</param>
        /// <param name="canExecute">Func that determines whether the command can execute.</param>
        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
