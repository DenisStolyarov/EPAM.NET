// <copyright file="AddressReader.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Address
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Read all addresses from file.
    /// </summary>
    public class AddressReader
    {
        /// <summary>
        /// Base parsing rule.
        /// </summary>
        public readonly string BasePattern = @"^http[s]?\:\/\/\w+\.\w+\/((\w+\.?)*\/?)*(\?\w+\=\w+)*";

        /// <summary>
        /// Addresses container.
        /// </summary>
        private readonly List<Address> addresses = new List<Address>();

        /// <summary>
        /// Address separators.
        /// </summary>
        private readonly char[] separators = new char[] { '/', '?' };

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressReader"/> class. 
        /// </summary>
        /// <param name="path">Path to file.</param>
        public AddressReader(string path)
        {
            this.Path = path ?? throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
            {
                throw new ArgumentException(nameof(path), "File not found.");
            }

            this.Pattern = this.BasePattern;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressReader"/> class. 
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="pattern">Address parsing rule.</param>
        public AddressReader(string path, string pattern)
        {
            this.Path = path ?? throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
            {
                throw new ArgumentException(nameof(path), "File not found.");
            }

            this.Pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
        }

        /// <summary>
        /// Gets path to file.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets parsing rule.
        /// </summary>
        public string Pattern { get; }

        /// <summary>
        /// Load and parse all addresses from file.
        /// </summary>
        /// <returns>All Addresses</returns>
        public Address[] ReadAddresses()
        {
            using (var reader = new StreamReader(this.Path))
            {
                var hostNameIndex = 0;
                var keyIndex = 0;
                var valueIndex = 1;
                Regex regex = new Regex(this.Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                while (!reader.EndOfStream)
                {
                    var address = reader.ReadLine();
                    if (regex.IsMatch(address))
                    {
                        var url = address.Split(this.separators).Skip(1).Where(a => a.Length > 0).ToArray();
                        var hostName = url[hostNameIndex];
                        var segments = url.Skip(1).Where(a => !a.Contains('=')).ToArray();
                        var parameters = url.Where(a => a.Contains('=')).ToDictionary(a => a.Split('=')[keyIndex], k => k.Split('=')[valueIndex]);
                        this.addresses.Add(new Address(hostName, segments, parameters));
                    }
                    else
                    {
                        logger.Warning($"Wrong url-address: {address}");
                    }
                }
            }

            return this.addresses.ToArray();
        }
    }
}
