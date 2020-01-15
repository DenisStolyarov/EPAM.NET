using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class FakeRepository : IRepository<Account>
    {
        private readonly List<Account> accounts = new List<Account>();

        public void Create(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            accounts.Add(account);
        }

        public void Delete(int id)
        {
            var remove = Get(id);

            accounts.Remove(remove);
        }

        public Account Get(int id)
        {
            return accounts.Find((a) => a.AccountNumber.Equals(id));
        }

        public IEnumerable<Account> GetAll()
        {
            return accounts.ToArray();
        }

        public void Update(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var find = Get(account.AccountNumber);
            accounts.Remove(find);
            accounts.Add(account);
        }
    }
}
