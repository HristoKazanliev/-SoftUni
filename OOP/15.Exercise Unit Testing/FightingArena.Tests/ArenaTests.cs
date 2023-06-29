namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private Warrior warrior2;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior1 = new Warrior("Atacker", 50, 100);
            warrior2 = new Warrior("Deffender", 60, 100);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
        }

        [Test]
        public void ConstructorShouldCreateEmptyList()
        {
            arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfNameIsAlreadyThere()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior1);
            });
        }

        [Test]
        [TestCase("NotEnrolled1", "NotEnrolled2")]
        [TestCase("NotEnrolled1", "Atacker")]
        [TestCase("Atacker", "NotEnrolled1")]
        public void FightMethodShouldThrowExceptionIfWarriorIsNotEnrolled(string warrior1Name, string warrior2Name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(warrior1Name, warrior2Name);
            });
        }

        [Test]
        public void FightMethodShouldWorkCorrectly()
        {
            arena.Fight("Atacker", "Deffender");

            Assert.AreEqual(40 , warrior1.HP);
            Assert.AreEqual(50, warrior2.HP);
        }


    }
}
