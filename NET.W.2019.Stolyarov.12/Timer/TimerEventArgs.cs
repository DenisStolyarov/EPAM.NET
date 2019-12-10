// <copyright file="TimerEventArgs.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Clock
{
    using System;

    /// <summary>
    /// Arguments for timer event.
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerEventArgs"/> class.
        /// </summary>
        /// <param name="seconds">Time counter</param>
        public TimerEventArgs(int seconds)
        {
            this.Seconds = seconds;
        }

        /// <summary>
        /// Gets seconds.
        /// </summary>
        public int Seconds { get; }
    }
}
