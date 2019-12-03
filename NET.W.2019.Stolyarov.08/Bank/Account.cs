// <copyright file="Account.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Bank
{
    /// <summary>
    /// Base template for user account
    /// </summary>
    public abstract class Account
    {
        /// <summary>
        /// Gets or sets user identificator
        /// </summary>
        public virtual uint AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets user name
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets user surname
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets money balance
        /// </summary>
        public virtual decimal Amount { get; set; }
    }
}