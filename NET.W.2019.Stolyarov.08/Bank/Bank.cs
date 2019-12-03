// <copyright file="Bank.cs" company="Epam">
//     Copyright (c) Epam. All rights reserved.
// </copyright>
// <author>Denis Stolyarov</author>
namespace Bank
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Service for work with user accounts
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Unique identificator
        /// </summary>
        protected static uint id = 0;

        /// <summary>
        /// Account container
        /// </summary>
        private List<BankAccount> accounts = new List<BankAccount>();

        /// <summary>
        /// Set of privileges
        /// </summary>
        public enum Variety
        {
            /// <summary>
            /// Low level
            /// </summary>
            Base,

            /// <summary>
            /// Average level
            /// </summary>
            Gold,

            /// <summary>
            /// High level
            /// </summary>
            Platinum
        }
        
        /// <summary>
        /// Returns copy of container
        /// </summary>
        /// <returns></returns>
        public BankAccount[] GetBankAccounts()
        {
            return this.accounts.ToArray();
        }

        /// <summary>
        /// Creates and add new account
        /// </summary>
        /// <param name="firstName">User name</param>
        /// <param name="lastName">User surname</param>
        /// <param name="variety">Set of privileges</param>
        /// <returns>Generated id</returns>
        public virtual uint AddAccount(string firstName, string lastName, Variety variety)
        {
            if (firstName == null || lastName == null)
            {
                throw new NullReferenceException();
            }

            id = this.Generateid(id);

            var account = new BankAccount
            {
                AccountNumber = id,
                FirstName = firstName,
                LastName = lastName,
                Amount = 0,
                Bonus = 0,
                Type = variety,
            };

            this.accounts.Add(account);

            return id;
        }

        /// <summary>
        /// Remove account
        /// </summary>
        /// <param name="id">User id</param>
        public virtual void CloseAccount(uint id)
        {
            int position = this.IsExist(id);

            if (position == -1)
            {
                throw new ArgumentException();
            }

            this.accounts.Remove(this.accounts[position]);
        }

        /// <summary>
        /// Replenishes balance and bonus points
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payment"></param>
        public virtual void Replenish(uint id, decimal payment)
        {
            if (payment < 0)
            {
                throw new ArgumentException();
            }

            int position = this.IsExist(id);

            if (position == -1)
            {
                throw new ArgumentException();
            }

            this.accounts[position].Amount += payment;
            this.accounts[position].Bonus += this.GetBonus(position, payment);
        }

        /// <summary>
        /// Reduces amount money and bonus points
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payment"></param>
        public virtual void Debit(uint id, decimal payment)
        {
            if (payment < 0)
            {
                throw new FormatException();
            }

            int position = this.IsExist(id);

            if (position == -1)
            {
                throw new ArgumentException();
            }

            if (this.accounts[position].Amount <= payment)
            {
                new ArgumentException();
            }

            this.accounts[position].Amount -= payment;

            if (this.accounts[position].Bonus > 0)
            {
                this.accounts[position].Bonus--;
            }
        }

        /// <summary>
        /// Write all records in file
        /// </summary>
        /// <param name="path">File path</param>
        public virtual void Save(string path)
        {
            if (this.accounts.Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Write(this.accounts, path);
        }

        /// <summary>
        /// Gets records from file
        /// </summary>
        /// <param name="path">File path</param>
        public virtual void Load(string path)
        {
            if (this.accounts.Count != 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.accounts = this.Read(path);
        }

        /// <summary>
        /// Remove all records
        /// </summary>
        public virtual void Clear()
        {
            this.accounts = new List<BankAccount>();
        }
        
        /// <summary>
        /// Generates unique identificator
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual uint Generateid(uint id)
        {
            return ++id;
        }

        /// <summary>
        /// Bonus algorithm
        /// </summary>
        /// <param name="position">Account position</param>
        /// <param name="payment">Money used</param>
        /// <returns></returns>
        protected virtual int GetBonus(int position, decimal payment)
        {
            int factor = 0;

            switch (this.accounts[position].Type)
            {
                case Variety.Base:
                    factor = 1;
                    break;
                case Variety.Gold:
                    factor = 2;
                    break;
                case Variety.Platinum:
                    factor = 3;
                    break;
            }

            if (payment < 10)
            {
                factor *= 1;
            }
            else if (payment < 100)
            {
                factor *= 2;
            }
            else
            {
                factor *= 3;
            }

            return factor;
        }

        /// <summary>
        /// Writes all records
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="path"></param>
        private void Write(List<BankAccount> accounts, string path)
        {
            if (accounts == null || path == null)
            {
                throw new NullReferenceException();
            }

            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    foreach (var account in accounts)
                    {
                        writer.Write(account.AccountNumber);
                        writer.Write(account.Amount);
                        writer.Write(account.FirstName);
                        writer.Write(account.LastName);
                        writer.Write(account.Bonus);
                        writer.Write(account.Type.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Gets records
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<BankAccount> Read(string path)
        {
            if (path == null)
            {
                throw new NullReferenceException();
            }

            List<BankAccount> accounts = new List<BankAccount>();

            using (FileStream file = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(file))
                {
                    while (reader.PeekChar() > -1)
                    {
                        uint accountNumber = reader.ReadUInt32();

                        decimal amount = reader.ReadDecimal();

                        string firstName = reader.ReadString();

                        string lastName = reader.ReadString();

                        int bonus = reader.ReadInt32();

                        string type = reader.ReadString();

                        var account = new BankAccount
                        {
                            AccountNumber = accountNumber,
                            FirstName = firstName,
                            LastName = lastName,
                            Amount = amount,
                            Bonus = bonus,
                            Type = this.GetVariety(type),
                        };

                        accounts.Add(account);
                    }
                }
            }

            return accounts;
        }

        /// <summary>
        /// Get account type from string
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Variety GetVariety(string type)
        {
            switch (type)
            {
                case "Base":
                    return Variety.Base;
                case "Gold":
                    return Variety.Gold;
                case "Platinum":
                    return Variety.Platinum;
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Check unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int IsExist(uint id)
        {
            int count = 0;

            foreach (var item in this.accounts)
            {
                if (item.AccountNumber == id)
                {
                    return count;
                }

                count++;
            }

            return -1;
        }

        /// <summary>
        /// Realize template for this bank
        /// </summary>
        public class BankAccount : Account
        {
            /// <summary>
            /// Set of privileges
            /// </summary>
            public Variety Type;

            /// <summary>
            /// Gets or sets bonus point
            /// </summary>
            public virtual int Bonus { get; set; }

            /// <summary>
            /// Return user information
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return $"{this.AccountNumber}, {this.FirstName}, {this.LastName}, {this.Amount}$, {this.Bonus}, {this.Type.ToString()}";
            }
        }
    }
}
