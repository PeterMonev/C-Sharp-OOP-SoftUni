using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummuLosesHealthIfAttacked()
        {
            var axe = new Axe(10, 20);
            var dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(90));
        }

        [Test]

        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            var axe = new Axe(10, 20);
            var dummy = new Dummy(0, 100);

            Assert.Throws<InvalidOperationException>(() => { axe.Attack(dummy); }, "Dummy is dead.");
        }

        [Test]

        public void DeadDummyCanGiveXP()
        {
            var dummy = new Dummy(0, 100);

            var result = dummy.GiveExperience();

            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            var dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = dummy.GiveExperience();

            }, "Target is not dead.");
        }
    }
}