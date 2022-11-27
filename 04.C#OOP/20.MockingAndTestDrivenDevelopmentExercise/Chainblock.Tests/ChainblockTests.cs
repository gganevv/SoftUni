namespace Chainblock.Tests
{
    using Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Linq;

    [TestFixture]
    public class ChainblockTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitilizeTransactions()
        {
            var chainblock = new Chainblock();
            chainblock.Add(new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500));
            Assert.That(chainblock.Count, Is.EqualTo(1));
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfSameTransactionIsPassed()
        {
            var chainblock = new Chainblock();
            var transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() =>
            chainblock.Add(transaction)
            , "Transaction already exists!");
        }

        [Test]
        public void ChangeStatusShouldChangeStatusPropery()
        {
            var chainblock = new Chainblock();
            var transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);
            Assert.That(chainblock.GetById(1).Status, Is.EqualTo(TransactionStatus.Failed));
        }

        [Test]
        public void ChangeStatusShouldThrowExceptionIfTransactionDoesntExist()
        {
            var chainblock = new Chainblock();
            Assert.Throws<ArgumentException>(() => 
            chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed)
            , "No such transaction exists!");
        }

        [Test]
        public void ContainsWithTransactionShouldReturnTrueIfTransactionExists()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            chainblock.Add(tx);
            Assert.IsTrue(chainblock.Contains(tx));
        }

        [Test]
        public void ContainsWithTransactionShouldReturnFalseIfTransactionExists()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Assert.IsFalse(chainblock.Contains(tx));
        }

        [Test]
        public void ContainsWithIdShouldReturnTrueIfTransactionExists()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            chainblock.Add(tx);
            Assert.IsTrue(chainblock.Contains(1));
        }

        [Test]
        public void ContainsWithIdShouldReturnFalseIfTransactionExists()
        {
            var chainblock = new Chainblock();
            Assert.IsFalse(chainblock.Contains(1));
        }

        [TestCase(200, 1000)]
        [TestCase(100, 250)]
        [TestCase(1200, 1500)]
        public void GetAllinAmountRangeShouldReturnCollectionWithTransactions(decimal lo, decimal hi)
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);
            var result = chainblock.GetAllInAmountRange(lo, hi);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldThrowExceptionIfNoTransactions()
        {
            var chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetAllOrderedByAmountDescendingThenById()
            , "No such transaction exists!");
        }

        [TestCase(1500, 0)]
        [TestCase(500, 1)]
        [TestCase(100, 2)]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnProperCollection(decimal outAmount, int rank)
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);
            var result = chainblock.GetAllOrderedByAmountDescendingThenById().ToArray();
            Assert.That(result[rank].Amount, Is.EqualTo(outAmount));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowExceptionIfNoTransactionsExists()
        {
            var chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed)
            , "No such transaction exists!");
        }


        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnProperCollection()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Failed, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Failed, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);
            var resultCollection = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed).ToList();
            Assert.That(resultCollection.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowExceptionIfNoTransactionsExists()
        {
            var chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed)
            , "No such transaction exists!");
        }


        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnProperCollection()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Failed, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Failed, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);
            var resultCollection = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed).ToList();
            Assert.That(resultCollection.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetByIdShouldThrowExceptionIfNoTransaction()
        {
            var chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetById(1)
           , "No such transaction exists!");
        }

        [Test]
        public void GetByIdShouldReturnProperTransaction()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Failed, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Failed, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);

            Contracts.ITransaction resultTx = chainblock.GetById(2);
            Assert.That(resultTx.Id, Is.EqualTo(2));
        }


        [Test]
        public void GetByReciverAndAmountRangeShouldThrowExceptionIfNoTransaction()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Failed, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Failed, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);

            System.Collections.Generic.IEnumerable<ITransaction> resultTx;
            Assert.Throws<InvalidOperationException>(() =>
            resultTx = chainblock.GetByReceiverAndAmountRange("Bai Ivan", 100, 1000)
            , "No such transaction exists!");
        }

        [Test]
        public void GetByReciverAndAmountRangeShouldReturnProperCollection()
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Failed, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Failed, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);

            var resultTx = chainblock.GetByReceiverAndAmountRange("Ivan", 200, 1000).ToArray();
            Assert.That(resultTx[0].Id, Is.EqualTo(2));
        }

        [TestCase(1500, 0)]
        [TestCase(500, 1)]
        [TestCase(100, 2)]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnProperCollection(decimal outAmount, int rank)
        {
            var chainblock = new Chainblock();
            Transaction tx = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Ivan", 100);
            Transaction tx2 = new Transaction(2, TransactionStatus.Successfull, "Pesho", "Ivan", 500);
            Transaction tx3 = new Transaction(3, TransactionStatus.Successfull, "Pesho", "Ivan", 1500);
            chainblock.Add(tx);
            chainblock.Add(tx2);
            chainblock.Add(tx3);
            var result = chainblock.GetByReceiverOrderedByAmountThenById("Ivan").ToArray();
            Assert.That(result[rank].Amount, Is.EqualTo(outAmount));
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowExceptionIfNoTransaction()
        {
            var chainblock = new Chainblock();
            Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetByReceiverOrderedByAmountThenById("Az")
            , "No such transaction exists!");
        }
    }
}
