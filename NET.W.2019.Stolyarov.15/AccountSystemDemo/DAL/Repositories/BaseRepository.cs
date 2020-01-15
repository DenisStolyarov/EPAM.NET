using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class BaseRepository : IRepository<Account>
    {
        private readonly AccountContext db = new AccountContext();

        public void Create(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var remove = Get(id);

            db.Entry(remove).State = EntityState.Deleted; ;
            db.SaveChanges();
        }

        public Account Get(int id)
        {
            return db.Accounts.First((a) => a.AccountNumber.Equals(id));
        }

        public IEnumerable<Account> GetAll()
        {
            var accounts = db.Accounts.ToList();
            return accounts;
        }

        public void Update(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var find = Get(account.AccountNumber);
            find = account;
            db.SaveChanges();
        }
    }
}
