// <copyright file="Timer.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Clock
{
    using System;
    using System.Threading;

    /// <summary>
    /// Class for time delay.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Timer event.
        /// </summary>
        private EventHandler<TimerEventArgs> timeControl;

        /// <summary>
        /// Event subscription.
        /// </summary>
        /// <param name="time">The ITime instance</param>
        public void Add(ITime time)
        {
            this.timeControl += time.ShowTime;
        }

        /// <summary>
        /// Event unsubscription.
        /// </summary>
        /// <param name="time">The ITime instance</param>
        public void Remove(ITime time)
        {
            this.timeControl -= time.ShowTime;
        }

        /// <summary>
        /// Starts the countdown.
        /// </summary>
        /// <param name="seconds">The time</param>
        public void Start(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            this.OnTime(seconds);
        }

        /// <summary>
        /// Event notification
        /// </summary>
        /// <param name="time">Seconds passed</param>
        private void OnTime(int time)
        {
            this.timeControl?.Invoke(this, new TimerEventArgs(time));
        }
    }
}
