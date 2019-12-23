using System.Text;
namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        public int AccountNumber { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public decimal Amount { get; protected set; }
        public int BonusCoints { get; protected set; }
        public AccountType Type { get; protected set; }
        public AccountStatus Status { get; protected set; }

        protected abstract void GetBonus(decimal payment, bool deposit);

        public void Deposit(decimal payment)
        {
            this.Amount += payment;
            GetBonus(payment, true);
        }

        public void Withdraw(decimal payment)
        {
            this.Amount -= payment;
            GetBonus(payment, false);
        }

        public void Close()
        {
            this.Status = AccountStatus.Close;
        }

        public Account(int accountNumber, string firstName, string lastName)
        {
            this.AccountNumber = accountNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BonusCoints = 0;
            this.Amount = 0;
            this.Status = AccountStatus.Open;
        }

        public override string ToString()
        {
            var build = new StringBuilder();
            build.Append($"{this.AccountNumber}, ");
            build.Append($"{this.FirstName}, ");
            build.Append($"{this.LastName}, ");
            build.Append($"{this.Amount}, ");
            build.Append($"{this.BonusCoints}, ");
            build.Append($"{this.Type.ToString()}, ");
            build.Append($"{this.Status.ToString()}.");
            return build.ToString();
        }
    }

    public enum AccountType
    {
        Base,
        Gold,
        Silver,
        Platinum
    }

    public enum AccountStatus
    {
        Open,
        Close,
    }
}
