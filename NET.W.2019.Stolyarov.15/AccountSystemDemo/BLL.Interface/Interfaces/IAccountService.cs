using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenAccount(string name, AccountType type, IAccountNumberCreateService creator);
        void CloseAccount(int id);
        IEnumerable<Account> GetAllAccounts();
        void WithdrawAccount(int id, decimal payment);
        void DepositAccount(int id, decimal payment);
    }
}
