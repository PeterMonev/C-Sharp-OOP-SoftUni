using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldDurabilityAfterEachAttack()
        {
            var axe = new Axe(10, 20);
            var dummy = new Dummy(100, 200);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(19));
            Assert.That(dummy.Health, Is.EqualTo(90));
        }

        [Test]

        public void AxeShouldNotAttackWithBrokenWeapon()
        {
            var axe = new Axe(10, 0);
            var dummy = new Dummy(100, 200);

            Assert.Throws<InvalidOperationException>(() => { axe.Attack(dummy); }, "Axe is broken.");
        }
    }
}