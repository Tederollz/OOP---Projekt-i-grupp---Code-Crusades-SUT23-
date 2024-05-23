using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System.Collections.Generic;
using test;

namespace CodeCrusaders.MSTest
{
    [TestClass]
    public class CheckingAccountTests
    {

        //En simpel Setup-metod som körs innan varje test. Skapar en användare med två konton.
        [TestInitialize]
        public void Setup()
        {
            UserContext.CurrentUser = new User("JohnDoe", "1234", false)
            {
                Accounts =
                {
                    new Accounts("Lönekonto", 1000, "SEK"),
                    new Accounts("Checking", 500, "USD")
                }
            };
        }

        //Test som kontrollerar att ett konto skapas korrekt med giltlig input.
        [TestMethod]
        [Description("Test for creating an account with valid input")]
        public void WhenCreateAccountIsCalled_WithValidInput_ShouldCreateAccount()
        {
            //Arrange - skapar testdata
            string name = "My Checking Account";
            decimal balance = 1000m;
            string currency = "SEK";


            //Act - anropar metoden som ska testas med testdatan ovan som inparametrar.
            bool result = CheckingAccount.TryCreateAccount(name, balance, currency, out var account);


            //Assert - kontrollerar att resultatet är som förväntat.
            Assert.IsTrue(result);
            Assert.IsNotNull(account);
            Assert.AreEqual(name, account.Name);
            Assert.AreEqual(balance, account.Balance);
            Assert.AreEqual(currency, account.Currency);
        }

        //Test som kontrollerar att default name används om inte namn anges vid skapande av konto
        [TestMethod]
        [Description("Test for creating an account with an empty name uses default name")]
        public void WhenCreateAccountIsCalled_WithEmptyName_ShouldUseDefaultName()
        {
            //Arrange
            string name = "";
            decimal balance = 1000m;
            string currency = "SEK";
            string defaultAccountName = "Checking Account";

            //Act
            bool result = CheckingAccount.TryCreateAccount(name, balance, currency, out var account);

            //Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(account);
            Assert.AreEqual(defaultAccountName, account.Name);
            Assert.AreEqual(balance, account.Balance);
            Assert.AreEqual(currency, account.Currency);
        }

        //Test som kontrollerar att ett konto inte skapas med negativt saldo
        [TestMethod]
        [Description("Test creating an account with a negative balance fails")]
        public void WhenCreateAccountIsCalled_WithNegativeBalance_ShouldFail()
        {
            //Arrange
            string name = "My Checking Account";
            decimal balance = -1000m;
            string currency = "SEK";

            //Act
            bool result = CheckingAccount.TryCreateAccount(name, balance, currency, out var account);

            //Assert
            Assert.IsFalse(result);
            Assert.IsNull(account);
        }

        //Test som kontrollerar att att konto inte skapas med ogiltlig valuta
        [TestMethod]
        [Description("Test creating an account with an invalid currency fails")]
        public void WhenCreateAccountIsCalled_WithInvalidCurrency_ShouldFail()
        {
            //Arrange
            string name = "My Checking Account";
            decimal balance = 1000m;
            string currency = "EUR";

            //Act
            bool result = CheckingAccount.TryCreateAccount(name, balance, currency, out var account);

            //Assert
            Assert.IsFalse(result);
            Assert.IsNull(account);
        }
    }
}
