using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
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
        public void ConstructorCanBeInitilizedWithSomeData()
        {
            Person person1 = new Person(1, "Pesho1");
            Person person2 = new Person(2, "Pesho2");
            Person person3 = new Person(3, "Pesho3");
            Person person4 = new Person(4, "Pesho4");
            Person[] people = new Person[4];
            people[0] = person1;
            people[1] = person2;
            people[2] = person3;
            people[3] = person4;
            Database database = new Database(people);
            Assert.That(database.Count, Is.EqualTo(4));
        }

        [Test]
        public void AddMethodIncrementsCounter()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodAddsProperData()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.That(database.FindByUsername("Ivan"), Is.EqualTo(person));
        }

        [Test]
        public void CannotAddPersonWithSameName()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            Person person2 = new Person(14, "Ivan");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => 
            database.Add(person2)
            );
        }

        [Test]
        public void CannotAddPersonWithSameId()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            Person person2 = new Person(13, "Pesho");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(person2)
                );
        }

        [Test]
        public void CannotAddMoreThan16People()
        {
            Database database = new Database();
            Person person1 = new Person(1, "Pesho1");
            Person person2 = new Person(2, "Pesho2");
            Person person3 = new Person(3, "Pesho3");
            Person person4 = new Person(4, "Pesho4");
            Person person5 = new Person(5, "Pesho5");
            Person person6 = new Person(6, "Pesho6");
            Person person7 = new Person(7, "Pesho7");
            Person person8 = new Person(8, "Pesho8");
            Person person9 = new Person(9, "Pesho9");
            Person person10 = new Person(10, "Pesho10");
            Person person11 = new Person(11, "Pesho11");
            Person person12 = new Person(12, "Pesho12");
            Person person13 = new Person(13, "Pesho13");
            Person person14 = new Person(14, "Pesho14");
            Person person15 = new Person(15, "Pesho15");
            Person person16 = new Person(16, "Pesho16");
            Person person17 = new Person(666, "FatalPesho");
            database.Add(person1);
            database.Add(person2);
            database.Add(person3);
            database.Add(person4);
            database.Add(person5);
            database.Add(person6);
            database.Add(person7);
            database.Add(person8);
            database.Add(person9);
            database.Add(person10);
            database.Add(person11);
            database.Add(person12);
            database.Add(person13);
            database.Add(person14);
            database.Add(person15);
            database.Add(person16);
            Assert.Throws<InvalidOperationException>(() =>
            database.Add(person17)
                );
        }

        [Test]
        public void RemoveMethodRemovesUser()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveMakeDatabaseNegative()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            database.Remove()
                );
        }

        [Test]
        public void FindByIdGetsProperPerson()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.That(database.FindById(13), Is.EqualTo(person));
        }

        [Test]
        public void FindByIdWithNEgativeIdThrowsException()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            database.FindById(-1)
                );
        }

        [Test]
        public void FindByIdWithNonExistingIdThrowsException()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            database.FindById(4)
                );
        }

        [Test]
        public void FindByNameGetsProperPerson()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.That(database.FindByUsername("Ivan"), Is.EqualTo(person));
        }

        [Test]
        public void FindByNameWithEmptyNameThrowsException()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.Throws<ArgumentNullException>(() =>
            database.FindByUsername(null)
                );
        }

        [Test]
        public void FindByNameWithNonExistingNameThrowsException()
        {
            Database database = new Database();
            Person person = new Person(13, "Ivan");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() =>
            database.FindByUsername("Ivo")
                );
        }
    }
}