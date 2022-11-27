namespace Chainblock.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class TransactionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeIdProperly()
        {
            int expectedId = 1;
            var tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Assert.That(tx.Id, Is.EqualTo(expectedId));
        }

        [Test]
        public void ConstructorShouldInitializeTransactionStatusProperly()
        {
            var expectedStatus = TransactionStatus.Successfull;
            var tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Assert.That(tx.Status, Is.EqualTo(expectedStatus));
        }

        [Test]
        public void ConstructorShouldInitializeSenderProperly()
        {
            var expectedSender = "Pesho";
            var tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Assert.That(tx.From, Is.EqualTo(expectedSender));
        }

        [Test]
        public void ConstructorShouldInitializeReciverProperly()
        {
            var expectedReciver = "Ivan";
            var tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Assert.That(tx.To, Is.EqualTo(expectedReciver));
        }

        [Test]
        public void ConstructorShouldInitializeAmountProperly()
        {
            var expectedAmount = 500;
            var tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Assert.That(tx.Amount, Is.EqualTo(expectedAmount));
        }

        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(0)]
        public void ConstructorShouldThrowExceptionWithNegativeID(int id)
        {
            Transaction tx;
            Assert.Throws<ArgumentException>(() =>
            tx = new Transaction(id, TransactionStatus.Successfull, "Pesho", "Ivan", 500)
            , "Id cannot be zero or negative!");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void ConstructorShouldThrowExceptionWithInvalidSender(string from)
        {
            Transaction tx;
            Assert.Throws<ArgumentException>(() =>
            tx = new Transaction(1, TransactionStatus.Successfull, from, "Ivan", 500)
            , "Sender cannot be null or empty!");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void ConstructorShouldThrowExceptionWithInvalidReciver(string to)
        {
            Transaction tx;
            Assert.Throws<ArgumentException>(() =>
            tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", to, 500)
            , "Reciver cannot be null or empty!");
        }

        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(0)]
        public void ConstructorShouldThrowExceptionWithNegativeAmount(decimal amount)
        {
            Transaction tx;
            Assert.Throws<ArgumentException>(() =>
            tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", amount)
            , "Amount cannot be zero or negative!");
        }
    }
}