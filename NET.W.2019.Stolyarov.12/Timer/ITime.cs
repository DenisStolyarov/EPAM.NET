// <copyright file="ITime.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Clock
{
    /// <summary>
    /// Time representation.
    /// </summary>
    public interface ITime
    {
        /// <summary>
        /// Display the time.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event arguments</param>
        void ShowTime(object sender, TimerEventArgs e);
    }
}
