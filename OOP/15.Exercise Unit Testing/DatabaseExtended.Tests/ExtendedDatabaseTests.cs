namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Text;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database twoPeopleDatabase;
        private Database sixteenPeopleDatabase; 

        [SetUp]
        public void SetUp()
        {
            Person[] twoPeople = new Person[2];
            for (int i = 0; i < 2; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hristo");
                sb.Append(i.ToString());

                twoPeople[i] = new Person(123 + i, sb.ToString());
            }

            twoPeopleDatabase = new Database(twoPeople);

            Person[] sixteenPeople = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hristo");
                sb.Append(i.ToString());

                sixteenPeople[i] = new Person(123 + i, sb.ToString());
            }

            sixteenPeopleDatabase = new Database(sixteenPeople);
        }

        [Test]
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(16)]
        public void ConstructorShouldAddLessOrEqualTo16(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hristo");
                sb.Append(i.ToString());
                people[i] = new Person(10 + i, sb.ToString());
            }

            Database database = new Database(people);

            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void ConstructorShouldThrowExceptionMoreThan16()
        {
            Person[] person = new Person[20];

            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hristo");
                sb.Append(i.ToString());
                person[i] = new Person(10 + i, sb.ToString());
            }

            Assert.Throws<ArgumentException>(()=>
            {
                Database database = new Database(person);
            });
        }

        [Test]
        public void AddMethodShouldThrowExceptionWithExistingPersonById()
        {
            Person person = new Person(124, "Hristo");

            Assert.Throws<InvalidOperationException>(() =>
            {
                twoPeopleDatabase.Add(person);
            });
        }

        [Test]
        public void AddMethodShouldThrowExceptionWithExistingPersonByName()
        {
            Person person = new Person(125, "Hristo0");

            Assert.Throws<InvalidOperationException>(() =>
            {
                twoPeopleDatabase.Add(person);
            });
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenCollectionIsMoreThan16()
        {
            Person person = new Person(123456, "Ico");

            Assert.Throws<InvalidOperationException>(() =>
            {
                sixteenPeopleDatabase.Add(person);
            });
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void RemoveMethodWorkingCorrectly()
        {
            for (int i = 0; i < 2; i++)
            {
                sixteenPeopleDatabase.Remove();
            }

            Assert.AreEqual(14, sixteenPeopleDatabase.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameMethodShouldThrowArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                twoPeopleDatabase.FindByUsername(name);
            });
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfNameIsLowerCase()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                twoPeopleDatabase.FindByUsername("hristo0");
            });
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfNameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                twoPeopleDatabase.FindByUsername("Mitko");
            });
        }

        [Test]
        public void FindByUsernameMethodShouldWorkCorrectly()
        {
            Person person = new Person(123, "Hristo0");
            Person resultPerson = twoPeopleDatabase.FindByUsername("Hristo0");
            Assert.AreEqual((person.Id, person.UserName), (resultPerson.Id, resultPerson.UserName));
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                twoPeopleDatabase.FindById(0);
            });
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdIsNotPositiveNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                twoPeopleDatabase.FindById(-10);
            });
        }

        [Test]
        public void FindByIdMethodShouldWorkCorrectly()
        {
            Person person = new Person(123, "Hristo0");
            Person resultPerson = twoPeopleDatabase.FindById(123);
            Assert.AreEqual((person.Id, person.UserName), (resultPerson.Id, resultPerson.UserName));
        }
    }
}