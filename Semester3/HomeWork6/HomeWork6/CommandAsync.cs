using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork6
{
    /// <summary>
    /// Async command class.
    /// </summary>
    public class CommandAsync : ICommand
    {
        public Func<object, Task> ExecuteFunction { get; }

        public Predicate<object> CanExecutePredicate { get; }

        public event EventHandler CanExecuteChanged;

        public void UpdateCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool IsWorking { get; private set; }

        public CommandAsync(Func<object, Task> executeFunction) : this(executeFunction, (obj) => true) { }

        public CommandAsync(Func<object, Task> executeFunction, Predicate<object> canExecutePredicate)
        {
            ExecuteFunction = executeFunction;
            CanExecutePredicate = canExecutePredicate;
        }

        public bool CanExecute(object parameter) => !IsWorking && (CanExecutePredicate?.Invoke(parameter) ?? true);

        /// <summary>
        /// Execute async command
        /// </summary>
        /// <param name="parameter">Command parameter.</param>
        public async void Execute(object parameter)
        {
            IsWorking = true;
            UpdateCanExecute();

            await ExecuteFunction(parameter);

            IsWorking = false;
            UpdateCanExecute();
        }
    }
}
