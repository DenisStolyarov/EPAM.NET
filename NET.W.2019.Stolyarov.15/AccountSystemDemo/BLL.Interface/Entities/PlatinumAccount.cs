using System;

namespace BLL.Interface.Entities
{
    public class PlatinumAccount : Account
    {
        public PlatinumAccount(int accountNumber, string firstName, string lastName)
            : base(accountNumber, firstName, lastName)
        {
            this.Type = AccountType.Platinum;
        }

        protected override void GetBonus(decimal payment, bool deposit)
        {
            if (deposit)
            {
                this.BonusCoints += (int)Math.Round((double)payment / 4);
            }
            else
            {
                this.BonusCoints -= (int)Math.Round((double)payment / 300);
            }
        }
    }
}
