using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class WarriorTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Warrior warrior = new Warrior("Peter", 50, 100);

            Assert.AreEqual("Peter", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Name_ShouldThrow_IfInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(() =>
                new Warrior(invalidName, 50, 100));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-50)]
        public void Damage_ShouldThrow_IfZeroOrNegative(int invalidDamage)
        {
            Assert.Throws<ArgumentException>(() =>
                new Warrior("Peter", invalidDamage, 100));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void HP_ShouldThrow_IfNegative(int invalidHp)
        {
            Assert.Throws<ArgumentException>(() =>
                new Warrior("Peter", 50, invalidHp));
        }

        // Attack validations
        [TestCase(29)]
        [TestCase(10)]
        [TestCase(0)]
        public void Attack_ShouldThrow_IfWarriorHpIsBelow30(int hp)
        {
            Warrior attacker = new Warrior("A", 50, hp);
            Warrior defender = new Warrior("B", 30, 50);

            Assert.Throws<InvalidOperationException>(() =>
                attacker.Attack(defender));
        }

        [TestCase(29)]
        [TestCase(10)]
        [TestCase(0)]
        public void Attack_ShouldThrow_IfEnemyHpIsBelow30(int hp)
        {
            Warrior attacker = new Warrior("A", 40, 50);
            Warrior defender = new Warrior("B", 20, hp);

            Assert.Throws<InvalidOperationException>(() =>
                attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrow_IfEnemyIsStronger()
        {
            Warrior attacker = new Warrior("A", 50, 50);
            Warrior defender = new Warrior("B", 100, 100);

            Assert.Throws<InvalidOperationException>(() =>
                attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldDecreaseHP_Correctly()
        {
            Warrior attacker = new Warrior("A", 50, 100);
            Warrior defender = new Warrior("B", 40, 100);

            attacker.Attack(defender);

            Assert.AreEqual(60, attacker.HP);  // 100 - 40
            Assert.AreEqual(50, defender.HP); // 100 - 50
        }

        [Test]
        public void Attack_ShouldSetEnemyHpToZero_WhenDamageIsHigher()
        {
            Warrior attacker = new Warrior("A", 200, 100);
            Warrior defender = new Warrior("B", 40, 100);

            attacker.Attack(defender);

            Assert.AreEqual(60, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }
    }
}
