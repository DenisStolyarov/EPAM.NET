﻿using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> repository;

        public AccountService(IRepository<Account> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void OpenAccount(string fullName, AccountType type, IAccountNumberCreateService creator)
        {
            int firstNameIndex = 0;
            int lastNameIndex = 1;

            char[] separators = new char[] { ' ' };

            string[] names = fullName.Split(separators, 2) ?? throw new ArgumentNullException(nameof(fullName));

            int id = creator.GenerateId();

            Account account;

            switch (type)
            {
                case AccountType.Base:
                    account = new BaseAccount(id, names[firstNameIndex], names[lastNameIndex]);
                    break;
                case AccountType.Gold:
                    account = new GoldAccount(id, names[firstNameIndex], names[lastNameIndex]);
                    break;
                case AccountType.Silver:
                    account = new SilverAccount(id, names[firstNameIndex], names[lastNameIndex]);
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount(id, names[firstNameIndex], names[lastNameIndex]);
                    break;
                default:
                    throw new ArgumentException(nameof(type));
            }

            this.repository.Create(account);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return repository.GetAll();
        }

        public void WithdrawAccount(int id, decimal payment)
        {
            var account = repository.Get(id);
            if (account.Status == AccountStatus.Close)
            {
                throw new ArgumentException(nameof(account));
            }
            if (payment < 0)
            {
                throw new ArgumentException(nameof(payment));
            }
            if (payment > account.Amount)
            {
                throw new ArgumentException(nameof(payment));
            }

            account.Withdraw(payment);
            repository.Update(account);
        }

        public void DepositAccount(int id, decimal payment)
        {
            var account = repository.Get(id);
            if (account.Status == AccountStatus.Close)
            {
                throw new ArgumentException(nameof(account));
            }
            if (payment < 0)
            {
                throw new ArgumentException(nameof(payment));
            }

            account.Deposit(payment);
            repository.Update(account);
        }

        public void CloseAccount(int id)
        {
            var account = repository.Get(id);
            account.Close();
            repository.Update(account);
        }
    }
}
