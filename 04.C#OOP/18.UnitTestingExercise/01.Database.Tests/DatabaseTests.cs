using NUnit.Framework;
using System;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorCanBeInitializedWithountData()
        {
            Database database = new Database();
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorCanBeInitializedWithMaxData()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.That(database.Count, Is.EqualTo(16));
        }

        [Test]
        public void ConstructorCannotBeInitializedWithMoreThanMaxData()
        {
            Database database; 
            Assert.Throws<InvalidOperationException>(() =>
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)
                );
        }

        [Test]
        public void CounterIncrements()
        {
            Database database = new Database();
            database.Add(1);
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void CounterDecrements()
        {
            Database database = new Database(1);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddMethodAddsProperElement()
        {
            Database database = new Database();
            database.Add(1);
            int[] testArr = new int[] { 1 };
            CollectionAssert.AreEqual(database.Fetch(), testArr);
        }

        [Test]
        public void AddMethodCannotAddMoreThan16Elements()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(17)
                );
        }

        [Test]
        public void RemoveMethodRemoveProperElement()
        {
            Database database = new Database(1, 2);
            database.Remove();
            int[] testArr = new int[] { 1 };
            CollectionAssert.AreEqual(database.Fetch(), testArr);
        }

        [Test]
        public void CannotRemoveMakeDatabaseNegative()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove()
                );
        }

        [Test]
        public void FetchMethodReturnTheProperArray()
        {
            Database database = new Database(1, 2);
            int[] testArr = new int[] { 1, 2 };
            CollectionAssert.AreEqual(database.Fetch(), testArr);
        }
    }
}