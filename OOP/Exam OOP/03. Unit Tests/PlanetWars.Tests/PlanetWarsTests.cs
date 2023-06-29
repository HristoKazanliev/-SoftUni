using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weaponTest;
            private Planet planetTest;

            [SetUp]
            public void SetUp()
            {
                weaponTest = new Weapon("weaponTest", 50, 5);
                planetTest = new Planet("planetTest", 150);
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-10)]
            public void TestPropertyPriceShouldThrowExceptionWithNegativePrice(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("weapon1", price, 3);
                });
            }

            [Test]
            public void TestIncreaseDestructionLevelMethodShouldWorkCorrectly()
            {
                Weapon weapon = new Weapon("weapon1", 20.5, 3);
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(4, weapon.DestructionLevel);
            }

            [Test]
            public void TestIsNuclearBoolTrue()
            {
                Weapon weapon = new Weapon("weapon1", 20.5, 10);

                Assert.AreEqual(true, weapon.IsNuclear);
            }

            [Test]
            public void TestIsNuclearBoolFalse()
            {
                Assert.AreEqual(false, weaponTest.IsNuclear);
            }

            [Test]
            [TestCase("")]
            [TestCase(null)]
            public void TestNamePropertyShouldThrowExceptionWithNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 50.5);
                });
            }

            [Test]
            public void TestBudgetPropertyShouldThrowExceptionWithNegativeBudget()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("planet1", -10.5);
                });
            }

            [Test]
            public void TestCollectionOfWeaponsCount()
            {
                Assert.AreEqual(0, planetTest.Weapons.Count);
            }

            [Test]
            public void TestAddWeaponShouldThrowExceptionWhenWeaponIsAlreadyAdded()
            {
                planetTest.AddWeapon(weaponTest);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetTest.AddWeapon(weaponTest);
                });
            }

            [Test]
            public void TestAddWeaponShouldWorkCorrectly()
            {
                planetTest.AddWeapon(weaponTest);

                Assert.AreEqual(1, planetTest.Weapons.Count);
            }

            [Test]
            public void TestMilitaryPowerRatio()
            {
                planetTest.AddWeapon(weaponTest);

                Assert.AreEqual(5, planetTest.MilitaryPowerRatio);
            }

            [Test]
            public void TestProfitMethodShouldWorkCorrectly()
            {
                planetTest.Profit(10.5);

                Assert.AreEqual(160.5 , planetTest.Budget);
            }

            [Test]
            public void TestSpendFundsShouldThrowException()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetTest.SpendFunds(200);
                });
            }

            [Test]
            public void TestSpendFundsShouldWorkCorrectly()
            {
                planetTest.SpendFunds(100);

                Assert.AreEqual(50, planetTest.Budget);
            }

            [Test]
            public void TestRemoveWeaponMethodShouldWorkCorrectly()
            {
                planetTest.AddWeapon(weaponTest);
                planetTest.RemoveWeapon("weaponTest");

                Assert.AreEqual("", planetTest.Weapons);
            }

            [Test]
            public void TestUpgradeWeaponMethodThrowsExceptionIfWeaponDoesNotExist()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetTest.UpgradeWeapon("weapon1");
                });
            }

            [Test]
            public void TestUpgradeWeaponMethodShouldWorkCorrectly()
            {
                planetTest.AddWeapon(weaponTest);
                planetTest.UpgradeWeapon("weaponTest");

                Assert.AreEqual(6, weaponTest.DestructionLevel);
            }

            [Test]
            public void TestDestructOpponentShouldThrowExceptionIfOpponentMilitaryPowerRatioIsTooStrong()
            {
                Planet planetOpponent = new Planet("planetOpponent", 200);
                planetOpponent.AddWeapon(weaponTest);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetTest.DestructOpponent(planetOpponent);
                });
            }

            [Test]
            public void TestDestructOpponentShouldWorkCorrectly()
            {
                Planet planetOpponent = new Planet("planetOpponent", 200);
                planetTest.AddWeapon(weaponTest);

                Assert.AreEqual("planetOpponent is destructed!", planetTest.DestructOpponent(planetOpponent));
            }
        }
    }
}
