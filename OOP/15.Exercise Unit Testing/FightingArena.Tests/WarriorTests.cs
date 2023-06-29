namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void NamePropertyShouldThrowExceptionWhenDataIsNullOrEmpty(string data)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(data, 50, 50);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DamagePropertyShouldThrowExceptionWhenDataIsEqualOrLessThan0(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Warrior", damage, 50);
            });
        }

        [Test]
        public void HPPropertyShouldThrowExceptionWhenDataIsLessThan0()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Warrior", 50, -1);
            });
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Warrior", 50, 50);

            Assert.AreEqual("Warrior", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(50, warrior.HP);
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionWhenAttackingWarriorHPIsEqualOrLessThan30(int hp)
        {
            Warrior warrior1 = new Warrior("Warrior", 50, hp);
            Warrior warrior2 = new Warrior("Warrior", 50, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionWhenDefendingWarriorHPIsEqualOrLessThan30(int hp)
        {
            Warrior warrior1 = new Warrior("Warrior", 50, 50);
            Warrior warrior2 = new Warrior("Warrior", 50, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWhenAttackingWarriorHPIsLowerThanDefendingWarriorDamage()
        {
            Warrior warrior1 = new Warrior("Warrior", 50, 50);
            Warrior warrior2 = new Warrior("Warrior", 60, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [Test]
        public void AttackMethodShouldReduceDefenderHp()
        {
            Warrior warrior1 = new Warrior("Warrior", 50, 100);
            Warrior warrior2 = new Warrior("Warrior", 60, 100);

            warrior1.Attack(warrior2);

            Assert.AreEqual(50, warrior2.HP);
        }

        [Test]
        public void AttackMethodShouldReduceAttackerHp()
        {
            Warrior warrior1 = new Warrior("Warrior", 50, 100);
            Warrior warrior2 = new Warrior("Warrior", 60, 100);

            warrior1.Attack(warrior2);

            Assert.AreEqual(40, warrior1.HP);
        }

        [Test]
        public void AttackMethodShouldReduceDefenderHpTo0()
        {
            Warrior warrior1 = new Warrior("Warrior", 50, 100);
            Warrior warrior2 = new Warrior("Warrior", 60, 40);

            warrior1.Attack(warrior2);

            Assert.AreEqual(0, warrior2.HP);
        }
    }
}