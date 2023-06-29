using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_Axe_Loses_Durability()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            //Act
            axe.Attack(new Dummy(100, 100));
            //Assert
            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void Test_Attack_With_Zero_Durability()
        {
            //Arrange
            Axe axe = new Axe(10, 1);
            //Act
            axe.Attack(new Dummy(100, 100));
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));
            });

            //Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}