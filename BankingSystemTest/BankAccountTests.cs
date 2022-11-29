using BankingSystem;
using System;
using NUnit.Framework;

namespace BankingSystemTest
{
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount(100000);
        }

        //Boundary Value Analysis

        [Test]
        public void Depositing_Min_Amount()
        {
            string actualOutput = account.Deposit(0);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_Just_Above_Min_Amount()
        {
            string actualOutput = account.Deposit(1);

            string expectedOutput = "successful transaction, current balance: " + 100001;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_Just_Below_Min_Amount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-1));
        }

        [Test]
        public void Depositing_Max_Amount()
        {
            string actualOutput = account.Deposit(5000000);

            string expectedOutput = "successful transaction, current balance: " + 5100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_Just_Below_Max_Amount()
        {
            string actualOutput = account.Deposit(4999999);

            string expectedOutput = "successful transaction, current balance: " + 5099999;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_Just_Above_Max_Amount()
        {
            string actualOutput = account.Deposit(5000001);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_Nominal_Value_Amount()
        {
            string actualOutput = account.Deposit(2500000);

            string expectedOutput = "successful transaction, current balance: " + 2600000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Min_Amount()
        {
            string actualOutput = account.Withdraw(0);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Just_Above_Min_Amount()
        {
            string actualOutput = account.Withdraw(1);

            string expectedOutput = "successful transaction, current balance: " + 99999;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Just_Below_Min_Amount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-1));
        }

        [Test]
        public void Withdraw_Max_Amount()
        {
            string actualOutput = account.Withdraw(5000000);

            string expectedOutput = "not enough balance, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Just_Below_Max_Amount()
        {
            string actualOutput = account.Withdraw(4999999);

            string expectedOutput = "not enough balance, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Just_Above_Max_Amount()
        {
            string actualOutput = account.Withdraw(5000001);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Nominal_Value_Amount()
        {
            string actualOutput = account.Withdraw(2500000);

            string expectedOutput = "not enough balance, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        // Decision table

        [Test]
        public void Depositing_Negative_Amount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-10000));
        }

        [Test]
        public void Depositing_Zero_Amount()
        {
            string actualOutput = account.Deposit(0);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_Less_Than_Balance_Subtract_Amount()
        {
            string actualOutput = account.Deposit(20000);

            string expectedOutput = "successful transaction, current balance: " + 120000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_More_Than_Balance_Subtract_Amount()
        {
            string actualOutput = account.Deposit(80000);

            string expectedOutput = "successful transaction, current balance: " + 180000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_More_Than_Balance_Amount()
        {
            string actualOutput = account.Deposit(200000);

            string expectedOutput = "successful transaction, current balance: " + 300000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Depositing_Big_Amount()
        {
            string actualOutput = account.Deposit(6000000);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Negative_Amount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-10000));
        }

        [Test]
        public void Withdraw_Zero_Amount()
        {
            string actualOutput = account.Withdraw(0);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Less_Than_Balance_Subtract_Amount()
        {
            string actualOutput = account.Withdraw(20000);

            string expectedOutput = "successful transaction, current balance: " + 80000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_More_Than_Balance_Subtract_Amount()
        {
            string actualOutput = account.Withdraw(80000);

            string expectedOutput = "not enough balance, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_More_Than_Balance_Amount()
        {
            string actualOutput = account.Withdraw(200000);

            string expectedOutput = "not enough balance, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Big_Amount()
        {
            string actualOutput = account.Withdraw(6000000);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        // Conditional Tests (Branch Coverage Criterion)

        [Test]
        public void Deposit_C2_Case_1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-10000));
        }

        [Test]
        public void Deposit_C2_Case_2()
        {
            string actualOutput = account.Deposit(6000000);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Deposit_C2_Case_3()
        {
            string actualOutput = account.Deposit(200000);

            string expectedOutput = "successful transaction, current balance: " + 300000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_C2_Case_1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-10000));
        }

        [Test]
        public void Withdraw_C2_Case_2()
        {
            string actualOutput = account.Withdraw(6000000);

            string expectedOutput = "failed transaction, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_C2_Case_3()
        {
            string actualOutput = account.Withdraw(200000);

            string expectedOutput = "not enough balance, current balance: " + 100000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_C2_Case_4()
        {
            string actualOutput = account.Withdraw(20000);

            string expectedOutput = "successful transaction, current balance: " + 80000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        //All-c-uses/some-p-use Testing

        [Test]
        public void Deposit_Du_pair_1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-10000));
        }

        [Test]
        public void Deposit_Du_pair_2()
        {
            string actualOutput = account.Deposit(50000);

            string expectedOutput = "successful transaction, current balance: " + 150000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Withdraw_Du_pair_1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-10000));
        }

        [Test]
        public void Withdraw_Du_pair_2()
        {
            string actualOutput = account.Withdraw(20000);

            string expectedOutput = "successful transaction, current balance: " + 80000;

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}