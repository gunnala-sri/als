using System;
using System.Threading;
using System.Threading.Tasks;

namespace XboxGame.Service
{
    /// <summary>
    /// An helper class to make synchronous call asynchronously
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// Instantiate TaskFactory
        /// </summary>
        private static readonly TaskFactory _taskFactory = new
        TaskFactory(CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default);

        /// <summary>
        /// Runs given functions Synchronously
        /// </summary>
        /// <typeparam name="TResult">Result object</typeparam>
        /// <param name="func">Function to be run</param>
        /// <returns>result</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        /// Runs given functions Synchronously
        /// </summary>
        /// <param name="func">Function to be run</param>
        public static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}
