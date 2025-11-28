using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class ArenaTests
    {
        [Test]
        public void Constructor_ShouldCreateEmptyCollection()
        {
            Arena arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Enroll_ShouldAddWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Peter", 50, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Enroll_ShouldThrow_IfWarriorAlreadyExists()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Peter", 50, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
                arena.Enroll(new Warrior("Peter", 40, 90)));
        }

        [Test]
        public void Fight_ShouldThrow_IfAttackerNotFound()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Peter", 50, 100));

            Assert.Throws<InvalidOperationException>(() =>
                arena.Fight("Missing", "Peter"));
        }

        [Test]
        public void Fight_ShouldThrow_IfDefenderNotFound()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Peter", 50, 100));

            Assert.Throws<InvalidOperationException>(() =>
                arena.Fight("Peter", "Missing"));
        }

        [Test]
        public void Fight_ShouldMakeTwoWarriorsAttackEachOther()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("A", 50, 100);
            Warrior defender = new Warrior("B", 40, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("A", "B");

            Assert.AreEqual(60, attacker.HP);
            Assert.AreEqual(50, defender.HP);
        }

        [Test]
        public void Fight_ShouldKillEnemyIfDamageIsHigher()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("A", 200, 100);
            Warrior defender = new Warrior("B", 40, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("A", "B");

            Assert.AreEqual(60, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }
    }
}
