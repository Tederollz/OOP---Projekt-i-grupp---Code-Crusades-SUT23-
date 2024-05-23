using FluentAssertions;
using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCrusaders.MSTest
{
    [TestClass]
    public class StartTests
    {

        //Test för att kontrollera att Admin skapas korrekt
        [TestMethod]
        [Description("Test if admins is created")]
        public void WhenCreateListIsCalled_CustomerListShouldBeCreated_WithAdmin()
        {
            //Arrange
            Start.CreateList();

            //Act
            var excepted = Start.CustomerList.Find(u => u.Username == "Admin");
            var actual = "Admin";

            //Assert
            Assert.IsNotNull(excepted);
            Assert.AreEqual(actual, excepted.Username);
        }

        //Test för att kontrollerar att CustomerList inte är null efter att den skapats
        [TestMethod]
        [Description("Test if CustomerList is not null")]
        public void WhenCreateListIsCalled_CustomerListShouldNotBeNull()
        {
            //Arrange
            Start.CreateList();

            //Act
            var customerList = Start.CustomerList;

            //Assert
            customerList.Should().NotBeNull();
        }

        //Test för att kontrollera att 6 användare skapas i CustomerList
        [TestMethod]
        [Description("Test if the correct number of users are created")]
        public void WhenCreateListIsCalled_CustomerListShouldReturnSixUsers()
        {
            //Arrange
            Start.CreateList();

            //Act
            var expected = 6;
            var actual = Start.CustomerList.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
