// <copyright file="Address.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Address
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Contains url-address information.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class. 
        /// </summary>
        /// <param name="hostName">Address host name.</param>
        /// <param name="segments">Segments of address.</param>
        /// <param name="parameters">Parameters of address.</param>
        public Address(string hostName, string[] segments, Dictionary<string, string> parameters)
        {
            this.HostName = hostName ?? throw new ArgumentNullException(nameof(hostName));
            this.Segments = new ReadOnlyCollection<string>(segments) ?? throw new ArgumentNullException(nameof(hostName));
            this.Parameters = new ReadOnlyDictionary<string, string>(parameters) ?? throw new ArgumentNullException(nameof(hostName));
        }

        /// <summary>
        /// Gets host name.
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// Gets URL-address segments.
        /// </summary>
        public ReadOnlyCollection<string> Segments { get; }

        /// <summary>
        /// Gets URL-address parameters.
        /// </summary>
        public ReadOnlyDictionary<string, string> Parameters { get; }
    }
}
