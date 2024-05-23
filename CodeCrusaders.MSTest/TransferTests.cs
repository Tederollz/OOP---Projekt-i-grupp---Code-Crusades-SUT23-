using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace CodeCrusaders.MSTest
{
    [TestClass]
    public class TransferTests
    {

        //Test för att kontrollera att en överföring med negativt belopp retunerar false
        [TestMethod]
        [Description("Test that returns false when the transfer amount is negative")]
        public void WhenIsValidTransferAmount_NegativeAmount_ShouldReturnFalse()
        {
            //Arrange
            decimal amount = -100m;

            //Act
            bool result = Transfer.IsValidTransferAmount(amount);

            //Assert
            Assert.IsFalse(result);
        }

        //Test för att kontrollera att en överföring med belopp på 0 retunerar false
        [TestMethod]
        [Description("Test that returns false when the transfer amount is zero")]
        public void WhenIsValidTransferAmount_ZeroAmount_ShouldReturnFalse()
        {
            //Arrange
            decimal amount = 0;

            //Act
            bool result = Transfer.IsValidTransferAmount(amount);

            //Assert
            Assert.IsFalse(result);
        }

        //Test för att kontrollera att en överföring med positivt belopp retunerar true
        [TestMethod]
        [Description("Test that returns true when the transfer amount is positive")]
        public void WhenIsValidTransferAmount_PositiveAmount_ShouldReturnTrue()
        {
            //Arrange
            decimal amount = 100m;

            //Act
            bool result = Transfer.IsValidTransferAmount(amount);

            //Assert
            Assert.IsTrue(result);
        }

        //Test som retunerar false om man försöker föra över mer pengar än vad som finns tillgänligt på kontot.
        [TestMethod]
        [Description("Test that returns false if the transfer amount is greater the the balance")]
        public void WhenTransferMoney_NotEnoughMoney_ShouldReturnFalse()
        {
            //Arrange
            var sourceAccount = new Accounts("Source", 100, "SEK");
            var destinationAccount = new Accounts("Destination", 200, "SEK");
            UserContext.CurrentUser = new User("testUser", "1234", false)
            {
                Accounts = new List<Accounts> { sourceAccount, destinationAccount }
            };

            //Act
            decimal amount = 150;
            bool isTransferSuccessful = Transfer.IsValidTransferAmount(amount) && sourceAccount.Balance >= amount;

            //Assert
            Assert.IsFalse(isTransferSuccessful);
        }

        //Test för att kontrollera att valutakonverteringen fungerar korrekt vid överföring
        [TestMethod]
        [Description("Test to controll the currencies convertion")]
        public void WhenTransferMoney_DifferentCurrencies_ShouldConvertCorrectly()
        {
            //Arrange
            var sourceAccount = new Accounts("Source", 1000, "SEK");
            var destinationAccount = new Accounts("Destination", 100, "USD");
            UserContext.CurrentUser = new User("testUser", "1234", false)
            {
                Accounts = new List<Accounts> { sourceAccount, destinationAccount }
            };
            ExchangeRate.CurrentRate = 0.1m;

            //Act
            decimal amount = 100;
            if (Transfer.IsValidTransferAmount(amount) && sourceAccount.Balance >= amount)
            {
                sourceAccount.Balance -= amount;
                decimal convertedAmount = amount * ExchangeRate.CurrentRate;
                destinationAccount.Balance += convertedAmount;
            }

            //Assert
            Assert.AreEqual(900, sourceAccount.Balance);
            Assert.AreEqual(110, destinationAccount.Balance);
        }

    }
}
