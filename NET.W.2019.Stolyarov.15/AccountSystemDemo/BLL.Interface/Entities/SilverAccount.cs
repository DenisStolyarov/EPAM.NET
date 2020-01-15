using System;

namespace BLL.Interface.Entities
{
    public class SilverAccount : Account
    {
        public SilverAccount()
        {

        }

        public SilverAccount(int accountNumber, string firstName, string lastName)
            : base(accountNumber, firstName, lastName)
        {
            this.Type = AccountType.Silver;
        }

        protected override void GetBonus(decimal payment, bool deposit)
        {
            if (deposit)
            {
                this.BonusCoints += (int)Math.Round((double)payment / 8);
            }
            else
            {
                this.BonusCoints -= (int)Math.Round((double)payment / 150);
            }
        }
    }
}
