namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book("It", "Stephen King");
            book.AddFootnote(10, "text");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestBookNamePropertyShouldThrowExceptionWhenStringIsNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Ivan Vazov");
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestAuthorPropertyShouldThrowExceptionWhenStringIsNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Under the yoke", author);
            });
        }

        [Test]
        public void TestConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(book);
            Assert.AreEqual("It", book.BookName);
            Assert.AreEqual("Stephen King", book.Author);
        }

        [Test]
        public void TestAddFootnoteMethodShouldThrowExceptionWhenFootnoteIsAlreadyAdded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(10, "otherText");
            });
        }

        [Test]
        public void TestFootnoteCountShouldWorkCorrectly()
        {
            book.AddFootnote(5, "otherText");

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]
        public void TestFindFootnoteMethodShouldThrowExceptionWhenFootnoteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(5);
            });
        }

        [Test]
        public void TestFindFootnoteMethodShouldWorkCorrectly()
        {
            string actualFootnote = book.FindFootnote(10);

            Assert.AreEqual("Footnote #10: text", actualFootnote);
        }

        [Test]
        public void TestAlterFootnoteMethodShouldThrowExceptionWhenFootnoteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(5, "someText");
            });
        }

        [Test]
        public void TestAlterFootnoteMethodShouldWorkCorrectly()
        {
            book.AlterFootnote(10, "newText");
            string actualFootnote = book.FindFootnote(10);

            Assert.AreEqual("Footnote #10: newText", actualFootnote);
        }
    }
}