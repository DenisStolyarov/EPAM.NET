using BLL.Interface.Interfaces;
using System;

namespace BLL.Interface.Entities
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public int GenerateId()
        {
            var random = new Random();
            var id = random.Next() + random.GetHashCode();
            return id;
        }
    }
}
