using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using NUnit;
using Moq;

namespace BLL.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        void GenerateNumberTest()
        {
            var numberMock = new Mock<IAccountNumberCreateService>();
            numberMock.Setup(a => a.GenerateId()).Returns(() => It.IsAny<int>());

            var numberGenerator = numberMock.Object;
            numberGenerator.GenerateId();
            numberMock.Verify(a => a.GenerateId());
        }

        [Test]
        void RepositoryTest()
        {
            var accountMock = new Mock<IRepository<Account>>();
            accountMock.Setup(a => a.Create(It.IsAny<Account>()));
            accountMock.Setup(a => a.Get(It.IsAny<int>())).Returns<int>((id) => (It.IsAny<Account>()));
            accountMock.Setup(a => a.Delete(It.IsAny<int>()));
            accountMock.Setup(a => a.Update(It.IsAny<Account>()));

            var account = accountMock.Object;
            account.Create(new BaseAccount(1, "Denis", "Stolyarov"));
            account.Get(1);
            account.Update(new BaseAccount(1, "Denis", "Ivanov"));
            account.Delete(1);
            accountMock.Verify();
        }

        [Test]
        void ServiceTest()
        {
            var servicetMock = new Mock<IAccountService>();
            servicetMock.Setup(a => a.OpenAccount(It.IsAny<string>(), It.IsAny<AccountType>(), It.IsAny<IAccountNumberCreateService>()));
            servicetMock.Setup(a => a.CloseAccount(It.IsAny<int>()));
            servicetMock.Setup(a => a.DepositAccount(It.IsAny<int>(), It.IsAny<decimal>()));
            servicetMock.Setup(a => a.WithdrawAccount(It.IsAny<int>(), It.IsAny<decimal>()));

            var service = servicetMock.Object;
            service.OpenAccount("Denis Stolyarov", AccountType.Platinum, new AccountNumberCreator());
            service.DepositAccount(1, 100);
            service.WithdrawAccount(1, 50);
            service.CloseAccount(1);
            servicetMock.Verify();
        }
    }
}
