// Written by Dr. Shane Wilson.
// The author licenses this file to you under the MIT license.
// See the LICENSE file in the solution root for more information.
using BankingTDD.Models;

namespace BankingTests
{
    public class BankAccountWithdrawalTests
    {
        [Fact]
        //<nameofmethod being tested>
        //The scenario being tested
        // The expected behaviour when the scenario is invoked

        public void MakeWithdrawal_ValidAmount_ChangesBalance()
        {
            // AAA Unit testing
            // Arrange - the data we need for the test
            BankAccount testAccount = new BankAccount("1454", "Shane", 10.0m);
            decimal withdrawalAmount = -1.0m;
            decimal expectedResult = 9.0m;

            // Act - invoke the method we are testing
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test withdrawal");

            // Assert - expected result = actual result
            Assert.Equal(expectedResult, testAccount.Balance, 2);
        }

        [Fact]
        public void MakeWithdrawal_InValidAmount_BalanceUnchanged()
        {
            // AAA Unit testing
            // Arrange - the data we need for the test
            BankAccount testAccount = new BankAccount("1454", "Shane", 10.0m);
            decimal withdrawalAmount = -20.0m;
            //decimal expectedResult = 9.0m;

            // Act and assert
            Assert.Throws<ArgumentException>(() => testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test withdrawal"));

            // Assert - expected result = actual result
            //Assert.Equal(expectedResult, testAccount.Balance, 2);
        }

        [Theory]
        [InlineData("1454", "Shane", 40.0, -20, 20)]
        [InlineData("1454", "Shane", 100.0, -20, 80)]
        [InlineData("1454", "Shane", 500.0, -250, 250)]
        [InlineData("1454", "Shane", 5000.0, -2500, 2500)]
        public void MakeWithdrawals_ValidAmount_ChangesBalance(string accNumber, string owner,
            decimal startingBalance, decimal withdrawalAmount, decimal expectedBalance)
        {
            // Arrange - the data we need for the test
            BankAccount testAccount = new BankAccount(accNumber, owner, startingBalance);
            
   

            // Act - invoke the method we are testing
            testAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, "Test withdrawal");

            // Assert - expected result = actual result
            Assert.Equal(expectedBalance, testAccount.Balance, 2);
        }
    }
}
