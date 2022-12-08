namespace Book.Tests
{
    using System;
    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ConstructorSetsBookNameProperly()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            Assert.AreEqual("Harry Potter", book.BookName);
        }

        [Test]
        public void ConstructorSetsBookAuthorProperly()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            Assert.AreEqual("J.K. Rowling", book.Author);
        }

        [Test]
        public void ConstructorShouldInitilizeTheDictionary()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void FootNoteCountShouldReturnFootnoteCount()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            book.AddFootnote(1, "Text");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void InvalidNameShouldThrowException()
        {
            Book book;
            Assert.Throws<ArgumentException>(() =>
            book = new Book("", "J.K. Rowling")
            );
        }

        [Test]
        public void InvalidAuthorShouldThrowException()
        {
            Book book;
            Assert.Throws<ArgumentException>(() =>
            book = new Book("Harry Potter", null)
            );
        }

        [Test]
        public void AddingFootnoteTwiceShouldThrowException()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            book.AddFootnote(1, "Text");
            Assert.Throws<InvalidOperationException>(() =>
            book.AddFootnote(1, "Text")
            );
        }

        [Test]
        public void AddingFootnoteShouldAddFootnote()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            book.AddFootnote(1, "Text");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void FindFootnoteShouldReturnProperFootnote()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            book.AddFootnote(1, "Text");
            string footnoteResult = book.FindFootnote(1);
            Assert.AreEqual($"Footnote #{1}: Text", footnoteResult);
        }


        [Test]
        public void AlterNonExistingFootnoteShouldThrowException()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            Assert.Throws<InvalidOperationException>(() =>
            book.AlterFootnote(1, "Text")
            );
        }

        [Test]
        public void AlterFootnoteShouldWork()
        {
            Book book = new Book("Harry Potter", "J.K. Rowling");
            book.AddFootnote(1, "Text");
            string expectedFootnote = "Footnote #1: Text2";
            book.AlterFootnote(1, "Text2");
            Assert.AreEqual(expectedFootnote, book.FindFootnote(1));
        }
    }
}