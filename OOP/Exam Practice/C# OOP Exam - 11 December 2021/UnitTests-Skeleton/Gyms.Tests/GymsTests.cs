namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    public class GymsTests
    {
        private Gym gymTest;
        private Athlete athleteTest;

        [SetUp]
        public void SetUp()
        {
            gymTest = new Gym("Gym",1);
            athleteTest = new Athlete("Athlete");
        }

        [Test]
        public void TestIsAthleteConstructorWorkingCorrectly()
        {
            Athlete athlete = new Athlete("Ivan");

            Assert.AreEqual("Ivan", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestNamePropertyShouldThrowExceptionWhenValueIsBNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 5);
            });
        }

        [Test]
        public void TestCapacityPropertyShouldThrowExceptionWhenValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("gym", -1);
            });
        }

        [Test]
        public void TestIsGymConstructorWorkingCorrectly()
        {
            Gym gym = new Gym("Ivan", 5);

            Assert.AreEqual("Ivan", gym.Name);
            Assert.AreEqual(5, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void TestAddAthleteShouldThrowExceptionIfCapacityIsExceeded()
        {
            gymTest.AddAthlete(athleteTest);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gymTest.AddAthlete(athleteTest);
            });
        }

        [Test]
        public void TestAddAthleteShouldWorkCorrectly()
        {
            gymTest.AddAthlete(athleteTest);

            Assert.AreEqual(1, gymTest.Count);
        }

        [Test]
        public void TestRemoveAthleteShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                gymTest.RemoveAthlete("Ivan");
            });
        }

        [Test]
        public void TestRemoveAthleteShouldWorkCorrectly()
        {
            gymTest.AddAthlete(athleteTest);
            gymTest.RemoveAthlete("Athlete");

            Assert.AreEqual(0, gymTest.Count);
        }

        [Test]
        public void InjureMethodShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                gymTest.InjureAthlete("Gosho");
            });
        }

        [Test]
        public void InjureMethodShouldWorkCorrectly()
        {
            gymTest.AddAthlete(athleteTest);
            gymTest.InjureAthlete("Athlete");
            var injuredAthlete = gymTest.InjureAthlete("Athlete");

            Assert.AreEqual(true, injuredAthlete.IsInjured);
            Assert.AreEqual("Athlete", injuredAthlete.FullName);
        }

        [Test]
        public void ReportMethodShouldWorkCorrectly()
        {
            Gym gym1 = new Gym("Gym1", 5);
            gym1.AddAthlete(athleteTest);
            gym1.AddAthlete(new Athlete("Mitko"));
            gym1.AddAthlete(new Athlete("Gosho"));

            gym1.InjureAthlete("Mitko");
            string gymReport = gym1.Report();

            Assert.AreEqual("Active athletes at Gym1: Athlete, Gosho", gymReport);
        }
    }
}
