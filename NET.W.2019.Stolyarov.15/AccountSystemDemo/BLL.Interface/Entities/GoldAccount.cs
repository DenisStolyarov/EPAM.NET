using System;

namespace BLL.Interface.Entities
{
    public class GoldAccount : Account
    {
        public GoldAccount()
        {

        }

        public GoldAccount(int accountNumber, string firstName, string lastName)
            : base(accountNumber, firstName, lastName)
        {
            this.Type = AccountType.Gold;
        }

        protected override void GetBonus(decimal payment, bool deposit)
        {
            if (deposit)
            {
                this.BonusCoints += (int)Math.Round((double)payment / 6);
            }
            else
            {
                this.BonusCoints -= (int)Math.Round((double)payment / 200);
            }
        }
    }
}
