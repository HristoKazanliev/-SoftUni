using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_Dummy_Loses_Health()
        {
            //Arrange
            Dummy dummy = new Dummy(20, 10);
            //Act
            dummy.TakeAttack(10);
            //Assert
            Assert.AreEqual(10, dummy.Health);
        }

        [Test]
        public void Test_Dead_Dummy_Throws_Exception()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(10);
            });
        }

        [Test]
        public void Test_Dead_Dummy_Gives_Exp()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);
            //Act
            //Assert
            Assert.AreEqual(10, dummy.GiveExperience());
        }

        [Test]
        public void Test_Alive_Dummy_Çan_Not_Give_Exp()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
            
        }
    }
}