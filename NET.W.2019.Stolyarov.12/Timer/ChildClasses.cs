// <copyright file="ChildClasses.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Clock
{
    using System;

    /// <summary>
    /// Work with seconds.
    /// </summary>
    public class Second : ITime
    {
        /// <inheritdoc/>
        public void ShowTime(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"{e.Seconds} second(s) passed");
        }
    }

    /// <summary>
    /// Work with minutes.
    /// </summary>
    public class Minute : ITime
    {
        /// <inheritdoc/>
        public void ShowTime(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"{e.Seconds / 60} minute(s) passed");
        }
    }

    /// <summary>
    /// Work with hours.
    /// </summary>
    public class Hour : ITime
    {
        /// <inheritdoc/>
        public void ShowTime(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"{e.Seconds / 3600} hour(s) passed");
        }
    }
}
