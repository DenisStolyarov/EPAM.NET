using System;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public BaseAccount(int accountNumber, string firstName, string lastName) 
            : base (accountNumber,firstName,lastName)
        {
            this.Type = AccountType.Base;
        }

        protected override void GetBonus(decimal payment, bool deposit)
        {
            if (deposit)
            {
                this.BonusCoints += (int)Math.Round((double)payment / 10);
            }
            else
            {
                this.BonusCoints -= (int)Math.Round((double)payment / 100);
            }
        }
    }
}
