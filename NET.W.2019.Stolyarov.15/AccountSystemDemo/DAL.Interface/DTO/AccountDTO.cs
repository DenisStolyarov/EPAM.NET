using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    class AccountDTO
    {
        public int AccountNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Amount { get; }

        public AccountDTO(int accountNumber, string firstName, string lastName, decimal amount)
        {
            this.AccountNumber = accountNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Amount = amount;
        }
    }
}
