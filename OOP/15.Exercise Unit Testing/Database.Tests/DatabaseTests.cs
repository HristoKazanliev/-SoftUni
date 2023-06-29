namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(1, 5)]
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddElementsWhileLessThan16(int start, int end)
        {
            var elements = Enumerable.Range(start, end).ToArray();
            Database database = new Database(elements);

            Assert.AreEqual(end, database.Count);
        }

        [Test]
        [TestCase(1, 17)]
        public void ConstructorShouldThrowExceptionWithMoreThan16(int start, int end)
        {
            var elements = Enumerable.Range(start, end).ToArray();
           
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(elements);
            });
        }

        [Test]
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(16)]
        public void AddMethodShouldAddNewItemWhileCountLessThan16(int count)
        {
            Database database = new Database();

            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWithMoreThan16()
        {
            var elements = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(elements);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(1);
            });
        }

        [Test]
        [TestCase(16)]
        [TestCase(1)]
        public void RemoveMethodShouldWorkCorrectly(int count)
        {
            var elements = Enumerable.Range(1, count).ToArray();
            Database database = new Database(elements);

            database.Remove();

            Assert.AreEqual(count-1, database.Count);
        }


        [Test]
        public void RemoveMethodShouldThrowExceptionWith0Count()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void FetchMethodShouldWorkCorrectly()
        {
            Database database = new Database(1, 2, 3);
            database.Add(4);
            database.Add(5);
            database.Remove(); 

            int[] fetchedArr = database.Fetch();
            int[] expectedArr = new int[] { 1, 2, 3, 4};

            Assert.AreEqual(expectedArr, fetchedArr);
        }
    }
}
