using System;
using Microsoft.Extensions.Logging;

namespace MediaBrowser.Model.Tasks
{
    /// <summary>
    /// Interface ITaskTrigger.
    /// </summary>
    public interface ITaskTrigger
    {
        /// <summary>
        /// Fires when the trigger condition is satisfied and the task should run.
        /// </summary>
        event EventHandler<EventArgs> Triggered;

        /// <summary>
        /// Gets or sets the options of this task.
        /// </summary>
        TaskOptions TaskOptions { get; set; }

        /// <summary>
        /// Stars waiting for the trigger action.
        /// </summary>
        /// <param name="lastResult">Result of the last run triggerd task.</param>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="taskName">The name of the task.</param>
        /// <param name="isApplicationStartup">Wheter or not this is is fired during startup.</param>
        void Start(TaskResult lastResult, ILogger logger, string taskName, bool isApplicationStartup);

        /// <summary>
        /// Stops waiting for the trigger action.
        /// </summary>
        void Stop();
    }
}
