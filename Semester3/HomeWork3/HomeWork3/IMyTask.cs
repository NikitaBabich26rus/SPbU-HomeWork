using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork3
{
    /// <summary>
    /// Task interface
    /// </summary>
    public interface IMyTask<TResult>
    {
        /// <summary>
        /// Checking the task for completeness
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Get tesult
        /// </summary>
        TResult  Result { get; }

        /// <summary>
        /// Add new task based on result of this task.
        /// </summary>
        /// <param name="func">New function</param>
        /// <returns>New task</returns>
        IMyTask<TNewResult> ContinueWith<TNewResult>(Func<TResult, TNewResult> func);
    }
}
