// <copyright file="AddressWriter.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Address
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    /// <summary>
    /// Writes all addresses in file.
    /// </summary>
    public class AddressWriter
    {
        /// <summary>
        /// Logger for parsing.
        /// </summary>
        public Logger logger;

        /// <summary>
        /// Base path to file.
        /// </summary>
        public readonly string BasePath = "Addresses.xml";

        /// <summary>
        /// Addresses container.
        /// </summary>
        private readonly Address[] addresses;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressWriter"/> class. 
        /// </summary>
        /// <param name="addresses">Parsed addresses.</param>
        public AddressWriter(Address[] addresses)
        {
            this.addresses = addresses ?? throw new ArgumentNullException(nameof(addresses));
            this.Path = this.BasePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressWriter"/> class. 
        /// </summary>
        /// <param name="addresses">Parsed addresses.</param>
        /// <param name="path">Path to file.</param>
        public AddressWriter(Address[] addresses, string path)
        {
            this.addresses = addresses ?? throw new ArgumentNullException(nameof(addresses));
            this.Path = path ?? throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
            {
                throw new ArgumentException(nameof(path), "File not found.");
            }
        }

        /// <summary>
        /// Gets path to file.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Writes all addresses in xml format.
        /// </summary>
        public void WriteToXml()
        {
            XDocument document = new XDocument();
            XElement root = new XElement("urlAddresses");
            foreach (var address in this.addresses)
            {
                XElement block = new XElement("urlAddress");
                block.Add(new XElement("host", (new XAttribute("name", address.HostName))));
                if (address.Segments.Count > 0)
                {
                    XElement uri = new XElement("uri");
                    foreach (var segment in address.Segments)
                    {
                        uri.Add(new XElement("segment", segment));
                    }

                    block.Add(uri);
                }

                if (address.Parameters.Count > 0)
                {
                    XElement param = new XElement("parameters");
                    foreach (var parameter in address.Parameters)
                    {
                        param.Add(new XElement("parameter", new XAttribute("key", parameter.Key), new XAttribute("value", parameter.Value)));
                    }

                    block.Add(param);
                }

                root.Add(block);
            }

            document.Add(root);
            document.Save(this.Path);
        }
    }
}
