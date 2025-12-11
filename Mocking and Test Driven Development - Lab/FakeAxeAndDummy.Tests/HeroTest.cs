using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAxeAndDummy.Tests
{
    public class HeroTest
    {
        [Test]

        public void HeroGainExerienceWhenTargetIsDead()
        {
            var targetMock = new Mock<ITarget>();

            targetMock.Setup(t => t.IsDead()).Returns(true);

            targetMock.Setup(t => t.GiveExperience()).Returns(250);

            var weaponMock = new Mock<IWeapon>();

            var hero = new Hero("TestHero", weaponMock.Object);

            //Act
            hero.Attack(targetMock.Object);

            //Assert
            Assert.That(hero.Experience == 250);
        }

        [Test]

        public void HeroGainExerienceWhenTargetIsDeadWithFake()
        {
           

            var hero = new Hero("TestHero", new FakeWeapon());

            //Act
            hero.Attack(new FakeTarget());

            //Assert
            Assert.That(hero.Experience == 250);
        }
    }
}
